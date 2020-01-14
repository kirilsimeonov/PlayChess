using PlayChess.Common;
using PlayChess.Pieces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Board.Contracts
{
    public interface IBoard
    {
        int TotalRows { get; }

        int TotalCols { get; }

        void AddPiece(IPiece pice, Position position);

        void RemovePiece(Position position);

        IPiece GetPieceAtPosition(Position position);
    }
}
