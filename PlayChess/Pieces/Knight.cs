using PlayChess.Common;
using PlayChess.Pieces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Pieces
{
    public class Knight : BasePiece, IPiece
    {
        public Knight(GameColor color) 
            : base(color)
        {

        }

    }
}
