;; FILE: test/test_runner.clj
(ns test-runner
  (:require [clojure.test :refer :all]
            [test.aoc]))

(defn -main []
  (run-tests 'test.aoc))