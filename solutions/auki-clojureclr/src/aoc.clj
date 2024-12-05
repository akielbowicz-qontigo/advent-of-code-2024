(ns aoc
  (:require [clojure.string :as str]))

(defn day1 [lines]
  (let [pairs (map #(str/split % #"\s+") lines)
        left  (sort (map (comp int first) pairs))
        right (sort (map (comp int second) pairs))
        new-pairs (map vector left right)
        diffs (map #(apply - %) new-pairs)]
    (reduce + diffs)))

(defn day2 [lines]
  1000)

(defn solve [day lines]
  (cond
    (= (int day) 1) (day1 lines)
    (= (int day) 2) (day2 lines)
  :else (+ 100 day)) )

(defn -main [& args]
  (let [[day input] args
        file-content (slurp input)
        lines (str/split-lines file-content)
        result (solve day lines)] 
  result))

;; (defn -main [& args]
;;   (println (str "HELLO FROM CLOJURE:" args))
;;   (+ 100 (first args)))
