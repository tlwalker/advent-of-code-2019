using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DaY3
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var wires = File.ReadLines("input.txt").Select(s => s.Split(",")).ToArray();

            var distance = await Part1(wires[0], wires[1]);
            var steps = await Part2(wires[0], wires[1]);
            Console.WriteLine($"Part 1: Shortest Distance = {distance}");
            Console.WriteLine($"Part 2: Minimal Steps to InterSect = {steps}");
        }

        private static Task<Wire> SetupWire(string[] wireInputs)
        {

            return Task.Run(() =>
            {
                var wire = new Wire();
                var directions = wireInputs.Select(ParseDirection);
                wire.Follows(directions);
                return wire;
            });

        }
        
        public static async Task<int> Part1(string[] wire1Inputs, string[] wire2Inputs)
        {
            
            var wire1 = await SetupWire(wire1Inputs);
            var wire2 = await SetupWire(wire2Inputs);
            
            var locations = wire1.Intersects(wire2);
            return locations.Min(l => l.Distance());
        }

        public static async Task<int> Part2(string[] wire1Inputs, string[] wire2Inputs)
        {
            var wire1 = await SetupWire(wire1Inputs);
            var wire2 = await SetupWire(wire2Inputs);

            return wire1.GetMinimalStepsToIntersect(wire2);
        }

        public static IPathDirection ParseDirection(string input)
        {
            (string, int) GetDirection(string d)
            {
                var m = int.Parse(d.Substring(1));
                return (d.Substring(0,1), m);
            }

            (string dir, int mag) = GetDirection(input);
            return dir switch
            {
                "R" => new Right(mag),
                "L" => new Left(mag),
                "U" => new Up(mag),
                "D" => new Down(mag),
                _ => throw new InvalidOperationException("Unknown direction given")
            };
        }
    }
}
