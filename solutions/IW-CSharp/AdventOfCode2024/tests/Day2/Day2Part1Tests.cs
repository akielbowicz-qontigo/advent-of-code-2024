using NUnit.Framework;

namespace AdventOfCode2024
{
    public class Day2Part1Tests
    {
        [Test]
        public void FullInputTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-02/input.txt";
            var result = Day2Part1.Day2Part1Main(filePath);
            Assert.That(result, Is.EqualTo(585));
        }
    }
}
