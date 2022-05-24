namespace ZaverecnyProjekt
{
    public class Bomb
    {
        private int currX;
        private int currY;

        public Bomb(int currX, int currY)
        {
            CurrX = currX;
            CurrY = currY;
        }

        public int CurrX { get => currX; set => currX = value; }
        public int CurrY { get => currY; set => currY = value; }
    }
}
