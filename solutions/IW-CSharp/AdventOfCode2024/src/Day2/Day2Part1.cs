namespace AdventOfCode2024
{
    public static class Day2Part1
    {
        public static double Day2Part1Main(string filePath)
        {
            var safeReportCount = 0;

            foreach (string line in File.ReadLines(filePath))
            {
                var report = line.Split(' ').Select(n => int.Parse(n)).ToList();
                if (report.IsSafe())
                {
                    safeReportCount++;
                }
            }

            return safeReportCount;
        }

        private static bool IsSafe(this List<int> report)
        {
            // Check strictly monotone condition.
            if (!report.LevelsAreDecreasing() && !report.LevelsAreIncreasing())
            {
                return false;
            }

            // Check maximun change condition. The minimum change condition is redundant at this point so we don't check it.
            for (var i = 1; i < report.Count; i++)
            {
                if (Math.Abs(report[i] - report[i-1]) > 3)
                {
                    return false;
                }
            }

            // If we made it here, it means the report is safe.
            return true;
        }

        private static bool LevelsAreDecreasing(this List<int> report)
        {
            for (var i = 1; i < report.Count; i++)
            {
                if (report[i] >= report[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool LevelsAreIncreasing(this List<int> report)
        {
            for (var i = 1; i < report.Count; i++)
            {
                if (report[i] <= report[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
