using PlayChess.Common;
using PlayChess.Pieces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Players.Contracts
{
    public interface IPlayer
    {
        string Name { get; }

        GameColor Color { get; }

        void AddPiece(IPiece piece);

        void RemovePiece(IPiece piece);
    }
}
