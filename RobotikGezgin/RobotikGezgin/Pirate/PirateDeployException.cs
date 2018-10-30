using System;

namespace RobotikGezgin.Pirate
{
    [Serializable]
    public class PirateDeployException : Exception
    {
        public PirateDeployException(string message) : base(message) { }
    }
}