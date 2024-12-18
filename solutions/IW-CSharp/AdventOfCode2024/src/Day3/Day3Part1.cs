using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public static class Day3Part1
    {
        public static double Day3Part1Main(string filePath)
        {
            var total = 0;
            foreach (string line in File.ReadLines(filePath))
            {
                var searchPattern = @"(mul)\((\d+),(\d+)\)";
                MatchCollection matches = Regex.Matches(line, searchPattern);

                var currentTotal = 0;
                foreach (Match match in matches)
                {
                    var first = int.Parse(match.Groups[2].Value);
                    var second = int.Parse(match.Groups[3].Value);
                    currentTotal += first * second;
                }
                total += currentTotal;
            }

            return total;
        }
    }
}
