using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaverecnyProjekt
{
    public class BorderPiece
    {
        private int currX;
        private int currY;
        public int CurrX { get => currX; set => currX = value; }
        public int CurrY { get => currY; set => currY = value; }

        public BorderPiece(int cX, int cY)
        {
            CurrX = cX;
            CurrY = cY;
        }
    }
}
