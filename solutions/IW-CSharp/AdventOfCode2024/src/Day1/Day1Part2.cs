namespace AdventOfCode2024
{
    public static class Day1Part2
    {
        public static double Day1Part2Main(string filePath)
        {
            // Save all the left and right numbers into two lists.
            var (leftList, rightList) = Day1HelperMethods.SaveInputInLists(filePath);

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
