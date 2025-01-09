(ns day4
    (:require [clojure.string :as str]
              [utils]))

(comment 
  (def input "../../problems/day-04/input.txt") 
  (def lines (utils/read-content input))
      (part-1 lines)
  (def r  (part-1 lines))
  
  )
  

(defn vecinos 
  ([posx posy n] 
   (vector
    (mapv #(vector (+ posx %) posy) (range n))
    (mapv #(vector (- posx %) posy) (range n)) 
    (mapv #(vector posx (+ posy %)) (range n)) 
    (mapv #(vector posx (- posy %)) (range n)) 
    (mapv #(vector (+ posx %) (+ posy %)) (range n)) 
    (mapv #(vector (+ posx %) (- posy %)) (range n)) 
    (mapv #(vector (- posx %) (+ posy %)) (range n)) 
    (mapv #(vector (- posx %) (- posy %)) (range n))))
  ([posx posy]
   (vecinos posx posy 4))) 

(defn indices-de-xs [lines]
(let [ indices  (map-indexed
                 (fn [row-idx line]
                   (map-indexed
                    (fn [col-idx char]
                      (when (= char \X)
                        [row-idx col-idx]))
                    line))
                 lines) 
      ]
  (filter some? (mapcat identity indices))
  ))

(defn get-letra [lines]
  (fn [row col]
    (get-in lines [row col])))

(defn part-1 [lines]
  (let [
        letra (get-letra lines)
        xs (indices-de-xs lines)
        m (mapcat (fn [[x y]] (vecinos x y)) xs)  
        palabras (map (fn [v] (str/join (map (fn [[r c]] (letra r c)) v))) m)
        xmas (filter (fn [p] (= p "XMAS")) palabras)
        ]
    (count xmas)))


;;   for each letter indexed by row and column  
;;   if letter is X get the neighbors
;;   for each neighbors check if it maches XMAS
  



(defn part-2 [lines]
   2)
