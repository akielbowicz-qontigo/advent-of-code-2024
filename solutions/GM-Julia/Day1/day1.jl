function total_distance(left_list, right_list)
    sort!(left_list)
    sort!(right_list)
    total_distance = sum(abs(left_list[i] - right_list[i]) for i in 1:length(left_list))
    return total_distance
end

left_list = [3, 4, 2, 1, 3, 3]
right_list = [4, 3, 5, 3, 9, 3]

result = total_distance(left_list, right_list)

println("Total distance between lists: $result")