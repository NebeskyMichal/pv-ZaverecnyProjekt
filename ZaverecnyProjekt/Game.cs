using Newtonsoft.Json;
using System.Configuration;
using ZaverecnyProjekt.lib;

namespace ZaverecnyProjekt
{
    public class Game
    {
        private GUI gui;
        private bool isPlaying;
        private Player player;
        private Database database;
        private IniFile ini;
        private int multiplier;
        public GUI Gui { get => gui; set => gui = value; }
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
        public Player Player { get => player; set => player = value; }
        public Database Database { get => database; set => database = value; }
        public IniFile Ini { get => ini; set => ini = value; }
        public int Multiplier { get => multiplier; set => multiplier = value; }

        public Game(string playerName)
        {
            Player = new Player(playerName);
            Gui = new GUI(1, Player);
            IsPlaying = true;
            Database = new Database();
            Ini = new IniFile("config.ini");
            Multiplier = 5;
        }

        /// <summary>
        /// Loads all required data from Player_name stored in database and in confing.ini
        /// </summary>
        public void Loading()
        {
            if (Database.PlayerExists(Player.Name))
            {
                string jsonData = Database.PlayerLoad(Player.Name);
                var tempData = JsonConvert.DeserializeObject<List<PlayerStats>>(jsonData);
                Player.PlayerStats = tempData[0];
            }
            Gui.Wave = Player.PlayerStats.Longest_run;
            Player.Health = Int32.Parse(Ini.IniReadValue("Game", "player_health"));
            Player.MaxBombs = Int32.Parse(Ini.IniReadValue("Game", "max_bombs"));
            Gui.PlayerHealth = Player.Health;
        }

        /// <summary>
        /// This method is controlling everything from here by playerInputs
        /// </summary>
        public void Play()
        {
            Loading();
            string playerInput = "";
            bool instanceCheck = true;
            while (IsPlaying)
            {
                bool inputCheck = true;
                Gui.GUI_Menu();
                while (inputCheck)
                {
                    try
                    {
                        playerInput = Console.ReadLine();
                        inputCheck = false;
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                        Gui.GUI_Menu();
                    }
                }
                switch (playerInput)
                {
                    case "start":
                        Console.Write("\b \b");
                        Player.CurrX = 60;
                        Player.CurrY = 10;
                        Console.Write(Player);
                        Gui.GUI_Game();
                        Player.Field.Spawner();
                        Player.Field.SetBorders();
                        while (Player.Health > 0 && Player.Field.CurrEnemy.Count > 0)
                        {
                            Player.PlayerActions(Console.ReadKey(true).Key);
                            Player.Field.EnemyMovement(Player.CurrX,Player.CurrY);
                            Gui.GUI_Refresh(Player.Health);

                        }
                        if (Player.Health > 0)
                        {
                            Gui.Wave++;
                            Player.Field.MaxEnemy += 5;
                            Player.MaxBombs++;
                            Player.PlayerStats.Longest_run = Gui.Wave;
                        }
                        else
                        {
                            Player.PlayerStats.Deaths_total++;
                        }
                        Player.Field.CurrEnemy.Clear();
                        break;
                    case "save":
                        Database.SavePlayer(Player);
                        break;
                    case "stats":
                        instanceCheck = true;
                        Gui.GUI_Stats(Player.PlayerStats);
                        while (instanceCheck)
                        {
                            string playerInput1 = Console.ReadLine();
                            if (playerInput1 == "exit")
                            {
                                instanceCheck = false;
                            }
                            Gui.GUI_Stats(Player.PlayerStats);
                        }
                        break;
                    case "help":
                        instanceCheck = true;
                        Gui.GUI_Help();
                        while (instanceCheck)
                        {
                            string playerInput1 = Console.ReadLine();
                            if (playerInput1 == "exit")
                            {
                                instanceCheck = false;
                            }
                            Gui.GUI_Help(); 
                        }
                        break;
                    case "exit":
                        IsPlaying = false;
                        break;
                }
            }
        }
    }
}
