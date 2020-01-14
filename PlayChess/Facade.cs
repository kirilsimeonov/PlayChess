using System;
using PlayChess.Engine;
using PlayChess.Engine.Contracts;
using PlayChess.Engine.Initializations;
using PlayChess.Inputs;
using PlayChess.Inputs.Contracts;
using PlayChess.Renderers;
using PlayChess.Renderers.Contracts;

namespace PlayChess
{
    public static class Facade
    {
        public static void Start()
        {
            //Създавам кой ми принтира
            IRenderer renderer = new ConsoleRenderer();

            //Извиквам мейн меню
            //renderer.RenderMenu();

            //Създавам кой ще ми чете данните за шаха
            IInputProvider inputProvider = new ConsoleInputProvider();

            //създавам енджина
            IEngine engine = new TwoPlayerEngine(renderer, inputProvider);

            //създавам как да инициализирам самата игра
            IGameInitialization gameInitialization = new StandartStartGameInitialization();

            engine.Initialize(gameInitialization);
            engine.Start();

            Console.ReadLine();
        }
    }
}
