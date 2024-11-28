Write-Host "Building $PSScriptRoot"
cargo build --release --manifest-path $psscriptroot\AdventOfCode\Cargo.toml
# Put all commands to build your project