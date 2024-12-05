param(
    [int]$day,
    [string]$inputAbsolutePath
)

$result = . $PSScriptRoot/bin/aoc.exe $day $inputAbsolutePath
return $result
