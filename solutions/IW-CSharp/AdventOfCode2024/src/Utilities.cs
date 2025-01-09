namespace AdventOfCode2024
{
    public static class Utilities
    {
        /// <summary>
        /// Given a text, this method returns that text reverted.<br></br>
        /// For example, given "abc", this method will return "cba".
        /// </summary>
        public static string Reverse(this string textToReverse)
        {
            var tmp = textToReverse.ToCharArray();
            Array.Reverse(tmp);
            return new string(tmp);
        }
    }
}
