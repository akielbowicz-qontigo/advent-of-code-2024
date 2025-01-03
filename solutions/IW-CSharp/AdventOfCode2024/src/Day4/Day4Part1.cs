using System.Text.RegularExpressions;
using static AdventOfCode2024.Day4Utilities;

namespace AdventOfCode2024
{
    public static class Day4Part1
    {
        public static double Day4Part1Main(string filePath)
        {
            var searchWord = "XMAS";  // Note: This implementation will work for any word with 4 characters.

            var numberOfLines = File.ReadLines(filePath).Count();
            var numberOfChars = File.ReadLines(filePath).First().Length;  // All lines have the same length, we can use the first one.

            var horizontalsLeftToRight = ComputeHorizontals(filePath, searchWord, RowDirection.LeftToRight);
            var horizontalsRightToLeft = ComputeHorizontals(filePath, searchWord, RowDirection.RightToLeft);

            var verticalsUpToDown = ComputeVerticals(filePath, numberOfLines, numberOfChars, searchWord, ColumnDirection.UpToDown);
            var verticalsDownToUp = ComputeVerticals(filePath, numberOfLines, numberOfChars, searchWord, ColumnDirection.DownToUp);

            var diagonalsNE = ComputeDiagonals(filePath, numberOfLines, numberOfChars, searchWord, DiagonalDirection.NE);
            var diagonalsSE = ComputeDiagonals(filePath, numberOfLines, numberOfChars, searchWord, DiagonalDirection.SE);
            var diagonalsSW = ComputeDiagonals(filePath, numberOfLines, numberOfChars, searchWord, DiagonalDirection.SW);
            var diagonalsNW = ComputeDiagonals(filePath, numberOfLines, numberOfChars, searchWord, DiagonalDirection.NW);

            var total = horizontalsLeftToRight + horizontalsRightToLeft +
                verticalsUpToDown + verticalsDownToUp +
                diagonalsNE + diagonalsSE + diagonalsSW + diagonalsNW;

            return total;
        }

        private static int ComputeHorizontals(string filePath, string searchWord, RowDirection direction)
        {
            // If we look for the word from right to left, we can just reverse it and search for it this way.
            if (direction == RowDirection.RightToLeft)
            {
                searchWord = searchWord.Reverse();
            }

            var counter = 0;
            foreach (var line in File.ReadLines(filePath))
            {
                counter += Regex.Matches(line, searchWord).Count;
            }

            return counter;
        }

        private static int ComputeVerticals(string filePath, int numberOfLines, int numberOfChars, string searchWord, ColumnDirection direction)
        {
            var counter = 0;
            var lines = new List<string>() { "", "", "", "" };
            var enumerator = File.ReadLines(filePath).GetEnumerator();

            // Save first 4 lines.
            for (var currentLine = 0; currentLine < 4; currentLine++)
            {
                enumerator.MoveNext();
                lines[currentLine] = enumerator.Current;
            }

            // Search for the word in the columns of the first lines.
            counter += CountWordInColumns(lines, numberOfChars, searchWord, direction);

            // Search for the word in columns from up to down.
            for (var currentLine = 4; currentLine < numberOfLines; currentLine++)
            {
                // Update the lines for the next iteration.
                enumerator.MoveNext();
                lines[0] = lines[1];
                lines[1] = lines[2];
                lines[2] = lines[3];
                lines[3] = enumerator.Current;

                // Search for the word in all the columns of the current lines.
                counter += CountWordInColumns(lines, numberOfChars, searchWord, direction);
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
        private static int CountWordInColumns(List<string> lines, int numberOfChars, string searchWord, ColumnDirection direction)
        {
            var counter = 0;
            for (var i = 0; i < numberOfChars; i++)
            {
                var str = "";
                switch (direction)
                {
                    case ColumnDirection.UpToDown:
                        str = $"{lines[0][i]}{lines[1][i]}{lines[2][i]}{lines[3][i]}";
                        break;
                    case ColumnDirection.DownToUp:
                        str = $"{lines[3][i]}{lines[2][i]}{lines[1][i]}{lines[0][i]}";
                        break;
                }

                if (str == searchWord)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int ComputeDiagonals(string filePath, int numberOfLines, int numberOfChars, string searchWord, DiagonalDirection direction)
        {
            var counter = 0;
            var lines = new List<string>() { "", "", "", "" };
            var enumerator = File.ReadLines(filePath).GetEnumerator();

            // Save first 4 lines.
            for (var currentLine = 0; currentLine < 4; currentLine++)
            {
                enumerator.MoveNext();
                lines[currentLine] = enumerator.Current;
            }

            // Search for the word in the diagonals NE of the first lines.
            counter += CountWordInDiagonals(lines, numberOfChars, searchWord, direction);

            // Search for the word in diagonals NE.
            for (var currentLine = 4; currentLine < numberOfLines; currentLine++)
            {
                // Update the lines for the next iteration.
                enumerator.MoveNext();
                lines[0] = lines[1];
                lines[1] = lines[2];
                lines[2] = lines[3];
                lines[3] = enumerator.Current;

                // Search for the word in all the diagonals NE of the current lines.
                counter += CountWordInDiagonals(lines, numberOfChars, searchWord, direction);
            }

            return counter;
        }

        private static int CountWordInDiagonals(List<string> lines, int numberOfChars, string searchWord, DiagonalDirection direction)
        {
            var indexStart = 0;
            var indexEnd = 0;
            if (direction == DiagonalDirection.SE || direction == DiagonalDirection.NE)
            {
                indexStart = 0;
                indexEnd = numberOfChars - 3;
            }
            else if (direction == DiagonalDirection.SW || direction == DiagonalDirection.NW)
            {
                indexStart = 3;
                indexEnd = numberOfChars;
            }

            var counter = 0;
            for (var i = indexStart; i < indexEnd; i++)
            {
                var str = "";
                switch (direction)
                {
                    case DiagonalDirection.SE:
                        str = $"{lines[0][i]}{lines[1][i + 1]}{lines[2][i + 2]}{lines[3][i + 3]}";
                        break;
                    case DiagonalDirection.NE:
                        str = $"{lines[3][i]}{lines[2][i + 1]}{lines[1][i + 2]}{lines[0][i + 3]}";
                        break;
                    case DiagonalDirection.SW:
                        str = $"{lines[0][i]}{lines[1][i - 1]}{lines[2][i - 2]}{lines[3][i - 3]}";
                        break;
                    case DiagonalDirection.NW:
                        str = $"{lines[3][i]}{lines[2][i - 1]}{lines[1][i - 2]}{lines[0][i - 3]}";
                        break;
                }

                if (str == searchWord)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
