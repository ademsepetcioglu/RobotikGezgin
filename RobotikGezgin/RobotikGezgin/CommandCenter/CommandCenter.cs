using RobotikGezgin.Command;
using RobotikGezgin.Pirate;
using RobotikGezgin.Report;
using RobotikGezgin.Surface;
using System.Collections.Generic;

namespace RobotikGezgin
{
    public class CommandCenter : ICommandCenter
    {
        private readonly ISurface surface;
        private readonly ICommandParser commandParser;
        private readonly ICommandInvoker commandInvoker;
        private readonly IReportComposer reportComposer;

        private readonly IList<IPirate> pirate;

        public CommandCenter(ISurface _surface, ICommandParser _commandparser, ICommandInvoker _commandInvoker, IReportComposer _reportComposer)
        {
            pirate = new List<IPirate>();
            surface = _surface;
            commandParser = _commandparser;
            commandInvoker = _commandInvoker;
            reportComposer = _reportComposer;
            commandInvoker.SetSurface(surface);
            commandInvoker.SetPirate(pirate);
        }
        public void Execute(string commandString)
        {
            var commandList = commandParser.Parse(commandString);
            commandInvoker.Assign(commandList);
            commandInvoker.InvokeAll();
        }

        public ISurface GetSurface()
        {
            return surface;
        }

        public string GetCombinedRoverReport()
        {
            return reportComposer.CompileReports(pirate);
        }
    }
}
