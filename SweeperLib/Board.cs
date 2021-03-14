using System;

namespace Sweeper
{
    public class Board
    {
        // Board array.
        private int[,] _board;
        // Mask array.
        private bool[,] _revealedMask;

        private (int, int)[] ADJACENT_VS = {
            // Top row
            (-1, -1),
            (0, -1),
            (1, -1),
            // Middle row (exclude current)
            (-1,  0),
            (1,  0),
            // Bottom row
            (-1,  1),
            (0,  1),
            (1,  1),
        };

        public const int MINE = 42;

        public int Columns { get { return _board.GetLength(1); } }
        public int Rows { get { return _board.GetLength(0); } }

        public Board(int rows, int columns)
        {
            _board = new int[rows, columns];
            _revealedMask = new bool[rows, columns];
        }

        public override string ToString()
        {
            var returnString = "";

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    returnString += _revealedMask[i, j]
                        ? (_board[i, j] == MINE ? "M " : _board[i, j] + " ")
                        : "X ";
                }
                returnString += Environment.NewLine;
            }

            return returnString;
        }

        // GetBoard()

        public void GenerateBoard(int mineCount)
        {
            var random = new Random();

            // Randomly place mines.
            for(int i = 0; i < mineCount; i++) {
                _board[random.Next(Rows), random.Next(Columns)] = MINE;
            }

            // Count adjacent mines.
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (_board[i, j] != MINE) {
                        _board[i, j] = countAdjacents(i, j);
                    }
                }
            }
        }

        private int countAdjacents(int x, int y)
        {
            var count = 0;
            var tupes = new (int, int)[] {
                (1, 1),
            };

            foreach (var (dx, dy) in ADJACENT_VS)
            {
                var checkX = x + dx;
                var checkY = y + dy;

                // Ignore out of bounds.
                if (checkX < 0 || checkX >= Rows || checkY < 0 || checkY >= Columns) {
                    continue;
                }

                if (_board[checkX, checkY] == MINE) {
                    count++;
                }
            }

            return count;
        }

        public int GetCell(int row, int column) => _board[row, column];
        public bool IsRevealed(int row, int column) => _revealedMask[row, column];

        public void RevealCell(int row, int column)
        {
            _revealedMask[row, column] = true;
        }

        public void RevealAll()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _revealedMask[i, j] = true;
                }
            }
        }

        public void RevealArea(int row, int column)
        {
            if (row < 0 || column < 0 || row >= Rows || column >= Columns || IsRevealed(row, column) || GetCell(row, column) != 0)
            {
                return;
            }

            RevealCell(row, column);

            foreach (var (dx, dy) in ADJACENT_VS)
            {
                RevealArea(row + dx, column + dy);
            }
        }

        public bool UserHasWon()
        {
            // If there are any cells unrevealed that aren't mines, the user
            // hasn't won yet.
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (!IsRevealed(i, j) && GetCell(i, j) != MINE)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
