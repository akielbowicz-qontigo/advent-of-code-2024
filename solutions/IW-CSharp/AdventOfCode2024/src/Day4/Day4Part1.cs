using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public static class Day4Part1
    {
        public static double Day4Part1Main(string filePath)
        {
            var searchWord = "XMAS";  // Note: This implementation will work for any word with 4 characters.

            var lines = File.ReadLines(filePath);
            var numberOfLines = lines.Count();
            var numberOfChars = lines.First().Length;  // All lines have the same length, we can use the first one.

            var horizontals = ComputeHorizontals(lines, searchWord);
            var verticals = ComputeVerticals(lines, numberOfLines, numberOfChars, searchWord);
            var diagonals = ComputeDiagonals(lines, numberOfLines, numberOfChars, searchWord);

            var total = horizontals + verticals + diagonals;
            return total;
        }

        private static int ComputeHorizontals(IEnumerable<string> lines, string searchWord)
        {
            var searchWordReversed = searchWord.Reverse();
            
            var counter = 0;
            foreach (var line in lines)
            {
                counter += Regex.Matches(line, searchWord).Count;
                counter += Regex.Matches(line, searchWordReversed).Count;
            }

            return counter;
        }

        private static int ComputeVerticals(IEnumerable<string> lines, int numberOfLines, int numberOfChars, string searchWord)
        {
            var counter = 0;
            var linesList = new List<string>() { "", "", "", "" };
            var linesEnumerator = lines.GetEnumerator();

            // Save the first lines in the list.
            for (var currentLine = 0; currentLine < 4; currentLine++)
            {
                linesEnumerator.MoveNext();
                linesList[currentLine] = linesEnumerator.Current;
            }

            // Search in the columns of the first lines.
            counter += CountWordInColumns(linesList, numberOfChars, searchWord);

            // With the first lines already in the list, let's iterate over all the lines.
            for (var currentLine = 4; currentLine < numberOfLines; currentLine++)
            {
                // Shift the lines for the next iteration.
                linesEnumerator.MoveNext();
                linesList[0] = linesList[1];
                linesList[1] = linesList[2];
                linesList[2] = linesList[3];
                linesList[3] = linesEnumerator.Current;

                // Search in the columns of the current lines.
                counter += CountWordInColumns(linesList, numberOfChars, searchWord);
            }

            return counter;
        }

        /// <summary>
        /// Given a set of lines of equal lenght, it searches for the given <paramref name="searchWord"/> in columns (from up to down).
        /// </summary>
        /// <param name="lines">The lines, in a list. The first one is the upper one, and so on.
        /// <param name="numberOfChars">The number of characters that the lines have. This will determine the number of columns.</param>
        /// <param name="searchWord">The word to search and count its appearances.</param>
        /// <returns>The number of times the word appears.</returns>
        private static int CountWordInColumns(List<string> lines, int numberOfChars, string searchWord)
        {
            var searchWordReversed = searchWord.Reverse();
            
            var counter = 0;
            for (var i = 0; i < numberOfChars; i++)
            {
                var str = $"{lines[0][i]}{lines[1][i]}{lines[2][i]}{lines[3][i]}";
                if (str == searchWord || str == searchWordReversed)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int ComputeDiagonals(IEnumerable<string> lines, int numberOfLines, int numberOfChars, string searchWord)
        {
            var counter = 0;
            var linesList = new List<string>() { "", "", "", "" };
            var linesEnumerator = lines.GetEnumerator();

            // Save the first lines in the list.
            for (var currentLine = 0; currentLine < 4; currentLine++)
            {
                linesEnumerator.MoveNext();
                linesList[currentLine] = linesEnumerator.Current;
            }

            // Search in the diagonals of the first lines.
            counter += CountWordInDiagonals(linesList, numberOfChars, searchWord);

            // With the first lines already in the list, let's iterate over all the lines.
            for (var currentLine = 4; currentLine < numberOfLines; currentLine++)
            {
                // Shift the lines for the next iteration.
                linesEnumerator.MoveNext();
                linesList[0] = linesList[1];
                linesList[1] = linesList[2];
                linesList[2] = linesList[3];
                linesList[3] = linesEnumerator.Current;

                // Search in the diagonals of the current lines.
                counter += CountWordInDiagonals(linesList, numberOfChars, searchWord);
            }

            return counter;
        }

        private static int CountWordInDiagonals(List<string> lines, int numberOfChars, string searchWord)
        {
            var searchWordReversed = searchWord.Reverse();

            var counter = 0;
            for (var i = 0; i < numberOfChars - 3; i++)
            {
                var strSE = $"{lines[0][i]}{lines[1][i + 1]}{lines[2][i + 2]}{lines[3][i + 3]}";
                var strNE = $"{lines[3][i]}{lines[2][i + 1]}{lines[1][i + 2]}{lines[0][i + 3]}";

                if (strSE == searchWord || strSE == searchWordReversed)
                {
                    counter++;
                }
                
                if (strNE == searchWord || strNE == searchWordReversed)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
