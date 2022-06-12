using System.Runtime.InteropServices;

namespace ZaverecnyProjekt.lib
{
    internal class Disabler
    {
        /// <summary>
        /// Piece of code taken from https://gist.github.com/FeniXb3/bcf410fe3d6d19d36c34fc434492b2da for disabling console resizing
        /// </summary>
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_SIZE = 0xF000;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public Disabler()
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
        }
    }
}
