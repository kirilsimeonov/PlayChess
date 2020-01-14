using PlayChess.Engine.Initializations;
using PlayChess.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Engine.Contracts
{
    public interface IEngine
    {
        IEnumerable<IPlayer> Players { get; }

        void Initialize(IGameInitialization gameInitializationStrategy);

        void Start();

        void WinningConditions();
        //TODO Enum with 4 conditions - WIn Lose Draw Not Win Yet
    }
}
