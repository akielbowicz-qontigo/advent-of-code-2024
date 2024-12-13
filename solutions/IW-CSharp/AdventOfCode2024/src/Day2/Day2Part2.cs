namespace AdventOfCode2024
{
    public static class Day2Part2
    {
        public static double Day2Part2Main(string filePath)
        {
            var safeReportCount = 0;

            foreach (string line in File.ReadLines(filePath))
            {
                var report = line.Split(' ').Select(n => int.Parse(n)).ToList();
                if (report.IsSafeWithProblemDampener())
                {
                    safeReportCount++;
                }
            }

            return safeReportCount;
        }

        private static bool IsSafeWithProblemDampener(this List<int> report)
        {
            if (report.IsSafe()) return true;

            // If the report is not directly safe, we try to remove one element at a time and see if we can make it safe this way.
            for (var i = 0; i < report.Count; i++)
            {
                var tempReport = new List<int>(report);  // Copy by value to avoid modifying the original report!
                tempReport.RemoveAt(i);
                if (tempReport.IsSafe())
                {
                    return true;
                }
            }

            // If we made it here, it means the report is not safe and removing one element from it won't make it safe either.
            return false;
        }
    }
}
