using System;

namespace RobotikGezgin.Command
{
    [Serializable]
    public class CommandException : Exception
    {
        public CommandException(string message, Exception innerException) : base(message, innerException) { }
    }
}