using System;
using System.Collections.Generic;
using System.Text;
using PlayChess.Common;

namespace PlayChess.Pieces.Contracts
{
    public abstract class BasePiece : IPiece
    {
        protected BasePiece (GameColor color)
        {
            Color = color;
        }

        public GameColor Color { get; private set; }
    }
}
