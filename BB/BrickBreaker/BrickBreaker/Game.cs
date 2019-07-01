using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    [Serializable]
    public class Game
    {
        public int CurrentLevel { get; set; }
        public List<int> HighScores { get; set; }
        public BrickColor GameBrickColor { get; set; }
        public Difficulty GameDifficulty { get; set; }
        public enum Difficulty
        {
            ROOKIE = 1,
            ADVANCED = 2,
            PRO = 3
        }
        public enum BrickColor
        {
            RED = 1,
            GREEN = 2,
            BLUE = 3
        }
        public Game()
        {
            CurrentLevel = 1;
            HighScores = new List<int>();
            for(int i=0; i<9; i++)
            {
                HighScores.Add(0);
            }
            GameBrickColor = BrickColor.GREEN;
            GameDifficulty = Difficulty.ADVANCED;
        }
    }
}
