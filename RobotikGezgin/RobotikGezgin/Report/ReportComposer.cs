using RobotikGezgin.Pirate;
using RobotikGezgin.Surface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotikGezgin.Report
{
    public class ReportComposer : IReportComposer
    {
        private readonly IDictionary<Coordinate, char> _coordinate;
        public ReportComposer()
        {
            _coordinate = new Dictionary<Coordinate, char>
            {
                 {Coordinate.North ,'N'},
                 {Coordinate.South, 'S'},
                 {Coordinate.East, 'E'},
                 {Coordinate.West, 'W'}
            };
        }
        public string Compose(Point _point, Coordinate coordinate)
        {
            var reportItem1 = _point.X;
            var reportItem2 = _point.Y;
            var reportItem3 = _coordinate[coordinate];
            var report = new StringBuilder();
            report.AppendFormat("{0} {1} {2}", reportItem1, reportItem2, reportItem3);
            return report.ToString();
        }
        public string CompileReports(IEnumerable<IPirate> pirate)
        {
            var reports = composeEachReport(pirate);
            return convertToString(reports);
        }
        private StringBuilder composeEachReport(IEnumerable<IPirate> pirates)
        {
            var reports = new StringBuilder();
            foreach (var pirate in pirates)
            {
                ensureRoverIsDeployed(pirate);
                var report = Compose(pirate._point, pirate._coordinate);
                reports.AppendLine(report);
            }
            return reports;
        }

        private static string convertToString(StringBuilder reports)
        {
            return reports.ToString()
                .TrimEnd('\n', '\r');
        }

        private static void ensureRoverIsDeployed(IPirate pirate)
        {
            if (!pirate.IsDeployed())
            {
                throw new ReportException("Rapor oluşturulamamıştır.");
            }
        }
    }
}
