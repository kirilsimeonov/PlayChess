using PlayChess.Common;
using PlayChess.Pieces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Pieces
{
    public class Pawn : BasePiece, IPiece

    {
        public Pawn(GameColor color) : base(color)
        {
            
        }
        
    }
}
