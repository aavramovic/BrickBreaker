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
    }
}
