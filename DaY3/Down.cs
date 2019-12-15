using System.Collections.Generic;

namespace DaY3
{
    public class Down : IPathDirection
    {
        public Down(int magnitude)
        {
            _magnitude = magnitude;
        }

        private readonly int _magnitude;

        public List<Location> Walk(Location fromLocation)
        {
            var locations = new List<Location>();
            var location = fromLocation;
            
            for (int i = 0; i < _magnitude; i++)
            {
                location = new Location(location.X, location.Y - 1);
                locations.Add(location);
            }

            return locations;
        }
    }
}