namespace AdventOfCode2024
{
    public static class Day1Part1
    {
        public static double Day1Part1Main(string filePath)
        {
            // Save all the left and right numbers into two lists.
            var (leftList, rightList) = Day1HelperMethods.SaveInputInLists(filePath);

            // Sort the two lists, calculate the differences between the elements and sum.
            leftList.Sort();
            rightList.Sort();
            var differences = leftList.Zip(rightList, (x, y) => Math.Abs(x - y)).ToList();
            var sumOfDifferences = differences.Sum();

            return sumOfDifferences;
        }
    }
}
