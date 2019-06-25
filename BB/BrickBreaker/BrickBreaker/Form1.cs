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
    enum Status
    {
        MENU,
        PLAY
    }
    public partial class Form1 : Form
    {
        private Game game;
        private Status status;
        //private string fileName;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            game = new Game();
            DrawMainMenu();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(status == Status.PLAY)
            {

            }
            else
            {
                e.Graphics.DrawImageUnscaled(BrickBreaker.Properties.Resources.MenuBackgroundImage, 0, 0);
            }
        }

        /**
         *  Го креира главното мени преку бришење на предходно прикажаните контроли 
         *  и динамичко креирање и додавање на соодветни нови контроли на формата.
         */
        private void DrawMainMenu()
        {
            Controls.Clear();

            Button buttonPlay = CreateButton(80, 120, 225, 55, "Play");
            buttonPlay.Click += new EventHandler(BtnPlay_Click);
            Controls.Add(buttonPlay);

            Button buttonSaveGame = CreateButton(125, 185, 225, 55, "Save Game");
            buttonSaveGame.Click += new EventHandler(BtnSaveGame_Click);
            Controls.Add(buttonSaveGame);

            Button buttonLoadGame = CreateButton(80, 250, 225, 55, "Load Game");
            buttonLoadGame.Click += new EventHandler(BtnLoadGame_Click);
            Controls.Add(buttonLoadGame);

            Button buttonOptions = CreateButton(125, 315, 225, 55, "Options");
            buttonOptions.Click += new EventHandler(BtnOptions_Click);
            Controls.Add(buttonOptions);

            Button buttonQuit = CreateButton(80, 380, 225, 55, "Quit");
            buttonQuit.Click += new EventHandler(BtnQuit_Click);
            Controls.Add(buttonQuit);

            Label labelScore = CreateLabel(405, 145, 169, 53, "Level:");
            Controls.Add(labelScore);

            Label labelGameScore = CreateLabel(405, 190, 48, 53, game.CurrentLevel.ToString());
            Controls.Add(labelGameScore);

            Label labelLevel = CreateLabel(405, 285, 169, 53, "Score:");
            Controls.Add(labelLevel);

            Label labelGameLevel = CreateLabel(405, 330, 169, 53, game.CurrentScore.ToString());
            Controls.Add(labelGameLevel);

            status = Status.MENU;
        }

        private void DrawSelectLevel()
        {
            Controls.Clear();

            

            status = Status.MENU;
        }

        /**
         *  Креира контрола-копче со зададени почетни x и y координати, ширина, висина и текст кој треба да се прикаже на копчето.
         */
        private Button CreateButton(int x, int y, int width, int height, string text)
        {
            Button newButton = new Button();
            newButton.Location = new Point(x, y);
            newButton.Size = new Size(width, height);
            newButton.BackColor = Color.DimGray;
            newButton.ForeColor = Color.White;
            newButton.Font = new Font("Showcard Gothic", 14, FontStyle.Regular);
            newButton.Text = text;
            return newButton;
        }

        /**
         *  Креира контрола-лабела со зададени почетни x и y координати, ширина, висина и текст кој треба да се прикаже на лабелата.
         */
        private Label CreateLabel(int x, int y, int width, int height, string text)
        {
            Label newLabel = new Label();
            newLabel.Location = new Point(x, y);
            newLabel.Size = new Size(width, height);
            newLabel.BackColor = Color.Transparent;
            newLabel.ForeColor = Color.White;
            newLabel.Font = new Font("Showcard Gothic", 26, FontStyle.Regular);
            newLabel.Text = text;
            return newLabel;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            DrawSelectLevel();
        }

        private void BtnSaveGame_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("SG");
        }

        private void BtnLoadGame_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("LG");
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            new Options().Show();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit game", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
