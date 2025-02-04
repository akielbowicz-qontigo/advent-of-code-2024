# advent-of-code-2024

Solutions to the Advent Of Code 2024 by some of the Simcorp Buenos Aires Devs


## How to run the problems

To run all solutions execute without any parameter:

```powershell
> .\run.ps1
```

To run for a specific solution like "mySolution" and a day execute:

```powershell
> .\run.ps1 -solution mySolution -day 8
```

To configure a project and install its dependencies run:

```powershell
> .\run.ps1 -solution mySolution -setup
```

## How to add a new solution

Copy the template solution `solutions/template` 

```powershell
cp -Recurse solutions/template solutions/mySolution-{initials}-{language}
```

Then you have to populate three files, which are self explanatory:

- [setup.ps1](./solutions/template/setup.ps1)
- [build.ps1](./solutions/template/build.ps1)
- [run.ps1](./solutions/template/run.ps1)

You can do whatever you what within your solution directory, but be considerate with the rest


## How to get the inputs

```powershell
> $env:AOC_TOKEN="<your session token>"
> get-input.ps1 -day 2 > problems/day-02/input.txt
```

To get your token you need to check the cookies once loged into AoC
![](session-token.png)
