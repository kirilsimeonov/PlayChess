using PlayChess.Common;
using PlayChess.Pieces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Pieces
{
    public class Queen : BasePiece, IPiece
    {
        public Queen(GameColor color)
            : base(color)
        {

        }
    }
}
