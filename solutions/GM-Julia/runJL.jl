day = ARGS[1]
path = ARGS[2]

include("Day3/day3.jl") # Inserta contenido del archivo aca. Como si fuese copy paste.
path = "C:/Dev/advent-of-code-2024/problems/day-03/input.txt"
content = read(path, String)
lines = join(split(content, "\n"))
println(total_multiplication(lines))