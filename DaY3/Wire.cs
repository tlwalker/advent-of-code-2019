using System.Collections.Generic;
using System.Linq;

namespace DaY3
{
    public class Wire
    {
        private readonly List<Location> _locations = new List<Location>();

        public List<Location> Intersects(Wire other) => _locations.Intersect(other._locations).ToList();

        public int GetMinimalStepsToIntersect(Wire other)
        {
            var intersections = Intersects(other);
            
            return intersections.Min(i => GetStepsToPoint(i) + other.GetStepsToPoint(i));

        }

        private int GetStepsToPoint(Location point) => _locations.FindIndex(l => l == point) + 1;
        
        public void Follows(IEnumerable<IPathDirection> pathDirections)
        {
            var lastLocation = !_locations.Any() ? new Location( 0, 0) : _locations.Last();
            foreach (var direction in pathDirections)
            {
                _locations.AddRange(direction.Walk(lastLocation));
                lastLocation = _locations.Last();
            }
        }
    }
}