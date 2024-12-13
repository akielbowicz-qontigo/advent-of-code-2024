(ns aoc
  (:require
   [clojure.string :as str]
   [day1 :refer [day1]]
   [day2]))


(defn solve [day lines]
  (cond
    (= (int day) 1) (day1 lines)
    (= (int day) 2) (day2/day2 lines)
   :else (+ 100 day)))

(comment
  (def input "../../problems/day-02/input.txt")
  (def lines (read-content input))
  )

(defn read-content [input]
  (let [
        file-content (slurp input)
        lines        (str/split-lines file-content)]
    lines))

(defn -main [& args]
  (let [[day input] args
        lines (read-content input)
        result (solve day lines)] 
   result))
