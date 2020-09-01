using System;

namespace Rock_Paper_Scissors
{
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError(string message) : base(message)
        {
        }
    }
}