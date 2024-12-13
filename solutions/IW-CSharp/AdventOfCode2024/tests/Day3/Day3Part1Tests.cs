using NUnit.Framework;

namespace AdventOfCode2024
{
    public class Day3Part1Tests
    {
        [Test]
        public void FullInputTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-03/input.txt";
            var result = Day3Part1.Day3Part1Main(filePath);
            Assert.That(result, Is.EqualTo(2031679));
        }
    }
}
