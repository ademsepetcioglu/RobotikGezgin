using RobotikGezgin.Surface;

namespace RobotikGezgin.Command
{
    public class SurfaceSizeCommand :ISurfaceSizeCommand
    {
        public Size size { get; private set; }
        private ISurface Surface;

        public SurfaceSizeCommand(Size _size)
        {
            size = _size;
        }

        public CommandType GetCommandType()
        {
            return CommandType.SurfaceSizeCommand;
        }

        public void Execute()
        {
            Surface.SetSize(size);
        }

        public void SetReceiver(ISurface _surface)
        {
           Surface = _surface;
        }
    }
}
