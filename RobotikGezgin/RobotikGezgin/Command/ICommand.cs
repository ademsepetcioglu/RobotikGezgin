namespace RobotikGezgin.Command
{
    public interface ICommand
    {
        CommandType GetCommandType();
        void Execute();
    }
}