namespace AdventOfCode2024
{
    public static class Day4Part2
    {
        public static int Day4Part2Main(string filePath)
        {
            var searchWord = "MAS";  // Note: This implementation will work for any word with 3 characters.

            var lines = File.ReadLines(filePath);
            var numberOfLines = lines.Count();
            var numberOfChars = lines.First().Length;  // All lines have the same length, we can use the first one.

            var crosses = CountCrosses(lines, numberOfLines, numberOfChars, searchWord);
            return crosses;
        }

        public static int CountCrosses(IEnumerable<string> lines, int numberOfLines, int numberOfChars, string searchWord)
        {
            var counter = 0;
            var linesList = new List<string>() { "", "", "" };
            var linesEnumerator = lines.GetEnumerator();

            // Save the first lines in the list.
            for (var currentLine = 0; currentLine < 3; currentLine++)
            {
                linesEnumerator.MoveNext();
                linesList[currentLine] = linesEnumerator.Current;
            }

            // Search in the first lines.
            counter += CountCurrentCrosses(linesList, numberOfChars, searchWord);

            // With the first lines already in the list, let's iterate over all the lines.
            for (var currentLine = 3; currentLine < numberOfLines; currentLine++)
            {
                // Shift the lines for the next iteration.
                linesEnumerator.MoveNext();
                linesList[0] = linesList[1];
                linesList[1] = linesList[2];
                linesList[2] = linesEnumerator.Current;

                // Search in the diagonals of the current lines.
                counter += CountCurrentCrosses(linesList, numberOfChars, searchWord);
            }

            return counter;
        }

        private static int CountCurrentCrosses(List<string> lines, int numberOfChars, string searchWord)
        {
            var searchWordReversed = searchWord.Reverse();

            var counter = 0;
            for (var i = 0; i < numberOfChars - 2; i++)
            {
                var strSE = $"{lines[0][i]}{lines[1][i + 1]}{lines[2][i + 2]}";
                var strNE = $"{lines[2][i]}{lines[1][i + 1]}{lines[0][i + 2]}";

                if ((strSE == searchWord || strSE == searchWordReversed) &&
                    (strNE == searchWord || strNE == searchWordReversed))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
