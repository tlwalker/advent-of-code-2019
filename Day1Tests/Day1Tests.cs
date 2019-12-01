using NUnit.Framework;
using Day1;
namespace Day1Tests
{
    public class ModuleTests
    {
       
        [Test]
        [TestCase(12, 2)]
        [TestCase(14, 2)]
        [TestCase(1969, 654)]
        [TestCase(100756, 33583)]
        public void ModuleShouldCalculateFuelRequirements(int mass, int expectedFuelRequirements)
        {
            var m = new Module(mass);
            Assert.That(m.FuelRequirement, Is.EqualTo(expectedFuelRequirements));
        }
    }

    public class FuelUnitsTests
    {
        [Test]
        [TestCase(2, 0)]
        [TestCase(654, 312)]
        [TestCase(33583, 16763)]
        public void FuelUnitsShouldGetFuelRequirements(int mass, int expectedFuelRequirements)
        {
            var f = new FuelUnits(mass);
            Assert.That(f.FuelRequirement, Is.EqualTo(expectedFuelRequirements));
        }
    }
}