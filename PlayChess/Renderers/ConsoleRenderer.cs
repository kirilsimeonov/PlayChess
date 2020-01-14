using PlayChess.Board.Contracts;
using PlayChess.Common;
using PlayChess.Common.Console;
using PlayChess.Renderers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PlayChess.Renderers
{

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "...PLAY CHESS...";
        
        private const ConsoleColor DarkSquareBoardColor = ConsoleColor.DarkYellow;
        private const ConsoleColor LightSquareBoardColor = ConsoleColor.Yellow;

        public ConsoleRenderer()
        {
            //TODO: Change magic values
            //Проверявам за размерите на конзолния прозорец да е поне 100:80
            if (Console.WindowWidth < 100 || Console.WindowHeight < 80)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("CONSOLE WINDOW AND HEIGHT MUST BE AT LEAST 100 AND 80");
                Environment.Exit(0);
            }
        }

        public void RenderMenu()
        {
           

            ConsoleFeatures.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);
            //TODO: add main menu

            Thread.Sleep(1000);

        }
        public void RenderBoard(IBoard board)
        {
            //TODO: validate console diimensions
            var startRowPrint = Console.WindowHeight / 2 - board.TotalRows / 2 * ConsoleConstants.CharactersPerBoardSquareRow;
            var startColPrint = Console.WindowWidth / 2 - board.TotalCols / 2 * ConsoleConstants.CharactersPerBoardSquareCol;

            // var startRowPrint = Console.WindowWidth / 2 - board.TotalRows / 2 * ConsoleConstants.CharactersPerBoardSquareRow;
           // var startColPrint = Console.WindowHeight / 2 - board.TotalCols / 2 * ConsoleConstants.CharactersPerBoardSquareCol;


            //fix charactersperboadsquareCol е първо

            var currentRow = startRowPrint;
            var currentCol = startColPrint;

           Console.BackgroundColor = ConsoleColor.White;
            int counter = 1;

            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentRow = startRowPrint + top * ConsoleConstants.CharactersPerBoardSquareCol;
                    currentCol = startColPrint + left * ConsoleConstants.CharactersPerBoardSquareRow;
                    // currentRow = startColPrint + top * ConsoleConstants.CharactersPerBoardSquareRow;
                    // currentCol = startRowPrint + left * ConsoleConstants.CharactersPerBoardSquareRow;

                    ConsoleColor backgroundColor;

                    if (counter % 2 == 0)
                    {
                        backgroundColor = DarkSquareBoardColor;
                        Console.BackgroundColor= DarkSquareBoardColor;
                    }
                    else
                    {
                        backgroundColor = LightSquareBoardColor;
                        Console.BackgroundColor = LightSquareBoardColor;
                    }

                    var position = Position.GetPositionFromCoordinatesArray(top, left, board.TotalRows);

                    var piece = board.GetPieceAtPosition(position);
                    ConsoleFeatures.PrintPiece(piece, backgroundColor, currentRow, currentCol);

                   


                    counter++;
                }
                counter++;
            }



            Console.SetCursorPosition(Console.WindowWidth / 2, 2);



        }

        public void PrintErrorMessage(string errorMessage)
        {
            ConsoleFeatures.ClearRow(ConsoleConstants.ConsoleRowForMessageOutput);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, ConsoleConstants.ConsoleRowForMessageOutput);
            Console.Write(errorMessage);
            Thread.Sleep(2000);
            ConsoleFeatures.ClearRow(ConsoleConstants.ConsoleRowForMessageOutput);

        }
    }
}
