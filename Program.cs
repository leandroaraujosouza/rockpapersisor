using System;
using System.Collections.Generic;
using System.Linq;

namespace Rock_Paper_Scissors
{

    class Program
    {
        static readonly char[] options = new char[] { 'P', 'R', 'S' };
        static void Main(string[] args)
        {

            var tournament = new List<Match> {
                new Match(new Player("Altemir", GenerateStrategyRandom()), new Player("Paulo Nunes", GenerateStrategyRandom())),
                new Match(new Player("José", GenerateStrategyRandom()), new Player("Maria", GenerateStrategyRandom())),
                new Match(new Player("Fernando", GenerateStrategyRandom()), new Player("Luana", GenerateStrategyRandom())),
                new Match(new Player("Leandro", GenerateStrategyRandom()), new Player("Michele", GenerateStrategyRandom()))
            };

            rps_tournament_winner(tournament);
        }


        private static string GenerateStrategyRandom()
        {

            var option = new Random().Next(0, 2);
            return options.GetValue(option).ToString().ToUpper();
        }

        public static void rps_tournament_winner(List<Match> tournament)
        {

            List<Match> finalists = new List<Match>();

            if (!tournament?.Any() ?? false)
                return;

            ValidateTournament(tournament);

            int index = 1;
            Player winnerBefore = new Player();
            foreach (var match in tournament)
            {
                var winner = rps_game_winner(match.Player1, match.Player2);
                if (index % 2 == 0)
                    finalists.Add(new Match(winnerBefore, winner));

                winnerBefore = winner;
                Console.WriteLine($"Match: {match.Player1.Name} ({match.Player1.Strategy}) x {match.Player2.Name} ({match.Player2.Strategy}) : Winner -> {winner.Name} ");
                index++;
            }

            if (finalists.Count == 0)
            {
                Console.WriteLine($"Winner Tournament: {winnerBefore.Name}");
            }

            if (finalists.Count > 0)
                rps_tournament_winner(finalists);
        }

        private static void ValidateTournament(List<Match> tournament)
        {
            foreach (var match in tournament)
            {
                if (match.Player1 == null || match.Player2 == null)
                {
                    throw new WrongNumberOfPlayersError("It is necessary to have 2 players.");
                }
                if (match.Player1.Strategy.IndexOfAny(options) == -1 ||
                    match.Player2.Strategy.IndexOfAny(options) == -1)
                    throw new NoSuchStrategyError("Strategy selected not found! use (R - Rock, P - Paper, S - Scissors)");
            }
        }

        private static Player rps_game_winner(Player player1, Player player2)
        {
            var playerWinner = new Player();

            if (player1.Strategy == "R" && player2.Strategy == "S")
                playerWinner = player1;
            else if (player1.Strategy == "S" && player2.Strategy == "P")
                playerWinner = player1;
            else if (player1.Strategy == "P" && player2.Strategy == "R")
                playerWinner = player1;

            if (player2.Strategy == "R" && player1.Strategy == "S")
                playerWinner = player2;
            else if (player2.Strategy == "S" && player1.Strategy == "P")
                playerWinner = player2;
            else if (player2.Strategy == "P" && player1.Strategy == "R")
                playerWinner = player2;

            if (player1.Strategy == player2.Strategy)
                playerWinner = player1;

            return playerWinner;
        }
    }
}
