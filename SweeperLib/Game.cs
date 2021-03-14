using System;

namespace Sweeper
{
    public enum GameState
    {
        Lost,
        Won,
        InProgress
    }

    public class Game
    {
        private Board _board;
        private GameState _state = GameState.InProgress;

        public Game()
        {
            _board = new Board(8, 10);
            _board.GenerateBoard(8);
        }

        public override string ToString()
        {
            return _board.ToString() + "State: " + _state;
        }

        public Board GetBoard() => _board;
        public GameState GetGameState() => _state;

        public void MakeMove(int row, int column)
        {
            var value = _board.GetCell(row, column);

            // Check cell value.
            if (value == Board.MINE)
            {
                _state = GameState.Lost;
                _board.RevealAll();
                return;
            }

            if (value == 0)
            {
                // Reveal adjacent 0 cells.
                _board.RevealArea(row, column);
            }
            else
            {
                _board.RevealCell(row, column);
            }

            // Check for win.
            if (_board.UserHasWon())
            {
                _state = GameState.Won;
            }
        }
    }
}
