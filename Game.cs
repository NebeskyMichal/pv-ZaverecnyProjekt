﻿namespace ZaverecnyProjekt
{
    public class Game
    {
        private GUI gui;
        private bool isPlaying;
        private Player player;
        public GUI Gui { get => gui; set => gui = value; }
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
        public Player Player { get => player; set => player = value; }

        public Game(string playerName)
        {
            Player = new Player(playerName);
            Gui = new GUI(1, Player);
            IsPlaying = true;
        }

        /// <summary>
        /// This method is controlling everything from here by playerInputs
        /// </summary>
        public void Play()
        {
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
                        Player.Health = 3;
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
                        }
                        Player.Field.CurrEnemy.Clear();
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
                            Gui.GUI_Stats();
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