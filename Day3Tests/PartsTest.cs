using System.IO.MemoryMappedFiles;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace Day3Tests
{
    public class PartsTest
    {
        [Test]
        [TestCase(new[] {"R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72"},
            new[] {"U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83"}, 159)]
        [TestCase(new[]{ "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" }, new[]{ "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" }, 135)]
        public async Task Part1ShouldReturnShortestDistanceFromCenter(string[] wire1Directions, string[] wire2Directions, int expectedShortestDistance)
        {
            var actual = await DaY3.Program.Part1(wire1Directions, wire2Directions);
            Assert.That(actual, Is.EqualTo(expectedShortestDistance));
        }


        [Test]
        [TestCase(new[] { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" },
            new[] { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" }, 610)]
        [TestCase(new[] { "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" }, new[] { "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" }, 410)]
        public async Task Part2ShouldReturnMinimalSteps(string[] wire1Directions, string[] wire2Directions, int expectedMinimalSteps)
        {
            var actual = await DaY3.Program.Part2(wire1Directions, wire2Directions);
            Assert.That(actual, Is.EqualTo(expectedMinimalSteps));
        }
    }
}