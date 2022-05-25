namespace ZaverecnyProjekt
{
    public class Game
    {
        private string playerName;
        private GUI gui;
        private bool isPlaying;

        public string PlayerName { get => playerName; set => playerName = value; }
        public GUI Gui { get => gui; set => gui = value; }
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }

        public Game(string playerName)
        {
            PlayerName = playerName;
            Gui = new GUI(playerName, 3, 0);
            IsPlaying = true;
        }

        /// <summary>
        /// This method is controlling everything from here by playerInputs
        /// </summary>
        public void Play()
        {
            string playerInput = "";
            bool instanceCheck = true;
            Player p = new Player();
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
                        instanceCheck = true;
                        Gui.GUI_Game();
                        p.Field.Spawner();
                        p.Field.SetBorders();
                        while (instanceCheck)
                        {
                            p.PlayerActions(Console.ReadKey(true).Key);
                            p.Field.EnemyMovement();
                        }
                        break;
                    case "save":

                        break;
                    case "load":

                        break;
                    case "stats":
                        instanceCheck = true;
                        Gui.GUI_Stats();
                        while (instanceCheck)
                        {
                            string playerInput1 = Console.ReadLine();
                            if (playerInput1 == "exit")
                            {
                                instanceCheck = false;
                            }
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
