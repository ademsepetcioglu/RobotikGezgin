namespace RobotikGezgin.Surface
{
    public interface ISurface
    {
        void SetSize(Size _size);
        Size GetSize();
        bool IsValid(Point aPoint);
    }
}