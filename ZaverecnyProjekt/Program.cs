using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using ZaverecnyProjekt.lib;

namespace ZaverecnyProjekt
{
    public class Program
    {

        static void Main(string[] args)
        {
            Disabler d = new Disabler();
            Console.Write("Welcome to the game\nPlease insert your new or existing username:");
            string username = "";
            bool check = true;
            while (check)
            {
                try
                {
                    username = Console.ReadLine();
                    check = false;
                }
                catch (Exception e)
                {
                    Console.Write("Error! Insert different name");
                }
            }
            Game g = new Game(username);
            g.Play();
        }
    }
}
