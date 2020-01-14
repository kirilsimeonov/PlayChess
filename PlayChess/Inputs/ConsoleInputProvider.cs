using PlayChess.Common;
using PlayChess.Common.Console;
using PlayChess.Inputs.Contracts;
using PlayChess.Players;
using PlayChess.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Inputs
{
    public class ConsoleInputProvider : IInputProvider
    {
        private const string AskForPlayerName = "Enter Player {0} name: ";



        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleFeatures.SetCursorAtCenter(AskForPlayerName.Length);
                Console.Write(String.Format(AskForPlayerName, i));

                string name = Console.ReadLine();

                var player = new Player(name, (GameColor)i - 1);
                players.Add(player);
            }

            return players;
        }

        public Move GetNextPlayerMove(IPlayer player)
        {
            ConsoleFeatures.ClearRow(ConsoleConstants.ConsoleRowForMessageOutput);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, ConsoleConstants.ConsoleRowForMessageOutput);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"{player.Name} IS NEXT :");
            var positionInputFromUserAsString = Console.ReadLine().Trim().ToLower();
            return ConsoleFeatures.CreateMoveFromCommand(positionInputFromUserAsString);
            

        }
    }
}
