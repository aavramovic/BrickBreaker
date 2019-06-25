using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class LevelForm : Form
    {
        Level LevelInstance;
        public LevelForm(Level SelectedLevel)
        {
            
            InitializeComponent();
            DoubleBuffered = true;
            LevelInstance = SelectedLevel;
        }

        private void LevelPanel_Paint(object sender, PaintEventArgs e)
        {
            LevelInstance.Draw(e.Graphics);
        }
    }
}
