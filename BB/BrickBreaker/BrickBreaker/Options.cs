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
            if (b1.brickColor == BrickForm.BrickColor.BLUE)
                blueRadioButton.Checked = true;
            if (b1.brickColor == BrickForm.BrickColor.RED)
                redRadioButton.Checked = true;
            if (b1.brickColor == BrickForm.BrickColor.GREEN)
                greenRadioButton.Checked = true;
            if (b1.difficulty == BrickForm.Difficulty.ROOKIE)
                rookieRadioButton.Checked = true;
            if (b1.difficulty == BrickForm.Difficulty.ADVANCED)
                advancedRadioButton.Checked = true;
            if (b1.difficulty == BrickForm.Difficulty.PRO)
                proRadioButton.Checked = true;

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (rookieRadioButton.Checked)
                brickForm.difficulty = BrickForm.Difficulty.ROOKIE;
            else if (advancedRadioButton.Checked)
                brickForm.difficulty = BrickForm.Difficulty.ADVANCED;
            else if (proRadioButton.Checked)
                brickForm.difficulty = BrickForm.Difficulty.PRO;

            BrickForm.BrickColor c;
            if (redRadioButton.Checked)
                c = BrickForm.BrickColor.RED;
            else if (blueRadioButton.Checked)
                c = BrickForm.BrickColor.BLUE;
            else
                c = BrickForm.BrickColor.GREEN;
            brickForm.brickColor = c;
            brickForm.ChangeBrickListColor();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
