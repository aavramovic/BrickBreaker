using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public sealed class StaticLevels
    {
        private static List<Level> Levels;

        public StaticLevels()
        {
            Levels = new List<Level>();
            FillStaticLevels(Levels);
        }

        private void FillStaticLevels(List<Level> levels)
        {
            throw new NotImplementedException();
        }

        public Level GetLevel(int i)
        {
            return Levels[i];
        }

        private List<Brick> BrickList1()
        {
            List<Brick> temp = new List<Brick>();
            return temp;
        }
    }
}
