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
    enum Mode
    {
        MAIN_MENU,
        SELECT_LEVEL,
        PLAY
    }
    public partial class Form1 : Form
    {
        private Game game;
        private Mode mode;  
        private string fileName;
        private List<Control> controls;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            controls = new List<Control>();

            DrawMainMenu();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        /**
         *  Го креира главното мени преку бришење на предходно прикажаните контроли 
         *  и динамичко креирање и додавање на соодветни нови контроли на формата.
         */
        private void DrawMainMenu()
        {
            this.Controls.Clear();

            Button buttonPlay = CreateButton(80, 45, 225, 55, "Play");
            buttonPlay.Click += new EventHandler(BtnPlay_Click);
            controls.Add(buttonPlay);

            Button buttonSaveGame = CreateButton(125, 115, 225, 55, "Save Game");
            buttonSaveGame.Click += new EventHandler(BtnSaveGame_Click);
            controls.Add(buttonSaveGame);

            Button buttonLoadGame = CreateButton(80, 185, 225, 55, "Load Game");
            buttonLoadGame.Click += new EventHandler(BtnLoadGame_Click);
            controls.Add(buttonLoadGame);

            Button buttonOptions = CreateButton(125, 255, 225, 55, "Options");
            buttonOptions.Click += new EventHandler(BtnOptions_Click);
            controls.Add(buttonOptions);

            Button buttonQuit = CreateButton(80, 325, 225, 55, "Quit");
            buttonQuit.Click += new EventHandler(BtnQuit_Click);
            controls.Add(buttonQuit);

            controls.ForEach(c => this.Controls.Add(c));

            mode = Mode.MAIN_MENU;
        }

        private void DrawSelectLevel()
        {
            throw new NotImplementedException();
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
            newButton.Name = "btn" + text.Replace(" ", "");
            return newButton;
        }

        private Label CreateLabel()
        {
            throw new NotImplementedException();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Play");
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
            throw new NotImplementedException("OPTS");
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
