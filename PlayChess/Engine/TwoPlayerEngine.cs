using PlayChess.Common;
using PlayChess.Engine.Contracts;
using PlayChess.Engine.Initializations;
using PlayChess.Inputs.Contracts;
using PlayChess.Players.Contracts;
using PlayChess.Renderers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


namespace PlayChess.Engine
{
    using PlayChess.Board;
    using PlayChess.Board.Contracts;
    using PlayChess.Players;
    using System.Linq;

    public class TwoPlayerEngine : IEngine
    {
        private int currPlayerIndex;

        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;


        public TwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            input = inputProvider;
            board = new Board();

        }


        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitialization gameInitialization)
        {
            //TODO: use the input for players

            this.players = new List<IPlayer>
            {
                new Player("Pesho",GameColor.Black),
                new Player("Gosho",GameColor.White)
            };//input.GetPlayers(Constants.StandartGameNumberOfPlayers);

            SetFirtsPlayerIndex();
            gameInitialization.Initialize(this.players, this.board); //инициализираме дъксата и играчите

            renderer.RenderBoard(board);

        }



        public void Start()
        {
            while (true)
            {
                
                try
                {
                    var currentPlayer = GetNextPlayer();
                    var move = input.GetNextPlayerMove(currentPlayer);
                }
                catch (Exception ex)
                {
                    currPlayerIndex--;
                    renderer.PrintErrorMessage(ex.Message);
                }

            }



        }

        private IPlayer GetNextPlayer()
        {
            currPlayerIndex++;
            if (this.currPlayerIndex >= players.Count)
            {
                currPlayerIndex = 0;
            }

            return players[currPlayerIndex];

        }

        private void SetFirtsPlayerIndex()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Color == GameColor.White)
                {
                    currPlayerIndex = i;
                    return;
                }
            }
        }



        public void WinningConditions()
        {
            throw new NotImplementedException();
        }
    }
}
