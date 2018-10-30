using RobotikGezgin.Surface;


namespace RobotikGezgin
{
    public interface ICommandCenter
    {
        void Execute(string commandString);
        ISurface GetSurface();
        string GetCombinedRoverReport();
    }
}