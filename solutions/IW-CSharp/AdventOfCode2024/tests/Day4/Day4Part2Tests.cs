using NUnit.Framework;

namespace AdventOfCode2024
{
    public class Day4Part2Tests
    {
        [Test]
        public void FullInputTest()
        {
            var filePath = "C:/Dev/AOC-2024/problems/day-04/input.txt";
            var result = Day4Part2.Day4Part2Main(filePath);
            Assert.That(result, Is.EqualTo(72948684));
        }
    }
}
