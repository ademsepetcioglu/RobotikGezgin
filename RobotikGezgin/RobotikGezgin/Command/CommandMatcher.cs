using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace RobotikGezgin.Command
{
    public class CommandMatcher : ICommandMatcher
    {
        private IDictionary<string, CommandType> _commandType;
        public CommandMatcher()
        {
            InitializeCommandTypeDictionary();
        }
        public CommandType GetCommandType(string command)
        {
            try
            {
                var commandType = _commandType.First(
                    regexToCommandType => new Regex(regexToCommandType.Key).IsMatch(command));

                return commandType.Value;
            }
            catch (InvalidOperationException e)
            {
                var exceptionMessage = String.Format("Geçerli konumda değildir '{0}'", command);
                throw new CommandException(exceptionMessage, e);
            }
        }

        private void InitializeCommandTypeDictionary()
        {
            _commandType = new Dictionary<string, CommandType>
            {
                { @"^\d+ \d+$", CommandType.SurfaceSizeCommand },
                { @"^\d+ \d+ [NSEW]$", CommandType.PirateDeployCommand },
                { @"^[LRM]+$", CommandType.PirateExploreCommand }
            };
        }
    }
}
