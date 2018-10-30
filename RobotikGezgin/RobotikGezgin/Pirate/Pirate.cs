using System;
using System.Collections.Generic;
using RobotikGezgin.Surface;

namespace RobotikGezgin.Pirate
{
    public class Pirate : IPirate
    {
        public Point _point { get; set; }
        public Coordinate _coordinate { get; set; }
        private bool isDeployed;
        private readonly IDictionary<Direction, Action> direction;
        private readonly IDictionary<Coordinate, Action> leftMoveCoordinate;
        private readonly IDictionary<Coordinate, Action> rightMoveCoordinate;
        private readonly IDictionary<Coordinate, Action> forwardMoveCoordinate;

        public Pirate()
        {
            direction = new Dictionary<Direction, Action>
            {
                {Direction.Left, () => leftMoveCoordinate[_coordinate].Invoke()},
                {Direction.Right, () => rightMoveCoordinate[_coordinate].Invoke()},
                {Direction.Forward, () => forwardMoveCoordinate[_coordinate].Invoke()}
            };

            leftMoveCoordinate = new Dictionary<Coordinate, Action>
            {
                {Coordinate.North, () => _coordinate = Coordinate.West},
                {Coordinate.East, () => _coordinate = Coordinate.North},
                {Coordinate.South, () => _coordinate = Coordinate.East},
                {Coordinate.West, () => _coordinate = Coordinate.South}
            };

            rightMoveCoordinate = new Dictionary<Coordinate, Action>
            {
                {Coordinate.North, () => _coordinate = Coordinate.East},
                {Coordinate.East, () => _coordinate = Coordinate.South},
                {Coordinate.South, () => _coordinate = Coordinate.West},
                {Coordinate.West, () => _coordinate = Coordinate.North}
            };

            forwardMoveCoordinate = new Dictionary<Coordinate, Action>
            {
                {Coordinate.North, () => {_point = new Point(_point.X, _point.Y + 1);}},
                {Coordinate.East, () => {_point = new Point(_point.X + 1, _point.Y);}},
                {Coordinate.South, () => {_point = new Point(_point.X, _point.Y - 1);}},
                {Coordinate.West, () => {_point = new Point(_point.X - 1, _point.Y);}}
            };
        }
        public void Deploy(ISurface surface, Point point, Coordinate coordinate)
        {
            if (surface.IsValid(_point))
            {
                _point = point;
                _coordinate = coordinate;
                isDeployed = true;
                return;
            }

            throwDeployException(surface, point);
        }

        public void Move(IEnumerable<Direction> movements)
        {
            foreach (var movement in movements)
            {
                direction[movement].Invoke();
            }
        }

        public bool IsDeployed()
        {
            return isDeployed;
        }

        private static void throwDeployException(ISurface _surface, Point _point)
        {
            var size = _surface.GetSize();
            var exceptionMessage = String.Format("Kordinatlar hatalı ({0},{1}). İniş konumu {2} x {3}.",
                _point.X, _point.Y, size.Width, size.Height);
            throw new PirateDeployException(exceptionMessage);
        }

    }
}
