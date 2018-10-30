using RobotikGezgin.Pirate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotikGezgin.Command
{
    public class PirateExploreCommand: IPirateExploreCommand
    {
        public IList<Direction> _direction { get; private set; }
        private IPirate pirate;

        public PirateExploreCommand(IList<Direction> _directions)
        {
            _direction = _directions;
        }

        public CommandType GetCommandType()
        {
            return CommandType.PirateExploreCommand;
        }

        public void Execute()
        {
            pirate.Move(_direction);
        }

        public void SetReceiver(IPirate _pirate)
        {
            pirate = _pirate;
        }
    }
}
