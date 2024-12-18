﻿using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public static class Day3Part2
    {
        public static double Day3Part2Main(string filePath)
        {
            var searchPattern = @"(mul)\((\d+),(\d+)\)|do\(\)|don't\(\)";

            var total = 0;
            var isEnabled = true;
            foreach (string line in File.ReadLines(filePath))
            {
                MatchCollection matches = Regex.Matches(line, searchPattern);

                var currentTotal = 0;
                foreach (Match match in matches)
                {
                    if (match.Value == "do()")
                    {
                        isEnabled = true;
                    }
                    if (match.Value == "don't()")
                    {
                        isEnabled = false;
                    }

                    if (isEnabled == true && match.Groups[1].Value == "mul")
                    {
                        var first = int.Parse(match.Groups[2].Value);
                        var second = int.Parse(match.Groups[3].Value);
                        currentTotal += first * second;
                    }
                    
                }
                total += currentTotal;
            }

            return total;
        }
    }
}
