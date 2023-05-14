using System;

namespace TicTacToe
{
    internal class Board
    {
        private char[] Positions { get; }
        public Board()
        {
            Positions = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };
        }

        static public int[,] GetWinningPositions()
        {
            return new int[8, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 3, 6, 9 },
                { 1, 5, 9 },
                { 3, 5, 7 }
            };
        }

        public bool IsPositionAvailable(int pos)
        {
            return Positions[pos - 1] == ' ';
        }

        public bool HasAvailablePositions()
        {
            foreach (char pos in  Positions)
            {
                if (pos == ' ') return true;
            }
            return false;
        }

        public void SetPosition(int pos, char playerSymbol)
        {
            Positions[pos - 1] = playerSymbol;
        }

        public void Update()
        {
            Console.WriteLine($" {Positions[0]} | {Positions[1]} | {Positions[2]}" +
                $" \r\n---+---+---\r\n {Positions[3]} | {Positions[4]} | {Positions[5]}" +
                $" \r\n---+---+---\r\n {Positions[6]} | {Positions[7]} | {Positions[8]} ");
            Console.WriteLine("");
        }
    }
}
