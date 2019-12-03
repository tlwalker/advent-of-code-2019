using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            Part1(filename);
            Part2(filename);
        }

        static void Part1(string filename)
        {
            var modules = GetModules(filename);
            var totalFuel = modules.Sum(m => m.FuelRequirement);
            Console.WriteLine($"Total Fuel Required: {totalFuel}");
        }

        static void Part2(string filename)
        {
            var modules = GetModules(filename);
            var fuelUnits = GetFuelUnits(modules);

            var fuelPerModule = modules.Zip(fuelUnits, (m, f) => m.FuelRequirement + f.FuelRequirement);
            var totalFuel = fuelPerModule.Sum();
            Console.WriteLine($"Total Fuel Required: {totalFuel}");
        }

        static List<IMass> GetModules(string filename)
        {
            var data = File.ReadLines(filename);
            return data.Select(x => int.TryParse(x, out int mass) && mass >= 9 ? (IMass) new Module(mass) : new FuellessMass())
                .ToList();
        }

        static List<IMass> GetFuelUnits(List<IMass> modules)
        {
            return modules.Select(m => new FuelUnits(m.FuelRequirement) as IMass).ToList();
        }
    }
}
