using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaverecnyProjekt
{
    public class Enemy
    {
        private static char icon = 'Q';
        private int currX;
        private int currY;
        public int CurrX { get => currX; set => currX = value; }
        public int CurrY { get => currY; set => currY = value; }

        public Enemy(int currX, int currY)
        {
            CurrX = currX;
            CurrY = currY;
        }
        public override string ToString()
        {
            return icon.ToString();
        }
    }
}
