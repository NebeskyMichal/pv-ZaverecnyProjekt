using System.Runtime.InteropServices;

namespace ZaverecnyProjekt
{
    public class Program
    {
        /// <summary>
        /// Piece of code taken from https://gist.github.com/FeniXb3/bcf410fe3d6d19d36c34fc434492b2da for disabling console resizing
        /// </summary>
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_SIZE = 0xF000;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        static void Main(string[] args)
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            Console.Write("Welcome to the game\nPlease insert your username:");
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
