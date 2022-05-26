namespace ZaverecnyProjekt
{
    public class GUI
    {
        private string playerName;
        private Player player;
        private int wave;
        private int playerHealth;

        public string PlayerName { get => playerName; set => playerName = value; }
        public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
        public int Wave { get => wave; set => wave = value; }
        public Player Player { get => player; set => player = value; }

        public GUI(int wave, Player player)
        {
            PlayerName = player.Name;
            PlayerHealth = player.Health;
            Wave = wave;
        }

        public void GUI_Menu()
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n|                Player:"+PlayerName+"                       Health: "+PlayerHealth+"                   Wave: "+Wave+"                               |");
            Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            Console.WriteLine("                                                    |Start new wave|                                                  \n");
            Console.WriteLine("                                                     |Save profile|                                                  \n");
            Console.WriteLine("                                                     |Load profile|                                                  \n");
            Console.WriteLine("                                                      |Statistics|                                                  \n");
            Console.WriteLine("                                                         |Exit|                                                  \n");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n");
            Console.Write("|                                                                                                                      |");
            Console.Write("|                To invoke some action you can use shortened words such as start,save,load,stats,exit                  |");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n+----------------------------------------------------------------------------------------------------------------------+");
            Console.SetCursorPosition(58, 17);
    }

        public void GUI_Game()
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n|                Player:" + PlayerName + "                      Health: " + PlayerHealth + "                   Wave: " + Wave + "                                 |");
            Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            for(int i = 5; i <20; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(119, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(60, 10);
            Console.Write("X");
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");
        }
        
        public void GUI_Stats()
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n|                Player:" + PlayerName + "                      Health: " + PlayerHealth + "                   Wave: " + Wave + "                                 |");
            Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            Console.WriteLine("                                                     |Statistics:|                                                  \n");
            Console.WriteLine("                                                     |Longest run:|                                                  \n");
            Console.WriteLine("                                                     |Kills total:|                                                  \n");
            Console.WriteLine("                                                     |Deaths total:|                                                  \n");
            Console.WriteLine("                                                     |Bombs placed:|                                                  \n");
            Console.WriteLine("                                                         |Exit|                                                  \n");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n");
            Console.Write("|                                                                                                                      |");
            Console.Write("|                     To invoke some action you can use shortened words such as start,load,stats,exit                  |");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n+----------------------------------------------------------------------------------------------------------------------+");
            Console.SetCursorPosition(58, 17);
        }

        public void GUI_Refresh(int health)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write("|                Player:" + PlayerName + "                      Health: " + health + "                   Wave: " + Wave + "                                 |");
        }
    }
}
