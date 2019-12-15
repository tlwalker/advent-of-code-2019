using System.Collections.Generic;

namespace DaY3
{
    public interface IPathDirection
    {
        List<Location> Walk(Location fromLocation);
    }
}