using System.Collections.Generic;
using RobotikGezgin.Pirate;
using RobotikGezgin.Surface;

namespace RobotikGezgin.Report
{
    public interface IReportComposer
    {
        string Compose(Point _point, Coordinate _coordinate);
        string CompileReports(IEnumerable<IPirate> pirate);
    }
}