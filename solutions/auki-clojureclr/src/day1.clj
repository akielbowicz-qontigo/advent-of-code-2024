(ns day1
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

