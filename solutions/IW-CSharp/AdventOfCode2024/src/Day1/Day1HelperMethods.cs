namespace AdventOfCode2024
{
    public static class Day1HelperMethods
    {
        /// <summary>
        /// Given a set of lines with two numbers separated by at least one space, this method returns all the left numbers 
        /// in a list and all the right numbers in another list.<br></br>
        /// For example, given the two lines "11 22" and "33 44", this method will return a list containing 11 and 33, and another 
        /// list containing 22 and 44.
        /// </summary>
        public static (List<int>, List<int>) SaveInputInLists(string filePath)
        {
            var leftList = new List<int>();
            var rightList = new List<int>();
            foreach (string line in File.ReadLines(filePath))
            {
                var leftNumber = GetLeftNumberFromLine(line);
                leftList.Add(leftNumber);

                var rightNumber = GetRightNumberFromLine(line);
                rightList.Add(rightNumber);
            }

            return (leftList, rightList);
        }

        /// <summary>
        /// Given a line with two numbers separated by at least one space (or any non-digit character), this method returns the number in the left.<br></br>
        /// For example, given the line "123 456", this method will return 123.
        /// </summary>
        private static int GetLeftNumberFromLine(string line)
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
        private static int GetRightNumberFromLine(string line)
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
    }
}
