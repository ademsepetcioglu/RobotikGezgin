using RobotikGezgin.Pirate;
using RobotikGezgin.Surface;

namespace RobotikGezgin.Command
{
    public interface IPirateDeployCommand : ICommand
    {
        Point _point { get; set; }
        Coordinate _coordinate { get; set; }
        void SetReceivers(IPirate _pirate, ISurface _surface);
    }
}
