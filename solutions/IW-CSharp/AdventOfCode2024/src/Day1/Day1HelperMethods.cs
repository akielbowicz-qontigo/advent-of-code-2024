namespace AdventOfCode2024
{
    public static class Day1HelperMethods
    {
        /// <summary>
        /// Given a line with two numbers separated by at least one space (or any non-digit character), this method returns the number in the left.<br></br>
        /// For example, given the line "123 456", this method will return 123.
        /// </summary>
        public static int GetLeftNumberFromLine(string line)
        {
            string number = "";
            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else
                {
                    return int.Parse(number);
                }
            }

            throw new Exception("There was no separator in the line.");
        }

        /// <summary>
        /// Given a line with two numbers separated by at least one space (or any non-digit character), this method returns the number in the right.<br></br>
        /// For example, given the line "123 456", this method will return 456.
        /// </summary>
        public static int GetRightNumberFromLine(string line)
        {
            var reversedLine = line.Reverse();
            string reversedNumber = "";
            foreach (char c in reversedLine)
            {
                if (char.IsDigit(c))
                {
                    reversedNumber += c;
                }
                else
                {
                    var number = reversedNumber.Reverse();
                    return int.Parse(number);
                }
            }

            throw new Exception("There was no separator in the line.");
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
