using NUnit.Framework;

namespace AdventOfCode2024
{
    public class Day1Part1Tests
    {
        [Test]
        public void SmallSampleTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-01/input-part1-sample.txt";
            var result = Day1Part1.Day1Part1Main(filePath);
            Assert.That(result, Is.EqualTo(11));
        }

        [Test]
        public void FullInputTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-01/input-part1-full.txt";
            var result = Day1Part1.Day1Part1Main(filePath);
            Assert.That(result, Is.EqualTo(2031679));
        }
    }
}
