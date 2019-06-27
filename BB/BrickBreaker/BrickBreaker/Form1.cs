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
        private List<Level> Levels;
        private Level SelectedLevel;

        //Constants (Секаде каде што треба да се користат се направени за само тука да се смени)
        private readonly int NUMBER_OF_LEVELS = 9;
        private readonly Size FULLSCREEN_SIZE;
        private readonly Size MENU_SIZE = new Size(900, 600);
        private readonly int SPACE_FROM_TOP = 40;


        private readonly Random random= new Random();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            FULLSCREEN_SIZE = Screen.FromControl(this).Bounds.Size;
            if(Levels == null)
                CreateLevels();
            game = new Game();
            DrawMainMenu();
        }

        private void CreateLevels()
        {
            Levels = new List<Level>();

            int k = 4;
            for(int i = 1; i<=NUMBER_OF_LEVELS; i++)
            {
                Levels.Add(GenerateRandomLevel(i * k, i * k, i * k, i * k));
            }
        }
        
        private Level GenerateRandomLevel(int minHeight, int maxHeight, int minWidth, int maxWidth)
        {
            List<Brick> BrickList = new List<Brick>();
            int RandomH = random.Next(minHeight, maxHeight);
            int RandomW = random.Next(minWidth, maxWidth);
            int BrickWidth = (FULLSCREEN_SIZE.Width / RandomW);
            int BrickHeight = FULLSCREEN_SIZE.Height / 4 / RandomH;
            for (int i = 0; i < RandomH; i++)
            {
                for(int j = 0; j< RandomW; j++)
                {
                    Point brickPoint = new Point(BrickWidth * j + FULLSCREEN_SIZE.Width%RandomW/2, BrickHeight * i+SPACE_FROM_TOP);
                    Brick brick = new Brick(BrickWidth, BrickHeight, brickPoint, Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)), 3);
                    BrickList.Add(brick);
                }
            }
            return new Level(BrickList, FULLSCREEN_SIZE);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(status == Status.PLAY)
            {
                e.Graphics.Clear(Color.Gray);
                SelectedLevel.Draw(e.Graphics);
                //this.BallTimer.Enabled = true;
                SelectedLevel.MoveBall();
                Invalidate();
            }
            else
            {
                this.MaximumSize = MENU_SIZE;
                //this.BallTimer.Enabled = false;
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

            Label labelBricksBreaker = CreateLabel(40, 10, 736, 103, "Bricks Breaker", 50);
            Controls.Add(labelBricksBreaker);

            Button buttonPlay = CreateButton(80, 120, 225, 55, "Play", 14);
            buttonPlay.Click += new EventHandler(BtnPlay_Click);
            Controls.Add(buttonPlay);

            Button buttonSaveGame = CreateButton(125, 185, 225, 55, "Save Game", 14);
            buttonSaveGame.Click += new EventHandler(BtnSaveGame_Click);
            Controls.Add(buttonSaveGame);

            Button buttonLoadGame = CreateButton(80, 250, 225, 55, "Load Game", 14);
            buttonLoadGame.Click += new EventHandler(BtnLoadGame_Click);
            Controls.Add(buttonLoadGame);

            Button buttonOptions = CreateButton(125, 315, 225, 55, "Options", 14);
            buttonOptions.Click += new EventHandler(BtnOptions_Click);
            Controls.Add(buttonOptions);

            Button buttonQuit = CreateButton(80, 380, 225, 55, "Quit", 14);
            buttonQuit.Click += new EventHandler(BtnQuit_Click);
            Controls.Add(buttonQuit);

            Label labelScore = CreateLabel(405, 145, 169, 53, "Level:", 26);
            Controls.Add(labelScore);

            Label labelGameScore = CreateLabel(405, 190, 48, 53, game.CurrentLevel.ToString(), 26);
            Controls.Add(labelGameScore);

            Label labelLevel = CreateLabel(405, 285, 169, 53, "Score:", 26);
            Controls.Add(labelLevel);

            Label labelGameLevel = CreateLabel(405, 330, 169, 53, game.CurrentScore.ToString(), 26);
            Controls.Add(labelGameLevel);

            status = Status.MENU;
        }

        /**
         *  Го креира менито за избор на ниво преку бришење на предходно прикажаните контроли 
         *  и динамичко креирање и додавање на соодветни нови контроли на формата.
         */
        private void DrawSelectLevel()
        {
            Controls.Clear();

            Button buttonBack = CreateButton(10, 10, 70, 30, "Back", 10);
            buttonBack.Click += new EventHandler(BtnBack_Click);
            Controls.Add(buttonBack);

            Label labelBricksBreaker = CreateLabel(235, 20, 231, 74, "Levels", 36);
            Controls.Add(labelBricksBreaker);

            for (int i = 1; i <= NUMBER_OF_LEVELS; i++)
            {
                int dx = ((i - 1) % 3) * 160;
                int dy = ((i - 1) / 3) * 110;
                Button buttonLevel = CreateButton(120 + dx, 100 + dy, 90, 90, i.ToString(), 14);
                buttonLevel.Tag = i;
                buttonLevel.Enabled = i <= game.CurrentLevel ? true : false;
                buttonLevel.Click += new EventHandler(BtnLevel_Click);
                Controls.Add(buttonLevel);
            }

            status = Status.MENU;
        }


        /**
         *  Креира контрола-копче со зададени почетни x и y координати, ширина, висина и текст кој треба да се прикаже на копчето.
         */
        private Button CreateButton(int x, int y, int width, int height, string text, int textSize)
        {
            Button newButton = new Button();
            newButton.Location = new Point(x, y);
            newButton.Size = new Size(width, height);
            newButton.BackColor = Color.DimGray;
            newButton.ForeColor = Color.LavenderBlush;
            newButton.Font = new Font("Showcard Gothic", textSize, FontStyle.Regular);
            newButton.Text = text;
            return newButton;
        }

        /**
         *  Креира контрола-лабела со зададени почетни x и y координати, ширина, висина и текст кој треба да се прикаже на лабелата.
         */
        private Label CreateLabel(int x, int y, int width, int height, string text, int textSize)
        {
            Label newLabel = new Label();
            newLabel.Location = new Point(x, y);
            newLabel.Size = new Size(width, height);
            newLabel.BackColor = Color.Transparent;
            newLabel.ForeColor = Color.LavenderBlush;
            newLabel.Font = new Font("Showcard Gothic", textSize, FontStyle.Regular);
            newLabel.Text = text;
            return newLabel;
        }
        
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            DrawSelectLevel();
        }

        private void BtnSaveGame_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("NOT IMPLEMENTED");
        }

        private void BtnLoadGame_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("NOT IMPLEMENTED");
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DrawMainMenu();
        }

        private void BtnLevel_Click(object sender, EventArgs e)
        {
            int? numLevel = (((Control)sender).Tag as int?);
            
            if (numLevel != null && numLevel<=NUMBER_OF_LEVELS && numLevel>=1)
            {
                SelectedLevel = Levels[(int)numLevel-1];
                Controls.Clear();


                this.MaximumSize = new Size(0, 0);
                this.Size = FULLSCREEN_SIZE;

                this.WindowState = FormWindowState.Maximized;


                /*Label stat = CreateLabel(0, 0, FULLSCREEN_SIZE.Width, SPACE_FROM_TOP, "-------------------", 20);
                stat.ForeColor = Color.White;
                stat.BackColor = Color.Orange;
                Controls.Add(stat);
                stat.Visible = true;
                stat.BringToFront();*/

                status = Status.PLAY;
            }
            else
            {
                MessageBox.Show("Invalid Level Selection");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (SelectedLevel != null)
            {
                //Testing Controls
                if (e.KeyData == Keys.W)
                    SelectedLevel.BallI.ChangeSpeed(0.1);
                if (e.KeyData == Keys.S)
                    SelectedLevel.BallI.ChangeSpeed(-0.1);

                SelectedLevel.MoveBouncer(sender, e);
                Invalidate();
            }
        }
    }
}
