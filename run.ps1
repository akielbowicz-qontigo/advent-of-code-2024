param(
    [int]$day,
    [string]$solution,
    [switch]$setup,
    [switch]$overrideResult
)

function Resolve-InputPath {
    param(
        [int]$day
    )
    Resolve-ProblemsPath $day input.txt
}

function Resolve-ResultPath {
    param(
        [int]$day
    )
    Resolve-ProblemsPath $day result.txt
}


function Resolve-ProblemsPath {
    param (
        [int]$day,
        [string]$name
    )
    Resolve-Path (Join-Path $PSScriptRoot problems ("day-{0:D2}" -f $day) $name)
}

function Invoke-Solution {    
    param(
        [string]$solution,
        [int]$day)

    if ($day -eq 0){
        $days = 1..31
    } else {
        $days = @($day) 
    }    

    $result = $days | %{ . $solution $_ (Resolve-InputPath $_)}
    $result
}

function Override-Result {
    param(
        [int]$day,
        $newResult
    )
    $newResult | Out-File (Resolve-ResultPath $day)
}

function Get-ExpectedResult {
    param(
        [Parameter(ValueFromPipeline=$true)]
        [int]$day
    )
    process {
        Get-Content (Resolve-ResultPath $day)
    }
}

function Format-Results {
    param(
        $results,
        $expectedResults,
        $day
    )
    $isSingleResult = $day -gt 0
    Write-Debug "Is single day: $isSingleResult"
    Write-Debug "Results: $($results | Out-String)"
    $days = $isSingleResult ? @($day-1) : 0..30  

    Write-Host $results, $days    
    $out = $results.GetEnumerator() | %{
        $pair = $_
        Write-Debug "values: $($pair.Value)"
        $t = @{"Solution" = $pair.Key }
        $days | %{
            $d = $_ 
            $actual = $isSingleResult ? $pair.Value : $pair.Value[$d]
            $expected = $expectedResults[$d]
            Write-Debug "i:$i, d:$d, actual: $actual, expected: $expected"
            $c = ($actual -eq $expected) ? "✅" : "❌ a:$actual != e:$expected"
            $t.Add("Day {0:D2}" -f ($d+1), $c )
         }
         
        [PSCustomObject]$t
    } 
    $out
}


if ($overrideResult -and [string]::IsNullOrEmpty($solution)){
    Write-Error "Can not override result without a specific solution. Please provide a solution name: '-solution mySolution'"
    exit 1
}

$solutions = Get-ChildItem (Join-Path $PSScriptRoot solutions) # | where {$_.Name -ne "template"} 
$solutionPath = (Join-Path $PSScriptRoot solutions $solution)

$solExists = Test-Path -Path $solutionPath -PathType Container

if (-not [string]::IsNullOrEmpty($solution) -and $solExists){
    $solutions = $( (Get-Item $solutionPath) )
}elseif (-not [string]::IsNullOrEmpty($solution) -and -not $solExists){
    throw "Solution '$solutionPath' does not exist."
}

if ($setup){
    foreach ($solution in $solutions) {
        $build = (Join-Path $solution setup.ps1)
        . $setup
    }
    Write-Host "Completed setup"
    return
}

$results = @{}
foreach ($solutionPath in $solutions) {
    $build = (Join-Path $solutionPath build.ps1)
    $runPath = (Join-Path $solutionPath run.ps1)
    . $build
    $solutionResults = Invoke-Solution $runPath $day
    $results.add($solutionPath.Name, $solutionResults)
}
Write-Debug "Actual results: $($results | Out-String)"

if ($overrideResult){
    Write-Host "Overriding results"
    $res = $results[$solution]
    if ($day -eq 0){
        1..31 | %{ Override-Result $_ $res[$_] }
    }else{
        Override-Result $day $res[0]
    }
    return
}

$expectedResults = 1..31 | Get-ExpectedResult
Write-Debug "Expected results: $expectedResults"
Format-Results $results $expectedResults $day