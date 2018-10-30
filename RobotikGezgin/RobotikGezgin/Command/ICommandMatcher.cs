namespace RobotikGezgin.Command
{
    public interface ICommandMatcher
    {
        CommandType GetCommandType(string command);
    }
}