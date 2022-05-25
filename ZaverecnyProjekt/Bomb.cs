using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaverecnyProjekt
{
    public class Bomb
    {
        private int currX;
        private int currY;
        public int CurrX { get => currX; set => currX = value; }
        public int CurrY { get => currY; set => currY = value; }
        public Bomb(int currX, int currY)
        {
            CurrX = currX;
            CurrY = currY;
        }
    }
}
