using RobotikGezgin.Pirate;
using RobotikGezgin.Surface;


namespace RobotikGezgin.Command
{
    public class PirateDeployCommand : IPirateDeployCommand
    {
        public Point _point { get; set; }
        public Coordinate _coordinate { get; set; }
        private IPirate pirate;
        private ISurface Surface;

        public PirateDeployCommand(Point point, Coordinate coordinate)
        {
            _point = point;
            _coordinate = coordinate;
        }

        public CommandType GetCommandType()
        {
            return CommandType.PirateDeployCommand;
        }

        public void Execute()
        {
            pirate.Deploy(Surface, _point, _coordinate);
        }

        public void SetReceivers(IPirate _pirate, ISurface _Surface)
        {
            pirate = _pirate;
            Surface = _Surface;
        }
    }
}
