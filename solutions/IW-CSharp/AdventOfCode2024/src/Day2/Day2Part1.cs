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
    }
}
