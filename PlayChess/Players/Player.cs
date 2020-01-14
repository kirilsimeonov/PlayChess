using PlayChess.Common;
using PlayChess.Pieces.Contracts;
using PlayChess.Players.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayChess.Players
{
    public class Player : IPlayer
    {
        private readonly ICollection<IPiece> pieces;
        

        public Player(string name, GameColor color)
        {
            //TODO: validate length of the name
            pieces = new List<IPiece>();
            Color = color;
            Name = name;
        }

        public GameColor Color { get; private set; }

        public string Name { get; private set; }

        public void AddPiece(IPiece piece)
        {
            ObjectValidator.CheckIfObjectIsNull(piece, ErrorMessages.NullPieceError);
            ChefIfPieceExists(piece);
            this.pieces.Add(piece);
            //TODO: check piece and color
        }

        public void RemovePiece(IPiece piece)
        {
            ObjectValidator.CheckIfObjectIsNull(piece, ErrorMessages.NullPieceError);
            //TODO: check piece and color
            ChefIfPieceDoesNotExist(piece);
            pieces.Remove(piece);
        }

        private void ChefIfPieceExists(IPiece piece)
        {
            if (this.pieces.Contains(piece))
            {
                throw new InvalidOperationException("Player has this piece already!");
            }
        }

        private void ChefIfPieceDoesNotExist(IPiece piece)
        {
            if (!this.pieces.Contains(piece))
            {
                throw new InvalidOperationException("Player does not have this piece!");
            }
        }

       
    }
}
