using NUnit.Framework;

namespace AdventOfCode2024
{
    public class Day1Part2Tests
    {
        [Test]
        public void SmallSampleTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-01/input-part1-sample.txt";
            var result = Day1Part2.Day1Part2Main(filePath);
            Assert.That(result, Is.EqualTo(31));
        }

        [Test]
        public void FullInputTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-01/input-part1-full.txt";
            var result = Day1Part2.Day1Part2Main(filePath);
            Assert.That(result, Is.EqualTo(19678534));
        }
    }
}
