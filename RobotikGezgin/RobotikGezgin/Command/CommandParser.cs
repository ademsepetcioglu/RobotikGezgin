using RobotikGezgin.Pirate;
using RobotikGezgin.Surface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotikGezgin.Command
{
    public class CommandParser : ICommandParser
    {
        private readonly Func<Size, ISurfaceSizeCommand> _surfaceSizeCommandFactory;
        private readonly Func<Point, Coordinate, IPirateDeployCommand> _pirateDeployCommandFactory;
        private readonly Func<IList<Direction>, IPirateExploreCommand> _pirateExploreCommandFactory;

        private readonly ICommandMatcher _commandMatcher;
        private readonly IDictionary<CommandType, Func<string, ICommand>> commandParserDictionary;
        private readonly IDictionary<char, Coordinate> coordinate;
        private readonly IDictionary<char, Direction> direction;

        public CommandParser(ICommandMatcher commandMatcher,
            Func<Size, ISurfaceSizeCommand> surfaceSizeCommandFactory,
            Func<Point, Coordinate, IPirateDeployCommand> pirateDeployCommandFactory,
            Func<IList<Direction>, IPirateExploreCommand> pirateExploreCommandFactory)
        {
            _commandMatcher = commandMatcher;
            _surfaceSizeCommandFactory = surfaceSizeCommandFactory;
            _pirateDeployCommandFactory = pirateDeployCommandFactory;
            _pirateExploreCommandFactory = pirateExploreCommandFactory;

            commandParserDictionary = new Dictionary<CommandType, Func<string, ICommand>>
            {
                 {CommandType.SurfaceSizeCommand, ParseSurfaceSizeCommand},
                 {CommandType.PirateDeployCommand, ParsePirateDeployCommand},
                 {CommandType.PirateExploreCommand, ParseRoverExploreCommand}
            };

            coordinate = new Dictionary<char, Coordinate>
            {
                 {'N', Coordinate.North},
                 {'S', Coordinate.South},
                 {'E', Coordinate.East},
                 {'W', Coordinate.West}
            };

            direction = new Dictionary<char, Direction>
            {
                 {'L', Direction.Left},
                 {'R', Direction.Right},
                 {'M', Direction.Forward}
            };
        }
        public IEnumerable<ICommand> Parse(string commandString)
        {
            var commands = commandString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return commands.Select(
                command => commandParserDictionary[_commandMatcher.GetCommandType(command)]
                    .Invoke(command)).ToList();
        }

        private ICommand ParseSurfaceSizeCommand(string toParse)
        {
            var arguments = toParse.Split(' ');
            var width = int.Parse(arguments[0]);
            var height = int.Parse(arguments[1]);
            var size = new Size(width, height);

            var populatedCommand = _surfaceSizeCommandFactory(size);
            return populatedCommand;
        }

        private ICommand ParsePirateDeployCommand(string toParse)
        {
            var arguments = toParse.Split(' ');

            var deployX = int.Parse(arguments[0]);
            var deployY = int.Parse(arguments[1]);

            var directionSignifier = arguments[2][0];
            var deployDirection = coordinate[directionSignifier];

            var deployPoint = new Point(deployX, deployY);

            var populatedCommand = _pirateDeployCommandFactory(deployPoint, deployDirection);
            return populatedCommand;
        }

        private ICommand ParseRoverExploreCommand(string toParse)
        {
            var arguments = toParse.ToCharArray();
            var movements = arguments.Select(argument => direction[argument]).ToList();
            var populatedCommand = _pirateExploreCommandFactory(movements);
            return populatedCommand;
        }
    }
}
