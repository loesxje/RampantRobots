using System;
using System.Collections.Generic;
using System.Text;
using RampantRobots_NextLvl.Classes;

namespace RampantRobots_NextLvl.Service
{
    public class GameService
    {
        private readonly IBoardService _boardService;
        private readonly IPlayerService _playerService;
        private Player _player;
        private Board _board;

        public GameService(IBoardService boardService, IPlayerService playerService)
        {
            _boardService = boardService;
            _playerService = playerService;
        }

        public void Initialize()
        {
            _player = _playerService.Create(1, 1);
            _board = _boardService.Create(5, 10, 3, 3, _player);
        }

        public void Run()
        {
            _boardService.Draw(_player, _board);
            _boardService.MovePlayer(_player, _board);
        }
    }
}
