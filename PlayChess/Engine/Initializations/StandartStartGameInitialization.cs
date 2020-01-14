using System;
using System.Collections.Generic;
using System.Text;
using PlayChess.Board.Contracts;
using PlayChess.Common;
using PlayChess.Pieces;
using PlayChess.Pieces.Contracts;
using PlayChess.Players.Contracts;

namespace PlayChess.Engine.Initializations
{
    public class StandartStartGameInitialization : IGameInitialization
    {

        private const int StandartNumberOfRowsAndCols = 8;
        

        private IList<Type> pieceTypes;

        public StandartStartGameInitialization()
        {
            pieceTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)
            };
        }

        public void Initialize(IList<IPlayer> players, IBoard board)
        {

            ValidateInitialization(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];


            // Fill First Player Pawns & Pieces
            AddPiecesToRow(firstPlayer, board, 8);
            AddPawnsToRow(firstPlayer, board, 7);

            // Fill Second Player Pawns & Pieces
            AddPiecesToRow(secondPlayer, board, 1);
            AddPawnsToRow(secondPlayer, board, 2);

        }

        private void AddPawnsToRow(IPlayer player, IBoard board, int boardRow)
        {
            for (int i = 0; i < 8; i++)
            {
                var pawn = new Pawn(player.Color);
                player.AddPiece(pawn);
                var position = new Position(boardRow, (char)(i + 'a'));
                board.AddPiece(pawn, position);

            }
        }

        //Fill the other Row without the Pawns
        private void AddPiecesToRow(IPlayer player,IBoard board, int boardRow)
        {
            for (int i = 0; i < 8; i++)
            {
                var pieceType = pieceTypes[i];
                var pieceInstance = (IPiece)Activator.CreateInstance(pieceType, player.Color);
                player.AddPiece(pieceInstance);
                var position = new Position(boardRow, (char)(i + 'a'));
                board.AddPiece(pieceInstance, position);
            }
        }

        private void ValidateInitialization(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != Constants.StandartGameNumberOfPlayers)
            {
                throw new InvalidOperationException("Standart Chess Game must have 2 players!");
            }

            if (board.TotalRows != StandartNumberOfRowsAndCols || board.TotalCols != StandartNumberOfRowsAndCols)
            {
                throw new InvalidOperationException("Standart Chess Game must have must have a 8x8 board");
            }
        }


    }
}
