using RobotikGezgin.Pirate;
using RobotikGezgin.Surface;
using System;
using System.Collections.Generic;


namespace RobotikGezgin.Command
{
    public class CommandInvoker : ICommandInvoker
    {
        private readonly Func<IPirate> Pirate;
        private readonly IDictionary<CommandType, Action<ICommand>> setReceiversMethodDictionary;

        private ISurface _surface;
        private IList<IPirate> _pirate;
        private IEnumerable<ICommand> _commandList;

        public CommandInvoker(Func<IPirate> pirate)
        {
            Pirate = pirate;

            setReceiversMethodDictionary = new Dictionary<CommandType, Action<ICommand>>
            {
                {CommandType.SurfaceSizeCommand, SetReceiversOnSurfaceSizeCommand},
                {CommandType.PirateDeployCommand, SetReceiversOnPirateDeployCommand},
                {CommandType.PirateExploreCommand, SetReceiversOnPirateExploreCommand}
            };
        }
        public void SetSurface(ISurface surface)
        {
            _surface = surface;
        }

        public void SetPirate(IList<IPirate> _somepirate)
        {
            _pirate = _somepirate;
        }

        public void Assign(IEnumerable<ICommand> CommandList)
        {
            _commandList = CommandList;
        }

        public void InvokeAll()
        {
            foreach (var command in _commandList)
            {
                setReceivers(command);
                command.Execute();
            }
        }
        private void setReceivers(ICommand command)
        {
            setReceiversMethodDictionary[command.GetCommandType()]
                .Invoke(command);
        }

        private void SetReceiversOnSurfaceSizeCommand(ICommand command)
        {
            var SurfaceSizeCommand = (ISurfaceSizeCommand)command;
            SurfaceSizeCommand.SetReceiver(_surface);
        }

        private void SetReceiversOnPirateDeployCommand(ICommand command)
        {
            var pirateDeployCommand = (IPirateDeployCommand)command;
            var newPirate = Pirate();
            _pirate.Add(newPirate);
            pirateDeployCommand.SetReceivers(newPirate, _surface);
        }

        private void SetReceiversOnPirateExploreCommand(ICommand command)
        {
            var pirateExploreCommand = (IPirateExploreCommand)command;
            var latestPirate = _pirate[_pirate.Count - 1];
            pirateExploreCommand.SetReceiver(latestPirate);
        }
    }
}
