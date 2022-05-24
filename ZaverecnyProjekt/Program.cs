namespace ZaverecnyProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Player p = new Player();
            GUI g = new GUI();
            g.GUI_Menu();
            Console.ReadKey();
            g.GUI_Game();
            Console.SetCursorPosition(60, 10);
            Console.Write(p);
            p.Field.SetBorders();
            p.Field.Spawner();
            while (true)
            {            
                p.PlayerActions(Console.ReadKey(true).Key);
                p.Field.EnemyMovement();
            }

        }
    }
}
