using PlayChess.Common;
using PlayChess.Pieces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Pieces
{
    public class Rook :BasePiece, IPiece
    {
        public Rook (GameColor color)
            : base(color)
        {

        }
    }
}
