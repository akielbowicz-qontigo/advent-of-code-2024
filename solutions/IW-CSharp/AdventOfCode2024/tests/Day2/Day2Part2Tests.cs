using NUnit.Framework;

namespace AdventOfCode2024
{
    public class Day2Part2Tests
    {
        [Test]
        public void FullInputTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-02/input.txt";
            var result = Day2Part2.Day2Part2Main(filePath);
            Assert.That(result, Is.EqualTo(626));
        }
    }
}
