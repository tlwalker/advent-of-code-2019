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
            return data.Select(x => int.TryParse(x, out int mass) && mass > 9 ? (IMass) new Module(mass) : new FuellessMass())
                .ToList();
        }

        static List<IMass> GetFuelUnits(List<IMass> modules)
        {
            return modules.Select(m => new FuelUnits(m.FuelRequirement) as IMass).ToList();
        }
    }

    public interface IMass
    {
        int FuelRequirement { get; }
    }

    public class FuellessMass : IMass
    {
        public int FuelRequirement => 0;
    }

    public class Module : IMass
    {
        public int FuelRequirement =>  _mass / 3 - 2;

        private readonly int _mass;

        public Module(int mass = 0)
        {
            _mass = mass;
        }
    }

    public class FuelUnits : IMass
    {
        public int FuelRequirement
        {
            get
            {
                var mass = _mass / 3 - 2;
                var fuel = 0;

                while (mass >= 0)
                {
                    fuel += mass;
                    mass = mass / 3 - 2;
                }

                return fuel;
            }
        }

        private readonly int _mass;

        public FuelUnits(int mass)
        {
            _mass = mass;
        }
    }
}
