using System;
using System.Threading;

namespace ZaverecnyProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            int currX = 60;
            int currY = 10;
            Player p = new Player();
            Console.WriteLine("\n\n\n\n+----------------------------------------------------------------------------------------------------------------------+"); 
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");
            Console.SetCursorPosition(currX, currY);
            Console.Write(p);
            Field f = new Field(p);
            
            while (true)
            {
                f.Spawner();
                p.PlayerActions(Console.ReadKey(true).Key);
            }

        }
    }
}
