using System.Collections.Generic;
using RobotikGezgin.Surface;

namespace RobotikGezgin.Pirate
{
    public interface IPirate
    {
        Point _point { get; set; }
        Coordinate _coordinate { get; set; }
        void Deploy(ISurface _surface, Point _point, Coordinate _coordinate);
        void Move(IEnumerable<Direction> directions);
        bool IsDeployed();
    }
}