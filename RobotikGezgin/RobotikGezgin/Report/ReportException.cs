using System;

namespace RobotikGezgin.Report
{
    [Serializable]
    public class ReportException : Exception
    {
        public ReportException(string message) : base(message) { }
    }
}