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
        /// <summary>
        /// GUI for Menu
        /// </summary>
        public void GUI_Menu()
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.SetCursorPosition(0, 2);
            Console.Write("|");
            Console.SetCursorPosition(20, 2);
            Console.Write("Player: " + PlayerName);
            Console.SetCursorPosition(55, 2);
            Console.Write("Health: " + PlayerHealth);
            Console.SetCursorPosition(95, 2);
            Console.Write("Wave: " + Wave);
            Console.SetCursorPosition(119, 2);
            Console.Write("|"); Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            Console.WriteLine("                                                    |Start new wave|                                                  \n");
            Console.WriteLine("                                                     |Save profile|                                                  \n");
            Console.WriteLine("                                                      |Statistics|                                                  \n");
            Console.WriteLine("                                                     |Search player|                                                  \n");
            Console.WriteLine("                                                         |Help|                                                  \n");
            Console.WriteLine("                                                         |Exit|                                                  \n");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n");
            Console.Write("|                                                                                                                      |");
            Console.Write("|           To invoke some action you can use shortened words such as start,save,stats,search,help,exit                |");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n+----------------------------------------------------------------------------------------------------------------------+");
            Console.SetCursorPosition(58, 17);
        }
        /// <summary>
        /// GUI Field for game
        /// </summary>
        public void GUI_Game()
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.SetCursorPosition(0, 2);
            Console.Write("|");
            Console.SetCursorPosition(20, 2);
            Console.Write("Player: " + PlayerName);
            Console.SetCursorPosition(55, 2);
            Console.Write("Health: " + PlayerHealth);
            Console.SetCursorPosition(95, 2);
            Console.Write("Wave: " + Wave);
            Console.SetCursorPosition(119, 2);
            Console.Write("|");
            Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            for (int i = 5; i < 20; i++)
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
        /// <summary>
        /// GUI for statistics about player
        /// </summary>
        public void GUI_Stats(PlayerStats p)
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.SetCursorPosition(0, 2);
            Console.Write("|");
            Console.SetCursorPosition(20, 2);
            Console.Write("Player: " + PlayerName);
            Console.SetCursorPosition(55, 2);
            Console.Write("Health: " + PlayerHealth);
            Console.SetCursorPosition(95, 2);
            Console.Write("Wave: " + Wave);
            Console.SetCursorPosition(119, 2);
            Console.Write("|");
            Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            Console.WriteLine("                                                 |Statistics for " + p.Name + "|                                                  ");
            Console.WriteLine("                                                     |Longest run:" + p.Longest_run + "|                                                 \n");
            Console.WriteLine("                                                     |Kills total:" + p.Kills_total + "|                                                 \n");
            Console.WriteLine("                                                     |Deaths total:" + p.Deaths_total + "|                                                 \n");
            Console.WriteLine("                                                     |Bombs placed:" + p.Bombs_placed + "|                                                 \n");
            Console.WriteLine("                                                         |Exit|                                                  \n");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n");
            Console.Write("|                                                                                                                      |");
            Console.Write("|                     To invoke some action you can use shortened words such as start,load,stats,exit                  |");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n+----------------------------------------------------------------------------------------------------------------------+");
            Console.SetCursorPosition(58, 17);
        }

        /// <summary>
        /// GUI for tutorial on how to play the game
        /// </summary>
        public void GUI_Help()
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.SetCursorPosition(0, 2);
            Console.Write("|");
            Console.SetCursorPosition(20, 2);
            Console.Write("Player: " + PlayerName);
            Console.SetCursorPosition(55, 2);
            Console.Write("Health: " + PlayerHealth);
            Console.SetCursorPosition(95, 2);
            Console.Write("Wave: " + Wave);
            Console.SetCursorPosition(119, 2);
            Console.Write("|"); Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            Console.WriteLine("                                                 You are the player (X)                                          \n");
            Console.WriteLine("                                           Your task is to kill all enemies (Q)                                  \n");
            Console.WriteLine("                                                 and Surive endless waves                                        \n");
            Console.WriteLine("                                              Move with arrows on keyboard                                       \n");
            Console.WriteLine("                                                Place bombs with spacebar                                        \n");
            Console.WriteLine("                                                         |Exit|                                                  \n");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n");
            Console.Write("|                                                                                                                      |");
            Console.Write("|                     To invoke some action you can use shortened words such as start,load,stats,exit                  |");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n+----------------------------------------------------------------------------------------------------------------------+");
            Console.SetCursorPosition(58, 17);
        }

        public void GUI_Search()
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.SetCursorPosition(0, 2);
            Console.Write("|");
            Console.SetCursorPosition(20, 2);
            Console.Write("Player: " + PlayerName);
            Console.SetCursorPosition(55, 2);
            Console.Write("Health: " + PlayerHealth);
            Console.SetCursorPosition(95, 2);
            Console.Write("Wave: " + Wave);
            Console.SetCursorPosition(119, 2);
            Console.Write("|"); Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            Console.WriteLine("                                                 Insert player name                                          \n");
            Console.WriteLine("                                            you wish to see the statistics of                                 \n");
            Console.WriteLine("                                                                                                                                   \n");
            Console.WriteLine("                                                                                                                               \n");
            Console.WriteLine("                                                                                                                                  \n");
            Console.WriteLine("                                                         |Exit|                                                  \n");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n");
            Console.Write("|                                                                                                                      |");
            Console.Write("|                     To invoke some action you can use shortened words such as start,load,stats,exit                  |");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n+----------------------------------------------------------------------------------------------------------------------+");
            Console.SetCursorPosition(58, 15);
        }
        /// <summary>
        /// After level GUI
        /// </summary>
        public void GUI_Afterlevel(int wave_number, int bombs_placed, int enemy_kills)
        {
            Console.Clear();
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+");
            Console.Write("|                                                                                                                      |");
            Console.SetCursorPosition(0, 2);
            Console.Write("|");
            Console.SetCursorPosition(20, 2);
            Console.Write("Player: " + PlayerName);
            Console.SetCursorPosition(55, 2);
            Console.Write("Health: " + PlayerHealth);
            Console.SetCursorPosition(95, 2);
            Console.Write("Wave: " + Wave);
            Console.SetCursorPosition(119, 2);
            Console.Write("|"); Console.Write("|                                                                                                                      |");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n\n");
            Console.WriteLine("                                          !!!Congratulations you completed!!!                                          \n");
            Console.WriteLine("                                            Wave  No. "+wave_number + "                                           \n");
            Console.WriteLine("                                            You killed "+ enemy_kills + " Enemies                                 \n");
            Console.WriteLine("                                            You placed " + bombs_placed + " Bombs                                 \n");
            Console.WriteLine("                                                                                                                    \n");
            Console.WriteLine("                                                 |Enter to continue|                                               \n");
            Console.Write("+----------------------------------------------------------------------------------------------------------------------+\n");
            Console.Write("|                                                                                                                      |");
            Console.Write("|                     To invoke some action you can use shortened words such as start,load,stats,exit                  |");
            Console.Write("|                                                                                                                      |");
            Console.Write("\n+----------------------------------------------------------------------------------------------------------------------+");
            Console.SetCursorPosition(58, 15);
        }

        /// <summary>
        /// Method that refreshes second line in GUI
        /// </summary>
        /// <param name="health"></param>
        public void GUI_Refresh(int health)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write("|");
            Console.SetCursorPosition(20, 2);
            Console.Write("Player: " + PlayerName);
            Console.SetCursorPosition(55, 2);
            Console.Write("Health: " + health);
            Console.SetCursorPosition(95, 2);
            Console.Write("Wave: " + Wave);
            Console.SetCursorPosition(119, 2);
            Console.Write("|");
        }
    }
}
