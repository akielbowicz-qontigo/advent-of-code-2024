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
        $days = $($day) 
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

if ($overrideResult -and [string]::IsNullOrEmpty($solution)){
    Write-Error "Can not override result without a specific solution. Please provide a solution name: '-solution mySolution'"
    exit 1
}

$solutions = Get-ChildItem (Join-Path $PSScriptRoot solutions) # | where {$_.Name -ne "template"} 
$solutionPath = (Join-Path $PSScriptRoot solutions $solution)

$solExists = Test-Path -Path $solutionPath -PathType Container

if (-not [string]::IsNullOrEmpty($solution) -and $solExists){
    $solutions = $( $solutionPath )
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

foreach ($solution in $solutions) {
    $build = (Join-Path $solution build.ps1)
    $runPath = (Join-Path $solution run.ps1)
    . $build
    $solutionResults = Invoke-Solution $runPath $day
    $results.add($solution, $solutionResults)
}

if ($overrideResult){
    Write-Host "Overriding results"
    $res = $results[$solution]
    if ($day -eq 0){
        1..31 | %{ Override-Result $_ $res[$_] }
    }else{
        Override-Result $day $res[0]
    }
}

$results | Format-List