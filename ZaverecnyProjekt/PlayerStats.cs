using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaverecnyProjekt
{
    public class PlayerStats
    {
        private string name;
        private int longest_run;
        private int kills_total;
        private int deaths_total;
        private int bombs_placed;

        public int Longest_run { get => longest_run; set => longest_run = value; }
        public int Kills_total { get => kills_total; set => kills_total = value; }
        public int Deaths_total { get => deaths_total; set => deaths_total = value; }
        public int Bombs_placed { get => bombs_placed; set => bombs_placed = value; }
        public string Name { get => name; set => name = value; }

        public PlayerStats() {
            Longest_run = 1;
        }
        public PlayerStats(string name,int run,int kill, int death, int bomb)
        {
            Name = name;
            Longest_run = run;
            Kills_total = kill; 
            Deaths_total = death;
            Bombs_placed = bomb;
        }

        public override string ToString()
        {
            return "longest_run = " + Longest_run + ", kills_total = " + Kills_total + ", deaths_total = " + Deaths_total + ", bombs_placed = " + Bombs_placed;
        }

    }
}
