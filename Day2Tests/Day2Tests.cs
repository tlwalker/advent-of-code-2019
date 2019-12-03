using System.Linq;
using Day2;
using NUnit.Framework;

namespace Day2Tests
{
    public class IntCodeInterpreterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new[]{1,0,0,3,99}, new[]{1,0,0,2,99})]
        [TestCase(new[]{ 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 }, new[]{ 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50})]
        [TestCase(new[]{ 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[]{ 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void InterpreterCanProduceProperOutput(int[] input, int[] expected)
        {
            var interpreter = new IntCodeInterpreter(input.Select(x => x.ToString()).ToArray());
            interpreter.Run();
            Assert.That(interpreter.Output.Select(int.Parse).ToArray(), Is.EquivalentTo(expected));
        }
    }
}