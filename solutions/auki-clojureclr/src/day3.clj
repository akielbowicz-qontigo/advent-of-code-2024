(ns day3
  (:require [clojure.string :as str]))

(def regex #"mul\((\d+),(\d+)\)")

(defn matches [s] 
  (re-seq regex s))

(defn mult [b c]
  (apply * (map int [b c])))

(defn sum-all-matches [line]
  (let [ms (matches line)
        n (map #(mult (nth % 1) (nth % 2)) ms)]
    (reduce + n)))

(def regex-2 #"do\(\)|don't\(\)|mul\((\d+),(\d+)\)")

(defn matches-2 [s]
  (re-seq regex-2 s))

(defn rf [st match]
  (let [[total flag] st
        [m a b] match]
    ;; (println (str "st: " st))
    ;; (println (str "match: " match)) 
    (cond 
      (= m "do()") [total :t]
      (= m "don't()") [total :f]
      (= flag :t) [(+ total (* (int a) (int b))) flag]
      (= flag :f) [total flag]
      )))

(defn sum-filtered [st line]
  (let [ms (matches-2 line)
        [total flag] st
       n (reduce rf [total flag] ms)]
  n))

(comment
  (matches (first test.aoc/day3-input))
  (day3 test.aoc/day3-input) 
  (day3-2  test.aoc/day3-2-input)
  (sum-filtered [0 :t] (first test.aoc/day3-2-input)) 
  (day3-2 aoc/lines)
  )

(defn day3 [lines]
  (let [ n (map sum-all-matches lines) ] 
    (reduce + n))
)

(defn day3-2 [lines]
  (let [[a b] (reduce sum-filtered [0 :t] lines) ] 
    a)
 )
  
