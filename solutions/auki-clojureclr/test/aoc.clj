;; FILE: test/core_test.clj
(ns test.aoc
  (:require
   [clojure.string :as str]
   [clojure.test :refer :all]
   [day1 :refer [day1 day1-2]]
   [day2 :refer [day2 day2-2]]))

(def day1-input (str/split-lines "3   4
4   3
2   5
1   3
3   9
3   3"))

(deftest test-day1
  (testing "Day 1" 
    (is (= 11 (day1 day1-input)))))

(deftest test-day1-p2
  (testing "Day 1 part 2" 
    (is (= 11 (day1-2 day1-input)))))

(def day2-input (str/split-lines "7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9"))

(deftest test-day2
  (testing "Day 2" 
    (is (= 2 (day2 day2-input)))))

(deftest test-day2-p2
  (testing "Day 2 part 2" 
    (is (= 11 (day2-2 day2-input)))))