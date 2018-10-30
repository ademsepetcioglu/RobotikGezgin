namespace RobotikGezgin.Surface
{
    public class Space : ISurface
    {
        private Size size { get; set; }

        public void SetSize(Size _size)
        {
            size = _size;
        }

        public Size GetSize()
        {
            return size;
        }

        public bool IsValid(Point _point)
        {
            var isValidX = _point.X >= 0 && _point.X <= size.Width;
            var isValidY = _point.Y >= 0 && _point.Y <= size.Height;
            return isValidX && isValidY;
        }
    }
}