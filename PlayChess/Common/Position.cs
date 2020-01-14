using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Common
{
    public struct  Position
    {

        public static Position GetPositionFromCoordinatesArray(int arrayRow, int arrCol, int totalRows)
        {
            return new Position(totalRows - arrayRow, (char)(arrCol + 'a'));
        }

        public static Position GetPositionFromCoordinatesChessBoard(int boardRow, char boardCol)
        {
            var newPosition = new Position(boardRow, boardCol);
            CheckIfValid(newPosition);
            return newPosition;
        }


        public Position(int row, char col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public static void CheckIfValid(Position position)
        {
            if (position.Row < Constants.MinimumBoardRowValue || position.Row > Constants.MaximumBoardRowValue)
            {
                throw new IndexOutOfRangeException("Invalid row input!");
            }
            if (position.Col < Constants.MinimumBoardColValue || position.Col > Constants.MaximumBoardColValue)
            {
                throw new IndexOutOfRangeException("Invalid column input!");
            }
        }

        public int Row { get; private set; }

        public char Col { get; private set; }
    }
}
