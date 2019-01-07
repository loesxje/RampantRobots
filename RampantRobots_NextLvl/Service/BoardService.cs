using System;
using System.Collections.Generic;
using System.Text;
using RampantRobots_NextLvl.Classes;

namespace RampantRobots_NextLvl.Service
{
    public interface IBoardService
    {
        Board Create(int height, int width, int xRobots, int turns, Player player);
        void Draw(Player player, Board board);
        void MovePlayer(Player player, Board board);
    }

    public class BoardService: IBoardService
    {
        private static IPlayerService _playerService;

        public BoardService(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public Board Create(int height, int width, int xRobots, int turns, Player player)
        {
            var random = new Random(42);
            var robots = new List<Robot>();

            for (var i = 0; i < xRobots; i++)
            {
                var newRobot = new Robot(random.Next(1, width), random.Next(1, height));

                if (robots.Contains(newRobot) | (newRobot.XPos == player.XPos & newRobot.YPos == player.YPos))
                    i--;

                robots.Add(newRobot);
            }

            return new Board
            {
                Height = height,
                Width = width,
                Turns = turns,
                Robots = robots
            };
        }

        public void Draw(Player player, Board board)
        {
            StringBuilder sb = new StringBuilder();

            for (var h = 1; h <= board.Height; h++)
            {
                for (var l = 1; l <= board.Width; l++)
                {
                    var locRobot = new Robot(l, h);
                    if (player.XPos == l & player.YPos == h)
                    {
                        sb.Append('M');
                    }
                    else if (board.Robots.Contains(locRobot))
                    {
                        sb.Append('R');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());
        }

        public void MovePlayer(Player player, Board board)
        {
            for (var i = 1; i <= board.Turns; i++)
            {
                Console.WriteLine("Press Enter to continue");
                var move = Console.ReadLine();
                _playerService.Move(move, player);
                Draw(player, board);
                Console.WriteLine($"You've got {board.Turns - i} turns left.");
            }
        }

    }
}
