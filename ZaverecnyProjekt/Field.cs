namespace ZaverecnyProjekt
{
    public class Field
    {
        public static int minX = 5;
        public static int maxX = 110;
        public static int minY = 5;
        public static int maxY = 20;
        public static int maxEnemy = 25;
        private static List<Enemy> currEnemy;
        private Random rand;
        private Player player;

        public static List<Enemy> CurrEnemy { get => currEnemy; set => currEnemy = value; }
        public Random Rand { get => rand; set => rand = value; }
        public Player Player { get => player; set => player = value; }

        public Field(Player player)
        {
            Rand = new Random();
            CurrEnemy = new List<Enemy>();
            this.Player = player;
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
            while (CurrEnemy.Count < maxEnemy)
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
            foreach(var e in CurrEnemy)
            {
                //Calculate distance between each enemy and player
            }
        }
    }
}
