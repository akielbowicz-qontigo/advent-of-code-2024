(ns utils 
  (:require
   [clojure.string :as str]))


(defn read-content [input]
  (let [file-content (slurp input)
        lines        (str/split-lines file-content)]
    lines))