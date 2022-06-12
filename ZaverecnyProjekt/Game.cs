using Newtonsoft.Json;
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
        private int restoreHP;
        public GUI Gui { get => gui; set => gui = value; }
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
        public Player Player { get => player; set => player = value; }
        public Database Database { get => database; set => database = value; }
        public IniFile Ini { get => ini; set => ini = value; }
        public int Multiplier { get => multiplier; set => multiplier = value; }
        public int RestoreHP { get => restoreHP; set => restoreHP = value; }

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
            int configHealth = Int32.Parse(Ini.IniReadValue("Game", "player_health"));
            int bombsConfig = Int32.Parse(Ini.IniReadValue("Game", "max_bombs"));
            Player.MaxBombs = bombsConfig;
            Gui.PlayerHealth = configHealth;
            RestoreHP = configHealth;
            Player.Field.MaxEnemy = Gui.Wave * Multiplier;
        }

        /// <summary>
        /// This method is controlling everything from here by playerInputs
        /// </summary>
        public void Play()
        {
            Loading();
            string playerInput = "";
            string playerInput1 = "";
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
                        Player.Health = restoreHP;
                        Gui.GUI_Game();
                        Player.Field.Spawner();
                        Player.Field.SetBorders();
                        while (Player.Health > 0 && Player.Field.CurrEnemy.Count > 0)
                        {
                            Player.PlayerActions(Console.ReadKey(true).Key);
                            Player.Field.EnemyMovement(Player.CurrX, Player.CurrY);
                            Gui.GUI_Refresh(Player.Health);

                        }
                        if (Player.Health > 0)
                        {
                            Gui.Wave++;
                            Player.Field.MaxEnemy += Multiplier;
                            Player.MaxBombs++;
                            if(Player.PlayerStats.Longest_run < Gui.Wave)
                            {
                                Player.PlayerStats.Longest_run = Gui.Wave;
                            }
                        }
                        else
                        {
                            if (Gui.Wave != 1)
                            {
                                Gui.Wave--;
                            }
                            Player.PlayerStats.Deaths_total++;
                            if(Player.Field.MaxEnemy > 5)
                            {
                                Player.Field.MaxEnemy -= Multiplier;
                            }
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
                            playerInput1 = Console.ReadLine();
                            if (playerInput1 == "exit")
                            {
                                instanceCheck = false;
                            }
                            Gui.GUI_Stats(Player.PlayerStats);
                        }
                        break;
                    case "search":
                        instanceCheck = true;
                        Gui.GUI_Search();
                        bool playerSearch = true;
                        while (playerSearch)
                        {

                            string playerName = Console.ReadLine();
                            if (playerName == "exit")
                            {
                                instanceCheck = false;
                                playerSearch = false;
                                break;
                            }
                            string jsonData = Database.PlayerLoad(playerName);
                            try
                            {
                                var tempData = JsonConvert.DeserializeObject<List<PlayerStats>>(jsonData);
                                Gui.GUI_Stats(tempData[0]);
                                playerSearch = false;
                            }
                            catch (Exception e)
                            {
                                Gui.GUI_Search();
                            }
                            Console.ReadLine();
                        }
                        break;
                    case "help":
                        instanceCheck = true;
                        Gui.GUI_Help();
                        while (instanceCheck)
                        {
                            playerInput1 = Console.ReadLine();
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
