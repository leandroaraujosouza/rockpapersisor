namespace Rock_Paper_Scissors
{
    public class Match
    {
        public Match(Player player1 = null, Player player2 = null)
        {
            this.Player1 = player1;
            this.Player2 = player2;

        }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}