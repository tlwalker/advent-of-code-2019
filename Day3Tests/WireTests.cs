using DaY3;
using NUnit.Framework;

namespace Day3Tests
{
    public class WireTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WiresShouldReturnIntersections()
        {
            var wire1Directions = new IPathDirection[] {new Right(8), new Up(5), new Left(5), new Down(3)};
            var wire2Directions = new IPathDirection[] {new Up(7), new Right(6), new Down(4), new Left(4)};
            var wire1 = new Wire();
            wire1.Follows(wire1Directions);
            var wire2 = new Wire();
            wire2.Follows(wire2Directions);
            var intersections = wire1.Intersects(wire2);
            Assert.That(intersections, Has.Count.EqualTo(2));
        }
    }
}