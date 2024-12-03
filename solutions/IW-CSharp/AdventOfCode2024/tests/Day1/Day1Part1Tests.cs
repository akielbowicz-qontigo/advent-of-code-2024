using NUnit.Framework;

namespace AdventOfCode2024
{
    public class Day1Part1Tests
    {
        [Test]
        public void FullInputTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-01/input.txt";
            var result = Day1Part1.Day1Part1Main(filePath);
            Assert.That(result, Is.EqualTo(2031679));
        }
    }
}
