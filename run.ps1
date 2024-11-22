param(
    [int]$day,
    [string]$solution,
    [switch]$setup
)

function Resolve-InputPath {
    param(
        [int]$day
    )
    Resolve-Path (Join-Path $PSScriptRoot problems ("day-{0:D2}" -f $day) input.txt)
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

$results