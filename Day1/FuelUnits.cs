namespace Day1
{
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