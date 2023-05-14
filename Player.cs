using System;

namespace TicTacToe
{
    internal class Player
    {
        public char Symbol { get; }
        private int[] Choices { get; }

        public Player(char symbol) {
            Symbol = symbol;
            Choices = new int[5];
        }

        public void SetFirstZeroIndex(int value)
        {
            int index = 0;
            foreach (int pos in Choices)
            {
                if (pos == 0)
                {
                    Choices[index] = value;
                    break;
                }
                index++;
            }
        }

        public bool HasWinningPositions()
        {
            int[,] positions = Board.GetWinningPositions();
            int matches = 0;
            for (int row = 0; row < positions.GetLength(0); row++)
            {
                for (int column = 0; column < positions.GetLength(1); column++)
                {
                    foreach (int pos in Choices)
                    {
                        if (pos == positions[row, column])
                        {
                            matches++;
                            if (matches == 3) return true;
                        }
                    }
                }
                matches = 0;
            }
            return false;
        }
    }
}
