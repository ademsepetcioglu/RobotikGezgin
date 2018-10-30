using System.Collections.Generic;

namespace RobotikGezgin.Command
{
    public interface ICommandParser
    {
        IEnumerable<ICommand> Parse(string commandString);
    }
}