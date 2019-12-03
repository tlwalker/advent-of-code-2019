namespace Day1
{
    public class Module : IMass
    {
        public int FuelRequirement =>  _mass / 3 - 2;

        private readonly int _mass;

        public Module(int mass = 0)
        {
            _mass = mass;
        }
    }
}