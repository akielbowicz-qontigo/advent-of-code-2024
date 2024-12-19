function total_distance(left_list, right_list)
    sort!(left_list)
    sort!(right_list)
    total_distance = sum(abs(left_list[i] - right_list[i]) for i in 1:length(left_list))
    return total_distance
end