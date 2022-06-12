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
                    if(username.Length > 20)
                    {
                        Console.WriteLine("Username is too long\nIt needs to be under 20 letters");
                    }
                    else if(username.Length <= 0)
                    {
                        Console.WriteLine("Username is too short or blank\nIt needs to be more than 0 letters");
                    }
                    else
                    {
                        check = false;
                    }
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
