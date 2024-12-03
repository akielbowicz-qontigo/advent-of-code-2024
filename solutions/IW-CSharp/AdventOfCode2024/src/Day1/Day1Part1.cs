namespace AdventOfCode2024
{
    public static class Day1Part1
    {
        public static double Day1Part1Main(string filePath)
        {
            // Save all the left and right numbers into two lists.
            var leftList = new List<int>();
            var rightList = new List<int>();
            foreach (string line in File.ReadLines(filePath))
            {
                var leftNumber = Day1HelperMethods.GetLeftNumberFromLine(line);
                leftList.Add(leftNumber);

                var rightNumber = Day1HelperMethods.GetRightNumberFromLine(line);
                rightList.Add(rightNumber);
            }

            // Sort the two lists, calculate the differences between the elements and sum.
            leftList.Sort();
            rightList.Sort();
            var differences = leftList.Zip(rightList, (x, y) => Math.Abs(x - y)).ToList();
            var sumOfDifferences = differences.Sum();

            return sumOfDifferences;
        }
    }
}
