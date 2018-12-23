using System;
using RampantRobots_NextLvl.Classes;
using RampantRobots_NextLvl.Service;

namespace RampantRobots_NextLvl
{
    class Program
    {
        private static IBoardService _boardService;
        private static IPlayerService _playerService;

        public Program(IBoardService boardService,IPlayerService playerService)
        {
            _boardService = boardService;
            _playerService = playerService;
        }

        static void Main(string[] args)
        {
            var player = _playerService.Create(1, 1);
            var board = _boardService.Create(5,10,3,3,player);

            _boardService.Draw(player, board);
            _boardService.MovePlayer(player, board);

            Console.ReadLine();
        }
    }
}
