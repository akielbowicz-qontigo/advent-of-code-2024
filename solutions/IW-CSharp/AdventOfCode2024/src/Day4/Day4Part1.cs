using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public static class Day4Part1
    {
        public static double Day4Part1Main(string filePath)
        {
            var searchWord = "XMAS";  // Note: This implementation will work for any word with 4 characters.

            var numberOfLines = File.ReadLines(filePath).Count();
            var numberOfChars = File.ReadLines(filePath).First().Length;  // All lines have the same length, we can use the first one.

            var horizontalsLeftToRight = ComputeHorizontalsLeftToRight(filePath, searchWord);
            var horizontalsRightToLeft = ComputeHorizontalsRightToLeft(filePath, searchWord);

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

        private static int ComputeHorizontalsLeftToRight(string filePath, string searchWord)
        {
            var horizontalsLeftToRight = 0;
            foreach (var line in File.ReadLines(filePath))
            {
                horizontalsLeftToRight += HorizontalsLeftToRight(line, searchWord);
            }
            return horizontalsLeftToRight;
        }

        private static int HorizontalsLeftToRight(string line, string searchWord)
        {
            var totalMatches = Regex.Matches(line, searchWord).Count;
            return totalMatches;
        }

        private static int ComputeHorizontalsRightToLeft(string filePath, string searchWord)
        {
            var horizontalsRightToLeft = 0;
            foreach (var line in File.ReadLines(filePath))
            {
                horizontalsRightToLeft += HorizontalsRightToLeft(line, searchWord);
            }
            return horizontalsRightToLeft;
        }

        private static int HorizontalsRightToLeft(string line, string searchWord)
        {
            var reversedLine = line.Reverse();
            var totalMatches = HorizontalsLeftToRight(reversedLine, searchWord);
            return totalMatches;
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
            switch (direction)
            {
                case DiagonalDirection.NE:
                case DiagonalDirection.SE:
                    counter = ComputeDiagonalsE(filePath, numberOfLines, numberOfChars, searchWord, direction);
                    break;
                case DiagonalDirection.NW:
                case DiagonalDirection.SW:
                    counter = ComputeDiagonalsW(filePath, numberOfLines, numberOfChars, searchWord, direction);
                    break;
            }

            return counter;
        }

        private static int ComputeDiagonalsE(string filePath, int numberOfLines, int numberOfChars, string searchWord, DiagonalDirection direction)
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
            counter += CountWordInDiagonalsE(lines, numberOfChars, searchWord, direction);

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
                counter += CountWordInDiagonalsE(lines, numberOfChars, searchWord, direction);
            }

            return counter;
        }

        private static int CountWordInDiagonalsE(List<string> lines, int numberOfChars, string searchWord, DiagonalDirection direction)
        {
            var counter = 0;
            for (var i = 0; i < numberOfChars - 3; i++)
            {
                var str = "";
                switch (direction)
                {
                    case DiagonalDirection.NE:
                        str = $"{lines[3][i]}{lines[2][i + 1]}{lines[1][i + 2]}{lines[0][i + 3]}";
                        break;
                    case DiagonalDirection.SE:
                        str = $"{lines[0][i]}{lines[1][i + 1]}{lines[2][i + 2]}{lines[3][i + 3]}";
                        break;
                }

                if (str == searchWord)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int ComputeDiagonalsW(string filePath, int numberOfLines, int numberOfChars, string searchWord, DiagonalDirection direction)
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
            counter += CountWordInDiagonalsW(lines, numberOfChars, searchWord, direction);

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
                counter += CountWordInDiagonalsW(lines, numberOfChars, searchWord, direction);
            }

            return counter;
        }

        private static int CountWordInDiagonalsW(List<string> lines, int numberOfChars, string searchWord, DiagonalDirection direction)
        {
            var counter = 0;
            for (var i = 3; i < numberOfChars; i++)
            {
                var str = "";
                switch (direction)
                {
                    case DiagonalDirection.NW:
                        str = $"{lines[3][i]}{lines[2][i - 1]}{lines[1][i - 2]}{lines[0][i - 3]}";
                        break;
                    case DiagonalDirection.SW:
                        str = $"{lines[0][i]}{lines[1][i - 1]}{lines[2][i - 2]}{lines[3][i - 3]}";
                        break;
                }

                if (str == searchWord)
                {
                    counter++;
                }
            }

            return counter;
        }

        private enum ColumnDirection
        {
            UpToDown,
            DownToUp
        }

        private enum DiagonalDirection
        {
            NE,
            SE,
            SW,
            NW
        }

        /// <summary>
        /// Given a text, this method returns that text reverted.<br></br>
        /// For example, given "abc", this method will return "cba".
        /// </summary>
        private static string Reverse(this string textToReverse)
        {
            var tmp = textToReverse.ToCharArray();
            Array.Reverse(tmp);
            return new string(tmp);
        }
    }
}
