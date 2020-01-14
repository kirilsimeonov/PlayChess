using PlayChess.Board.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Renderers.Contracts
{
    public interface IRenderer
    {
        void RenderMenu();

        void RenderBoard(IBoard board);

        void PrintErrorMessage(string errorMessage);
    }
}
