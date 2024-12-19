function total_multiplication(input)
    sum = 0
    check_mul_pattern = true
    mul_pattern = "mul("
    mul_pattern_iter = 1
    left_number = ""
    right_number = ""
    left_side = true

    for char in input
        if check_mul_pattern
            if char == mul_pattern[mul_pattern_iter]
                mul_pattern_iter += 1
            else
                mul_pattern_iter = 1
            end
            if mul_pattern_iter > length(mul_pattern)
                check_mul_pattern = false
                mul_pattern_iter = 1
                continue
            end
        end

        if !check_mul_pattern
            if isdigit(char)
                if left_side
                    left_number = string(left_number, char)
                else
                    right_number = string(right_number, char)
                end
            elseif char == ',' && !isempty(left_number)
                left_side = false
            elseif char == ')' && !isempty(left_number) && !isempty(right_number)
                sum += parse(Int, left_number) * parse(Int, right_number)
                left_number = ""
                right_number = ""
                check_mul_pattern = true
                left_side = true
            else
                left_number = ""
                right_number = ""
                check_mul_pattern = true
                left_side = true
            end
        end
    end

    return sum
end

# Example usage
path = "C:/Dev/advent-of-code-2024/problems/day-03/input.txt"
content = read(path, String)
lines = join(split(content, "\n"))
println(total_multiplication(lines))
