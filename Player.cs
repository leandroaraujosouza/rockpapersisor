namespace Rock_Paper_Scissors
{
    public class Player
    {
        public Player()
        {
        }

        public Player(string name, string strategy)
        {
            this.Name = name;
            this.Strategy = strategy;

        }
        public string Name { get; set; }
        public string Strategy { get; set; }        
    }
}