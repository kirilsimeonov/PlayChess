

namespace PlayChess.Common.Console
{
    using PlayChess.Pieces;
    using PlayChess.Pieces.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    //Console Helperi - pravqt obshti neshta po konzolata

    public static class ConsoleFeatures
    {
        private static IDictionary<string, bool[,]> patterns = new Dictionary<string, bool[,]>
        {
            { "Pawn", new bool[,]
            {
                {false,false,false,false,false,false,false,false,false },
                {false,false,false,false,false,false,false,false,false },
                {false,false,false,false,false,false,false,false,false },
                {false,false,false,true,true,true,false,false,false },
                {false,false,false,true ,true ,true,false,false,false },
                {false,false,false,false,true ,false,false,false,false },
                {false,false,false,true ,true ,true ,false,false,false },
                {false,false,true ,true ,true ,true ,true ,false,false },
                {false,false,false,false,false,false,false,false,false },

            }},
            { "Rook", new bool[,]
            {
                {false,false,false,false,false,false,false,false,false },
                {false,false,true ,false,true ,false,true ,false,false },
                {false,false,true ,true ,true ,true ,true ,false,false },
                {false,false,true ,true ,true ,true ,true ,false,false },
                {false,false,false,true ,true ,true ,false,false,false },
                {false,false,false,true ,true ,true ,false,false,false },
                {false,true ,true ,true ,true ,true ,true ,true ,false },
                {false,true ,true ,true ,true ,true ,true ,true ,false },
                {false,false,false,false,false,false,false,false,false },

            }},
            { "Knight", new bool[,]
            {
                {false,false,false,false,false,false,false,false,false },
                {false,false,true,true,true ,false,false,false,false },
                {false,true,true,true,true,true ,false,false,false },
                {false,true,true ,false,false,true ,true ,false,false },
                {false,true ,true,true ,false ,false,false,false,false },
                {false,false ,true ,true ,true ,false ,false,false,false },
                {false,false,true ,true ,true ,true ,false ,false,false },
                {false,true ,true ,true ,true ,true ,true ,true ,false },
                {false,false,false,false,false,false,false,false,false },

            }},
             { "Bishop", new bool[,]
            {
                {false,false,false,false,false,false,false,false,false },
                {false,false,false,false,true ,false,false,false,false },
                {false,false,false,true,true,true ,false,false,false },
                {false,false,true ,true,false,true ,true ,false,false },
                {false,false,true ,false,false ,false,true ,false,false },
                {false,false,false,true ,false,true,false,false,false },
                {false,false,false,false,true ,false,false,false,false},
                {false,false,true ,true ,false,true ,true ,false,false},
                {false,false,false,false,false,false,false,false,false},

            }},
            { "King", new bool[,]
            {
                {false,false,false,false,false,false,false,false,false },
                {false,false,false,false,true ,false,false,false,false },
                {false,false,false,true ,true ,true ,false,false,false },
                {false,false ,false,false,true ,false,false,false ,false },
                {false,false ,true ,true,true ,true,true ,false ,false },
                {false,false,true ,true ,true ,true,true ,false,false },
                {false,false,false ,true ,true ,true,false ,false,false},
                {false,false,false,true ,true ,true ,false,false,false},    
                {false,false,false,false,false,false,false,false,false},

            }},
             { "Queen", new bool[,]
            {
                {false,false,false,false,false,false,false,false,false },
                {false,false,false,false,true ,false,false,false,false },
                {false,false,true,false,true ,false ,true,false,false },
                {false,false ,false,true,false ,true,false,false ,false },
                {false,false ,true ,true,true ,true,true ,false ,false },
                {false,false,true ,true ,true ,true,true ,false,false },
                {false,false,false ,true ,true ,true,false ,false,false},
                {false,false,false,true ,true ,true ,false,false,false},
                {false,false,false,false,false,false,false,false,false},

            }}


        };

        public static void SetCursorAtCenter(int messageLength)
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - messageLength / 2;
            Console.SetCursorPosition(centerCol, centerRow);
            
        }
        public static ConsoleColor ToConsoleColor(this GameColor chessColor)
        {
            switch (chessColor)
            {
                case GameColor.Black:
                    return ConsoleColor.Black;
                    
                case GameColor.White:
                    return ConsoleColor.Gray;
                 
                case GameColor.Blue:
                    return ConsoleColor.Blue;
                   
                case GameColor.Red:
                    return ConsoleColor.Red;
                    
                default:
                    throw new InvalidOperationException("Invalid Chess Color!");
                    
            }
        }


        public static void PrintPiece(IPiece piece, ConsoleColor backgroundColor, int top, int left)
        {
            if (piece== null)
            {
                PrintEmptySquare(backgroundColor, top, left);
                return;
            }

            if (!patterns.ContainsKey(piece.GetType().Name))
            {
                return;
            }

            var piecePattern = patterns[piece.GetType().Name];

            
                for (int i = 0; i < piecePattern.GetLength(0); i++)
                {
                    for (int j = 0; j < piecePattern.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(left + j, top + i);
                        if (piecePattern[i,j])
                        {
                            Console.BackgroundColor = piece.Color.ToConsoleColor();
                        }
                        else
                        {
                            Console.BackgroundColor = backgroundColor;
                        }
                        Console.Write(" ");
                    }
                }
            
        }

        public static void PrintEmptySquare(ConsoleColor backgroundColor, int top, int left)
        {
            for (int i = 0; i < ConsoleConstants.CharactersPerBoardSquareRow; i++)
            {
                for (int j = 0; j < ConsoleConstants.CharactersPerBoardSquareCol; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    Console.Write(" ");
                }
            }
        }

        public static Move CreateMoveFromCommand(string command)
        {
            var positionInputFromUserAsStringArray = command.Split('-');

            if (positionInputFromUserAsStringArray.Length != 2)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var from = positionInputFromUserAsStringArray[0];
            var to = positionInputFromUserAsStringArray[1];

            var fromPosition = Position.GetPositionFromCoordinatesChessBoard(from[1] - '0', from[0]);
            var toPosition = Position.GetPositionFromCoordinatesChessBoard(to[1] - '0', to[0]);

            return new Move(fromPosition,toPosition);
        }

        public static void ClearRow(int row)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0,row);
            Console.Write(new string(' ', Console.WindowWidth));

        }
    }
}
