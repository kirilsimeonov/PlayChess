using PlayChess.Common;
using PlayChess.Pieces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Pieces
{
    public class King : BasePiece, IPiece
    {
        public King(GameColor color)
            : base(color)
        {

        }
    }
}
