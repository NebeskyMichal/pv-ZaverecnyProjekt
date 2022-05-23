using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaverecnyProjekt
{
    public class Player
    {
        private static char icon = 'X';
        private int health;
        private int currX;
        private int currY;
        private int facing;
        private int maxBombs;
        private List<Bomb> placedBombs;
        public int Health { get => health; set => health = value; }
        public int CurrX { get => currX; set => currX = value; }
        public int CurrY { get => currY; set => currY = value; }
        public int Facing { get => facing; set => facing = value; }
        public int MaxBombs { get => maxBombs; set => maxBombs = value; }
        public List<Bomb> PlacedBombs { get => placedBombs; set => placedBombs = value; }

        public Player()
        {
            Health = 3;
            CurrX = 60;
            CurrY = 10;
            Facing = 3;
            MaxBombs = 10;
            PlacedBombs = new List<Bomb>();      
        }

        public void PlayerActions(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX += 1, CurrY);
                    ReadNextChar();
                    Console.Write(this);
                    Facing = 3;
                    break;
                case ConsoleKey.LeftArrow:
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX -= 1, CurrY);
                    ReadNextChar();

                    Console.Write(this);
                    Facing = 1;
                    break;
                case ConsoleKey.DownArrow:
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX, CurrY += 1);
                    ReadNextChar();

                    Console.Write(this);
                    Facing = 2;
                    break;
                case ConsoleKey.UpArrow:
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX, CurrY -= 1);
                    ReadNextChar();
                    Console.Write(this);
                    Facing = 4;
                    break;
                case ConsoleKey.Spacebar:
                    this.PlaceBomb();
                    break;
            }
        }

        public void ReadNextChar()
        {
            PlacedBombs.RemoveAll(x => x.CurrX == CurrX && x.CurrY == CurrY);
        }

        public void PlaceBomb()
        {
            if (PlacedBombs.Count < MaxBombs)
            {
                if (Facing == 3)
                {
                    Console.SetCursorPosition(CurrX + 1, CurrY);
                    Console.Write('O');
                    PlacedBombs.Add(new Bomb(CurrX + 1, CurrY));
                    Console.SetCursorPosition(CurrX + 1, CurrY);
                }
                else if (Facing == 2)
                {
                    Console.SetCursorPosition(CurrX, CurrY + 1);
                    Console.Write('O');
                    PlacedBombs.Add(new Bomb(CurrX, CurrY + 1));
                    Console.SetCursorPosition(CurrX + 1, CurrY);
                }
                else if (Facing == 4)
                {
                    Console.SetCursorPosition(CurrX, CurrY - 1);
                    Console.Write('O');
                    PlacedBombs.Add(new Bomb(CurrX, CurrY - 1));
                    Console.SetCursorPosition(CurrX + 1, CurrY);
                }
                else if (Facing == 1)
                {
                    Console.SetCursorPosition(CurrX - 1, CurrY);
                    Console.Write('O');
                    PlacedBombs.Add(new Bomb(CurrX - 1, CurrY));
                    Console.SetCursorPosition(CurrX + 1, CurrY);
                }               
            }
        }


        public override string ToString()
        {
            return icon.ToString();
        }
    }
}
