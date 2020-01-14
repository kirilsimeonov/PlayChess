using PlayChess.Common;
using System;
using System.Collections.Generic;
using System.Text;


namespace PlayChess.Pieces.Contracts
{
    public interface IPiece
    {
        GameColor Color { get; }
    }
}
