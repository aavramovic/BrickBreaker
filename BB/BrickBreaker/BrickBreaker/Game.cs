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
        public int CurrentScore { get; set; }
        public Game()
        {
            CurrentLevel = 1;
            CurrentScore = 0;
        }
    }
}
