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
        public void EnemyActions(string action)
        {
            Console.SetCursorPosition(currX+1,currY);
            switch (action)
            {
                case "right":               
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX += 1, CurrY);
                    Console.Write(this);
                    break;
                case "left":
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX -= 1, CurrY);
                    Console.Write(this);
                    break;
                case "down":
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX, CurrY += 1);
                    Console.Write(this);
                    break;
                case "up":
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX, CurrY -= 1);
                    Console.Write(this);
                    break;
            }
        }
        public override string ToString()
        {
            return icon.ToString();
        }
    }
}
