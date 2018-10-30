using RobotikGezgin.Surface;

namespace RobotikGezgin.Command
{
    public interface ISurfaceSizeCommand : ICommand
    {
        Size size { get; }
        void SetReceiver(ISurface _surface);
    }
}
