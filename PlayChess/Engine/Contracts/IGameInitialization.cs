using PlayChess.Board.Contracts;
using PlayChess.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Engine.Initializations
{
    public interface IGameInitialization
    {
        void Initialize(IList<IPlayer> players, IBoard board);
        
    }
}
