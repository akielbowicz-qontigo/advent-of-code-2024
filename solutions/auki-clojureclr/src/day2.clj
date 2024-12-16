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

(defn subcollections [coll]
  (map #(concat (take % coll) (drop (inc %) coll)) (range (count coll))))

(defn valid-2! [row]
  (if (valid! (increments row))
    true
    (boolean (some (comp valid! increments) (subcollections row)))))

(comment
  (first aoc/lines) 
  (map (comp identity row) test.aoc/day2-input) 
  (map (comp increments row) test.aoc/day2-input) 
  (map (comp valid-2! row) test.aoc/day2-input) 
  (day2-2  test.aoc/day2-input)
  (day2-2 (take 3 aoc/lines))
  (day2-2  aoc/lines)
  (subcollections [1 2 3 4]))

(defn day2 [lines]
  (let [rows (map (comp increments row) lines)]
     (count (filter valid! rows))))

(defn day2-2 [lines]
  (let [rows (map row lines)]
    (count (filter valid-2! rows))))
  
