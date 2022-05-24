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
        private Field field;
        private bool canPlace;

        public Field Field { get => field; set => field = value; }
        public int Health { get => health; set => health = value; }
        public int CurrX { get => currX; set => currX = value; }
        public int CurrY { get => currY; set => currY = value; }
        public int Facing { get => facing; set => facing = value; }
        public int MaxBombs { get => maxBombs; set => maxBombs = value; }
        public List<Bomb> PlacedBombs { get => placedBombs; set => placedBombs = value; }
        public bool CanPlace { get => canPlace; set => canPlace = value; }

        public Player()
        {
            Health = 3;
            CurrX = 60;
            CurrY = 10;
            Facing = 3;
            MaxBombs = 10;
            CanPlace = true;
            PlacedBombs = new List<Bomb>();
            Field = new Field(this);
        }
        /// <summary>
        /// Method used for moving player in console using arrow keys and calling method PlaceBomb() using spacebar
        /// </summary>
        /// <param name="key"></param>
        public void PlayerActions(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX += 1, CurrY);
                    if (!this.CheckNextChar())
                    {
                        Console.SetCursorPosition(CurrX -= 1, CurrY);
                        CanPlace = false;
                        Console.Write(this);
                        break;
                    }
                    Console.Write(this);
                    Facing = 3;
                    CanPlace = true;
                    break;
                case ConsoleKey.LeftArrow:
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX -= 1, CurrY);
                    if (!this.CheckNextChar())
                    {
                        Console.SetCursorPosition(CurrX += 1, CurrY);
                        CanPlace = false;
                        Console.Write(this);
                        break;
                    }
                    Console.Write(this);
                    Facing = 1;
                    CanPlace = true;
                    break;
                case ConsoleKey.DownArrow:
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX, CurrY += 1);
                    if (!this.CheckNextChar())
                    {
                        Console.SetCursorPosition(CurrX, CurrY -= 1);
                        CanPlace = false;
                        Console.Write(this);
                        break;
                    }
                    Console.Write(this);
                    Facing = 2;
                    CanPlace = true;
                    break;
                case ConsoleKey.UpArrow:
                    Console.Write("\b \b");
                    Console.SetCursorPosition(CurrX, CurrY -= 1);
                    if (!this.CheckNextChar())
                    {
                        Console.SetCursorPosition(CurrX, CurrY += 1);
                        CanPlace = false;
                        Console.Write(this);
                        break;
                    }
                    Console.Write(this);
                    Facing = 4;
                    CanPlace = true;
                    break;
                case ConsoleKey.Spacebar:
                    this.PlaceBomb();
                    break;
            }
        }
        /// <summary>
        /// Method determinating if the next character is either bomb,enemy or border
        /// </summary>
        public bool CheckNextChar()
        {
            PlacedBombs.RemoveAll(x => x.CurrX == CurrX && x.CurrY == CurrY);
            if (Field.Borders.Exists(x => x.CurrX == this.CurrX && x.CurrY == this.CurrY))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Method writing O(Bomb indicator) to console until maximum bomb count is reached
        /// </summary>
        public void PlaceBomb()
        {
            if (PlacedBombs.Count < MaxBombs && CanPlace)
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
