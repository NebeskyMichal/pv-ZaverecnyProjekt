namespace ZaverecnyProjekt
{
    public class Field
    {
        public static int minX = 1;
        public static int maxX = 119;
        public static int minY = 5;
        public static int maxY = 20;
        private int maxEnemy = 5;
        private List<Enemy> currEnemy;
        private Random rand;
        private Player player;
        private List<BorderPiece> borders;

        public List<Enemy> CurrEnemy { get => currEnemy; set => currEnemy = value; }
        public Random Rand { get => rand; set => rand = value; }
        public Player Player { get => player; set => player = value; }
        public List<BorderPiece> Borders { get => borders; set => borders = value; }
        public int MaxEnemy { get => maxEnemy; set => maxEnemy = value; }

        public Field(Player player)
        {
            Rand = new Random();
            CurrEnemy = new List<Enemy>();
            Borders = new List<BorderPiece>();
            this.Player = player;
        }
        /// <summary>
        /// Creates borders around map so that player cant move out of bounds
        /// </summary>
        public void SetBorders()
        {
            for (int i = 0; i < 120; i++)
            {
                Borders.Add(new BorderPiece(i, 4));
                Borders.Add(new BorderPiece(i, 20));
            }
            for (int j = 5; j < 20; j++)
            {
                Borders.Add(new BorderPiece(0, j));
                Borders.Add(new BorderPiece(119, j));
            }
        }

        /// <summary>
        /// Method chooses random position in certain range and writes Q(Enemy Indicator) at that position
        /// </summary>
        public void SpawnEnemy()
        {
            int rX = rand.Next(minX, maxX);
            int rY = rand.Next(minY, maxY);
            Console.SetCursorPosition(rX, rY);
            CurrEnemy.Add(new Enemy(rX, rY));
            Console.Write("Q");
            Console.SetCursorPosition(Player.CurrX + 1, Player.CurrY);
        }
        /// <summary>
        /// Method used for repeating SpawnEnemy() in seperate thread
        /// </summary>
        public void Spawner()
        {
            while (CurrEnemy.Count < MaxEnemy)
            {
                Thread t = new Thread(SpawnEnemy);
                t.Start();
                t.Join();
            }
        }
        /// <summary>
        /// Method for moving enemies towards player in console
        /// </summary>
        public void EnemyMovement()
        {
            int pX = Player.CurrX;
            int pY = Player.CurrY;
            for(int i = 0; i<CurrEnemy.Count; i++)
            {
                int eX = CurrEnemy[i].CurrX;
                int eY = CurrEnemy[i].CurrY;

                if (pX - eX > 0 && pY - eY == 0)
                {
                    CurrEnemy[i].EnemyActions("right");
                    Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                    Console.Write(player);
                }
                else if (pX - eX == 0 && pY - eY > 0)
                {
                    CurrEnemy[i].EnemyActions("down");
                    Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                    Console.Write(player);

                }
                else if (eX - pX > 0 && eY - pY == 0)
                {
                    CurrEnemy[i].EnemyActions("left");
                    Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                    Console.Write(player);
                }
                else if (pX - eX == 0 && eY - pY > 0)
                {
                    CurrEnemy[i].EnemyActions("up");
                    Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                    Console.Write(player);
                }
                else
                {
                    if (pX <= 60 && pY <= 20)
                    {
                        if (eX != 1)
                        {
                            CurrEnemy[i].EnemyActions("left");
                            Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                            Console.Write(player);
                        }
                        else if (eX != 1 && eY > 5)
                        {
                            CurrEnemy[i].EnemyActions("up");
                            Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                            Console.Write(player);
                        }
                    }
                    else if (pX <= 60 && pY >= 20)
                    {
                        if (eX != 1)
                        {
                            CurrEnemy[i].EnemyActions("left");
                            Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                            Console.Write(player);
                        }
                        else
                        {
                            CurrEnemy[i].EnemyActions("down");
                            Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                            Console.Write(player);
                        }
                    }
                    else if (pX >= 60 && pY <= 20)
                    {
                        if (eX != 118)
                        {
                            CurrEnemy[i].EnemyActions("right");
                            Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                            Console.Write(player);
                        }
                        else if (eX != 118 && eY > 5)
                        {
                            CurrEnemy[i].EnemyActions("up");
                            Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                            Console.Write(player);
                        }
                    }
                    else if (pX >= 60 && pY >= 20)
                    {
                        if (eX != 119)
                        {
                            CurrEnemy[i].EnemyActions("right");
                            Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                            Console.Write(player);
                        }
                        else if (eX != 120 && eY < 25)
                        {
                            CurrEnemy[i].EnemyActions("down");
                            Console.SetCursorPosition(Player.CurrX, Player.CurrY);
                            Console.Write(player);
                        }
                    }
                }
                BombCheck(CurrEnemy[i]);
                if(eX == pX && eY == pY)
                {
                    Player.Health--; 
                    CurrEnemy.Remove(CurrEnemy[i]);                    
                }
            }
        }

        public void BombCheck(Enemy e)
        {
            for(int j = 0; j<Player.PlacedBombs.Count; j++)
            {
                if (e.CurrX == Player.PlacedBombs[j].CurrX  && e.CurrY == Player.PlacedBombs[j].CurrY)
                {
                    CurrEnemy.Remove(e);
                    Player.PlacedBombs.Remove(Player.PlacedBombs[j]);
                }
            }
        }
    }
}
