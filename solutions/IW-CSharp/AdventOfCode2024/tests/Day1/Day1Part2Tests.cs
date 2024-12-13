using NUnit.Framework;

namespace AdventOfCode2024
{
    public class Day1Part2Tests
    {
        [Test]
        public void FullInputTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-01/input.txt";
            var result = Day1Part2.Day1Part2Main(filePath);
            Assert.That(result, Is.EqualTo(19678534));
        }
    }
}
