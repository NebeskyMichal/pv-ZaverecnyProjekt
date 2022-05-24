namespace ZaverecnyProjekt
{
    public class GUI
    {


        public GUI()
        {
        }

        public void GUI_Menu()
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n|                Player: [Name]                      Health: [Health]                      Wave: [Wave]                |");
            Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            Console.WriteLine("                                                    |Start new wave|                                                  \n");
            Console.WriteLine("                                                     |Load profile|                                                  \n");
            Console.WriteLine("                                                      |Statistics|                                                  \n");
            Console.WriteLine("                                                         |Exit|                                                  \n");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n");
            Console.Write("|                                                                                                                      |");
            Console.Write("|                     To invoke some action you can use shortened words such as start,load,stats,exit                  |");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n+----------------------------------------------------------------------------------------------------------------------+");
    }

        public void GUI_Game()
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n|                Player: [Name]                      Health: [Health]                      Wave: [Wave]                |");
            Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            for(int i = 5; i <20; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(119, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");

        }
    }
}
