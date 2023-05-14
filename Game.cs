using System;

namespace TicTacToe
{
    internal class Game
    {
        private Board Board { get; }
        private Player Player1 { get; }
        private Player Player2 { get; }
        private Player CurrentPlayer { get; set; }

        public Game()
        {
            Board = new Board();
            Player1 = new Player('X');
            Player2 = new Player('O');
            CurrentPlayer = Player1;
        }

        public void PlayGame()
        {
            Board.Update();
            while (true)
            {
                PlayTurn();
                Console.Clear();
                Board.Update();
                bool playerWins = CurrentPlayer.HasWinningPositions();
                if (playerWins)
                {
                    Console.WriteLine($"{CurrentPlayer.Symbol} player wins!");
                    return;
                }
                else
                {
                    if (Board.HasAvailablePositions())
                    {
                        if (CurrentPlayer == Player1) CurrentPlayer = Player2;
                        else CurrentPlayer = Player1;
                    }
                    else
                    {
                        Console.WriteLine("The game is a Draw!");
                        return;
                    }
                }
            }
        }

        private void PlayTurn()
        {
            Console.Write($"{CurrentPlayer.Symbol} player, please select a space in the grid: ");
            while (true)
            {
                int userChoice;
                string choiceText = Console.ReadLine();
                bool converted = int.TryParse(choiceText, out userChoice);
                if (converted && userChoice >= 1 && userChoice <= 9)
                {
                    if (Board.IsPositionAvailable(userChoice))
                    {
                        CurrentPlayer.SetFirstZeroIndex(userChoice);
                        Board.SetPosition(userChoice, CurrentPlayer.Symbol);
                        return;
                    }
                    else
                    {
                        Console.Write("The position is already taken, select another: ");
                    }
                }
                else
                {
                    Console.Write("Please select a valid position: ");
                }
            }
        }
    }
}
