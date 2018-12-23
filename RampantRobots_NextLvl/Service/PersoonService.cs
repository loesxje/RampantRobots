using System;
using System.Collections.Generic;
using System.Text;
using RampantRobots_NextLvl.Classes;

namespace RampantRobots_NextLvl.Service
{
    public interface IPlayerService
    {
        Player Create(int xPos, int yPos);
        void Move(string move ,Player player);
    }

    public class PlayerService : IPlayerService
    {
        public Player Create(int xPos, int yPoss)
        {
            return new Player
            {
                XPos = xPos,
                YPos = yPoss
            };
        }

        public void Move(string move, Player player)
        {
            for (var i = move.Length - 1; i >= 0; i--)
            {
                switch (move[i])
                {
                    case 'w':
                        player.YPos--;
                        break;
                    case 's':
                        player.YPos++;
                        break;
                    case 'a':
                        player.XPos--;
                        break;
                    case 'd':
                        player.XPos++;
                        break;
                    default:
                        Console.WriteLine("You gave in some wrong input.  Move only with the w,a,s,d keys.");
                        break;
                }
            }

        }
    }
}
