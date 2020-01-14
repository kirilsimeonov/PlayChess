using PlayChess.Common;
using PlayChess.Pieces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Pieces
{
    public class Bishop : BasePiece, IPiece
    {
        public Bishop(GameColor color)
            : base(color)
        {

        }
    }
}
