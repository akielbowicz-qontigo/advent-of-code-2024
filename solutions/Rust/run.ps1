param(
    [int]$day,
    [string]$inputAbsolutePath
)
# Put your command to execute here
# it should receive an integer indicating the day to run and the problem input absolute path
# $result = adventOfCode.exe 1 "$inputAbsolutePath"
$result = . $psscriptroot\AdventOfCode\target\release\AdventOfCode.exe $day $inputAbsolutePath
return $result