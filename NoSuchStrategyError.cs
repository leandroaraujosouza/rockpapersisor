using System;

namespace Rock_Paper_Scissors
{
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError(string message) : base(message)
        {
        }
    }
}