using System;
using System.ComponentModel;
using RampantRobots_NextLvl.Classes;
using RampantRobots_NextLvl.Service;

namespace RampantRobots_NextLvl
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameService = GetGameService();

            gameService.Initialize();
            gameService.Run();

            Console.ReadLine();
        }

        private static GameService GetGameService()
        {
            var playerService = new PlayerService();
            var boardService = new BoardService(playerService);

            return new GameService(boardService, playerService);
        }
    }
}
