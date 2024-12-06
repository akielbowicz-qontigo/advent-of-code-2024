(ns aoc
  (:require [clojure.string :as str]))

(defn split-cols [lines]
  (let  [
         pairs (map #(str/split % #"\s+") lines)
         left  (map (comp int first) pairs) 
         right (map (comp int second) pairs)] 
        
    [left, right]))

(defn day1 [lines]
  (let [[left right] (split-cols lines)
        new-pairs (map vector (sort left) (sort right))
        diffs (map #(apply - %) new-pairs)]
    (reduce + (map abs diffs))))

(defn counter [coll]
  (reduce (fn [counts num]
            (update counts num (fnil inc 0)))
          {}
          coll))

(defn day1-2 [lines]
  (let [[left right] (split-cols lines)
         right-counts (counter right)
        weighted (map #(apply * [% (get right-counts % 0)]) left)]
    (reduce + weighted)))

(defn day2 [lines]
  0)

(defn solve [day lines]
  (cond
    (= (int day) 1) (day1 lines)
    (= (int day) 2) (day2 lines)
   :else (+ 100 day)))

(comment
  (def input "../../problems/day-01/input.txt")
  (def lines (read-content input))
  (split-cols lines) 
  (day1 lines)
  ((counter (second (split-cols lines)) ) 0)  
  (day1-2 lines)
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

;; (defn -main [& args]
;;   (println (str "HELLO FROM CLOJURE:" args))
;;   (+ 100 (first args)))
