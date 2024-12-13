(ns day2
  (:require [clojure.string :as str]))

(defn row [line]
  (map #(int %) (str/split line #"\s+")))

(defn increments [row]
  (map - row (rest row)))



(defn valid! [row]
  (let [same-sign (apply = (map #(>= % 0) row))
        in-range (every? #(<= 1 (abs %) 3) row)]
    (and same-sign in-range)))

(comment
  (first aoc/lines) 
  (map (comp identity row) test.aoc/day2-input) 
  (map (comp increments row) test.aoc/day2-input) 
  (map (comp valid! increments row) test.aoc/day2-input) 
  ( let [r (row (second aoc/lines))
         x (map - r (rest r))]
    (valid! x))
  (day2 (take 3 aoc/lines))
  )
  

(defn day2 [lines]
  (let [rows (map (comp increments row) lines)]
     (count (filter valid! rows))))

(defn day2-2 [lines]
  lines)
