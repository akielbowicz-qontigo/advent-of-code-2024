(ns aoc
  (:require
   [day1 :refer [day1]]
   [day2]
   [day3]
   [day4]
   [utils :refer [read-content]]))
   


(defn solve [day lines]
  (cond
    (= (int day) 1) (day1 lines)
    (= (int day) 2) (day2/day2-2 lines)
    (= (int day) 3) (day3/day3 lines)
    (= (int day) 4) (day4/part-2 lines)
    :else (+ 100 day)))

(comment
  (def input "../../problems/day-03/input.txt")
  (def lines (utils/read-content input))
  )


(defn -main [& args]
  (let [[day input] args
        lines (utils/read-content input)
        result (solve day lines)] 
   result))
