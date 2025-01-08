using System.Text.RegularExpressions;
using static AdventOfCode2024.Day4Utilities;

namespace AdventOfCode2024
{
    public static class Day4Part1Simpler
    {
        public static double Day4Part1Main(string filePath)
        {
            var searchWord = "XMAS";  // Note: This implementation will work for any word with 4 characters.

            var numberOfLines = File.ReadLines(filePath).Count();
            var numberOfChars = File.ReadLines(filePath).First().Length;  // All lines have the same length, we can use the first one.

            var horizontals = ComputeHorizontals(filePath, searchWord);
            var verticals = ComputeVerticals(filePath, numberOfLines, numberOfChars, searchWord);
            var diagonals = ComputeDiagonals(filePath, numberOfLines, numberOfChars, searchWord);

            var total = horizontals + verticals + diagonals;
            return total;
        }

        private static int ComputeHorizontals(string filePath, string searchWord)
        {
            var searchWordReversed = searchWord.Reverse();
            
            var counter = 0;
            foreach (var line in File.ReadLines(filePath))
            {
                counter += Regex.Matches(line, searchWord).Count;
                counter += Regex.Matches(line, searchWordReversed).Count;
            }

            return counter;
        }

        private static int ComputeVerticals(string filePath, int numberOfLines, int numberOfChars, string searchWord)
        {
            var counter = 0;
            var lines = new List<string>() { "", "", "", "" };
            var enumerator = File.ReadLines(filePath).GetEnumerator();

            // Save the first lines in the list.
            for (var currentLine = 0; currentLine < 4; currentLine++)
            {
                enumerator.MoveNext();
                lines[currentLine] = enumerator.Current;
            }

            // Search in the columns of the first lines.
            counter += CountWordInColumns(lines, numberOfChars, searchWord);

            // With the first lines already in the list, let's iterate over all the lines.
            for (var currentLine = 4; currentLine < numberOfLines; currentLine++)
            {
                // Shift the lines for the next iteration.
                enumerator.MoveNext();
                lines[0] = lines[1];
                lines[1] = lines[2];
                lines[2] = lines[3];
                lines[3] = enumerator.Current;

                // Search in the columns of the current lines.
                counter += CountWordInColumns(lines, numberOfChars, searchWord);
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

        private static int ComputeDiagonals(string filePath, int numberOfLines, int numberOfChars, string searchWord)
        {
            var counter = 0;
            var lines = new List<string>() { "", "", "", "" };
            var enumerator = File.ReadLines(filePath).GetEnumerator();

            // Save the first lines in the list.
            for (var currentLine = 0; currentLine < 4; currentLine++)
            {
                enumerator.MoveNext();
                lines[currentLine] = enumerator.Current;
            }

            // Search in the diagonals of the first lines.
            counter += CountWordInDiagonals(lines, numberOfChars, searchWord);

            // With the first lines already in the list, let's iterate over all the lines.
            for (var currentLine = 4; currentLine < numberOfLines; currentLine++)
            {
                // Shift the lines for the next iteration.
                enumerator.MoveNext();
                lines[0] = lines[1];
                lines[1] = lines[2];
                lines[2] = lines[3];
                lines[3] = enumerator.Current;

                // Search in the diagonals of the current lines.
                counter += CountWordInDiagonals(lines, numberOfChars, searchWord);
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

                if (strSE == searchWord || strSE == searchWordReversed ||
                    strNE == searchWord || strNE == searchWordReversed)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
