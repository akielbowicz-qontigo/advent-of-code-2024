namespace AdventOfCode2024
{
    public static class Day1Part2
    {
        public static double Day1Part2Main(string filePath)
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

            // Calculate the similarity score.
            var similarityScore = 0;
            foreach (var leftNumber in leftList)
            {
                var appearancesInRightList = rightList.Count(n => n == leftNumber);
                similarityScore += leftNumber * appearancesInRightList;
            }

            return similarityScore;
        }
    }
}
