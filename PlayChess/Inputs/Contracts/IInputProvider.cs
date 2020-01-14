using PlayChess.Common;
using PlayChess.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Inputs.Contracts
{
    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);

        Move GetNextPlayerMove(IPlayer player);
    }
}
