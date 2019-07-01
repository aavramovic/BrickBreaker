using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public enum Status
    {
        MENU,
        PLAY
    }
    public partial class BrickForm : Form
    {
        public Game Game { get; set; }
        public Status status { get; set; }
        public List<Level> Levels { get; set; }
        public Level SelectedLevel { get; set; }
        private readonly int NUMBER_OF_LEVELS = 9;
        private readonly Size FULLSCREEN_SIZE;
        private readonly Size MENU_SIZE = new Size(700, 500);
        private readonly int SPACE_FROM_TOP = 40;
        private readonly Random random= new Random();
        public BrickForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            FULLSCREEN_SIZE = Screen.FromControl(this).WorkingArea.Size;

            Game = new Game();
            if (Levels == null)
                CreateLevels();
            DrawMainMenu();
        }
        public void CreateLevels()
        {
            Levels = new List<Level>();
            for(int i = 1; i<=NUMBER_OF_LEVELS; i++)
            {
                int k = i / 3;
                int levelMultiplier = i + k + (int)Game.GameDifficulty-1;
                Levels.Add(GenerateRandomLevel(levelMultiplier, i, Game.GameBrickColor));
            }
        }
        
        private Level GenerateRandomLevel(int levelMultiplier, int id, Game.BrickColor brickColor)
        {
            List<Brick> BrickList = new List<Brick>();
            int RandomH = levelMultiplier;
            int RandomW = levelMultiplier;
            int BrickWidth = (FULLSCREEN_SIZE.Width / RandomW);
            int BrickHeight = FULLSCREEN_SIZE.Height / 4 / RandomH;
            for (int i = 0; i < RandomH; i++)
            {
                for(int j = 0; j< RandomW; j++)
                {
                    Point brickPoint = new Point(BrickWidth * j + FULLSCREEN_SIZE.Width%RandomW/2, BrickHeight * i+SPACE_FROM_TOP);
                    Brick brick = new Brick(BrickWidth, BrickHeight, brickPoint, brickColor,random.Next(1,4));
                    BrickList.Add(brick);
                }
            }
            return new Level(BrickList, FULLSCREEN_SIZE, id);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(status == Status.PLAY)
            {
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font("Showcard Gothic", 15, FontStyle.Regular);
                Brush b = new SolidBrush(Color.White);
                
                String messageScore = String.Format("Level Score: {0}", SelectedLevel.CurrentScore);
                e.Graphics.DrawString(messageScore, font, b, 5, 5);
                String messageLives = String.Format("Lives: {0}", SelectedLevel.PlayerLives);
                e.Graphics.DrawString(messageLives, font, b, Size.Width - 100, 5);

                SelectedLevel.Draw(e.Graphics);

                if (SelectedLevel.IsCompleted())
                {

                    if(Game.CurrentLevel < 10 && Game.CurrentLevel <= SelectedLevel.ID)
                        Game.CurrentLevel++;


                    LevelCompleted();
                }
                else
                {
                    SelectedLevel.MoveBall(e.Graphics);
                }
                MoveTimer.Enabled = true;
            }
            else
            {
                this.MaximumSize = MENU_SIZE;
                e.Graphics.DrawImageUnscaled(BrickBreaker.Properties.Resources.MenuBackgroundImage, 0, 0);
            }
        }

        /**
         *  Го креира главното мени преку бришење на предходно прикажаните контроли 
         *  и динамичко креирање и додавање на соодветни нови контроли на формата.
         */
        public void DrawMainMenu()
        {
            Controls.Clear();

            this.WindowState = FormWindowState.Normal;

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

            Label labelGameScore = CreateLabel(405, 190, 48, 53, Game.CurrentLevel.ToString(), 26);
            Controls.Add(labelGameScore);

            Label labelLevel = CreateLabel(405, 285, 169, 53, "Score:", 26);
            Controls.Add(labelLevel);

            Label labelGameLevel = CreateLabel(405, 330, 169, 53, Game.HighScores.Sum().ToString(), 26);
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

            this.WindowState = FormWindowState.Normal;

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
                buttonLevel.Enabled = i <= Game.CurrentLevel ? true : false;
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
        public Label CreateLabel(int x, int y, int width, int height, string text, int textSize)
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
            String fileName = null;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save the game";
            dialog.Filter = "Bricks Breaker file (*.brb)|*.brb";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }
            if(fileName != null)
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, Game);
                }
            }
        }
        private void BtnLoadGame_Click(object sender, EventArgs e)
        {
            String fileName = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open a game";
            dialog.Filter = "Bricks Breaker file (*.brb)|*.brb";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }
            if (fileName != null)
            {
                try
                {
                    using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        Game = (Game)formatter.Deserialize(stream);
                    }
                }
                catch
                {
                    MessageBox.Show("Could not load file: " + Path.GetFileName(fileName));
                }
            }
            DrawMainMenu();
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            Options options = new Options(this);
            this.SendToBack();
            options.Show();
            options.BringToFront();
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
                SelectedLevel.ID = (int)numLevel;
                SelectedLevel.f1 = this;
                this.MaximumSize = new Size(0, 0);
                this.Size = FULLSCREEN_SIZE;
                this.WindowState = FormWindowState.Maximized;
                this.BackgroundImageLayout = ImageLayout.Tile;
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
                //FOR INSTANT VICTORY UNCOMMENT THE CODE BELLOW (TESTING PURPOSES ONLY!!! DO NOT CHEAT)
                //if (e.KeyData == Keys.W)
                  //  SelectedLevel.BrickListTemp = new List<Brick>();

                if (e.KeyData == Keys.Escape && status == Status.PLAY)
                    ExitLevel();

                SelectedLevel.MoveBouncer(sender, e);
            }
        }
        private void MoveTimer_Tick_1(object sender, EventArgs e)
        {
            Invalidate(true);
        }
        private void LevelCompleted()
        {
            Game.HighScores[SelectedLevel.ID - 1] = Math.Max(SelectedLevel.CurrentScore + (SelectedLevel.PlayerLives * 1000 * (int)Game.GameDifficulty)
                            , Game.HighScores[SelectedLevel.ID - 1]);
            SelectedLevel.ResetLevel();
            MoveTimer.Enabled = false;
            MessageBox.Show("Congratulations!!! You've passed this level.", "Level Complete", MessageBoxButtons.OK);
            DrawSelectLevel();
        }
        private void ExitLevel()
        {
            MoveTimer.Enabled = false;
            if (MessageBox.Show("Are you sure you want to exit the level?", "Exit Level", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SelectedLevel.ResetLevel();
                status = Status.MENU;
                DrawSelectLevel();
            }
            else
            {
                MoveTimer.Enabled = true;
            }
        }
    }
}
