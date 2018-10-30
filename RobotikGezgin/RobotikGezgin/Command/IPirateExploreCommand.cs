using RobotikGezgin.Pirate;
using System.Collections.Generic;

namespace RobotikGezgin.Command
{
    public interface IPirateExploreCommand : ICommand
    {
        IList<Direction> _direction { get; }
        void SetReceiver(IPirate _pirate);
    }
}
