using NUnit.Framework;

namespace AdventOfCode2024
{
    public class Day4Part1Tests
    {
        [Test]
        public void FullInputTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-04/input.txt";
            var result = Day4Part1.Day4Part1Main(filePath);
            Assert.That(result, Is.EqualTo(2662));
        }

        [Test]
        public void FullInputSimplerTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-04/input.txt";
            var result = Day4Part1Simpler.Day4Part1Main(filePath);
            Assert.That(result, Is.EqualTo(2662));
        }
    }
}
