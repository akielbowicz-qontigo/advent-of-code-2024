param(
    [int]$day,
    [string]$inputAbsolutePath
)

$result = julia $psscriptroot/runJL.jl $day $inputAbsolutePath
return $result