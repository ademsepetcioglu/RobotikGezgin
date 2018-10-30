using RobotikGezgin.Pirate;
using RobotikGezgin.Surface;
using System.Collections.Generic;


namespace RobotikGezgin.Command
{
   public interface ICommandInvoker
    {
        void SetSurface(ISurface _surface);
        void SetPirate(IList<IPirate> _somepirate);
        void Assign(IEnumerable<ICommand> _commandList);
        void InvokeAll();
    }
}
