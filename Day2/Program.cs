using System;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            IDayPart part1 = new Part1(filename);
            part1.Solve();
            Console.WriteLine($"Part 1 result: {part1.Result}");

            var part2 = new Part2(filename);
            part2.Solve();
            Console.WriteLine($"Part 2 result: {part2.Result}");
        }
    }
}
