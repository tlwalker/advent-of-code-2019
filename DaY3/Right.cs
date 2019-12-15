using System.Collections.Generic;

namespace DaY3
{
    public class Right : IPathDirection
    {
        public Right(int magnitude)
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
                location = new Location(location.X + 1, location.Y);
                locations.Add(location);
            }

            return locations;
        }
    }
}