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
    public partial class Options : Form
    {
        public BrickForm brickForm { get; set; }
        public Options(BrickForm b1)
        {
            InitializeComponent();
            brickForm = b1;
            if (b1.Game.GameBrickColor == Game.BrickColor.BLUE)
                blueRadioButton.Checked = true;
            if (b1.Game.GameBrickColor == Game.BrickColor.RED)
                redRadioButton.Checked = true;
            if (b1.Game.GameBrickColor == Game.BrickColor.GREEN)
                greenRadioButton.Checked = true;
            if (b1.Game.GameDifficulty == Game.Difficulty.ROOKIE)
                rookieRadioButton.Checked = true;
            if (b1.Game.GameDifficulty == Game.Difficulty.ADVANCED)
                advancedRadioButton.Checked = true;
            if (b1.Game.GameDifficulty == Game.Difficulty.PRO)
                proRadioButton.Checked = true;

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (rookieRadioButton.Checked)
                brickForm.Game.GameDifficulty = Game.Difficulty.ROOKIE;
            else if (advancedRadioButton.Checked)
                brickForm.Game.GameDifficulty = Game.Difficulty.ADVANCED;
            else if (proRadioButton.Checked)
                brickForm.Game.GameDifficulty = Game.Difficulty.PRO;
            if (redRadioButton.Checked)
                brickForm.Game.GameBrickColor = Game.BrickColor.RED;
            else if (blueRadioButton.Checked)
                brickForm.Game.GameBrickColor = Game.BrickColor.BLUE;
            else
                brickForm.Game.GameBrickColor = Game.BrickColor.GREEN;
            brickForm.CreateLevels();
            this.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
