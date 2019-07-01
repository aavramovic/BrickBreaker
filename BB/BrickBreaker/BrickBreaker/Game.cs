using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    [Serializable]
    class Game
    {
        public int CurrentLevel { get; set; }
        public List<int> HighScores { get; set; }

        public Game()
        {
            CurrentLevel = 1;
            HighScores = new List<int>();
            for(int i=0; i<9; i++)
            {
                HighScores.Add(0);
            }
        }
    }
}
