Write-Host "Building $PSScriptRoot"
dotnet publish $PSScriptRoot\csharp-wrapper\aoc.csproj -o $PSScriptRoot\bin
# Put all commands to build your project