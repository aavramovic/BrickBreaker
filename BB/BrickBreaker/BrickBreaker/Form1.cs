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
        MAIN_MENU,
        SELECT_LEVEL,
        PLAY
    }
    public partial class Form1 : Form
    {
        private Game game;
        private Status status;
        private string fileName;
        private Level level;

        //!IMPORTANT
        //Sakam vo levelForm da go premestam ova so listata i fill level list metodot
        //
        private List<Level> LevelList;

        private LevelForm SelectedLevel;
        private readonly int LEVEL_BUTTON = 80;
        private readonly Size MAX_SCREEN_SIZE;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            MAX_SCREEN_SIZE = new Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height);
            game = new Game();
            LevelList = new List<Level>();
            DrawMainMenu();

            FillLevelList();
        }

        private void FillLevelList()
        {
            List<Brick> brickList = CreateBrickList();
            
            Point ballPosition = new Point(MAX_SCREEN_SIZE.Height - 200, (int)(MAX_SCREEN_SIZE.Width / 2));
            Ball ball = new Ball(20, ballPosition, Color.White);

            Point bouncerPosition = new Point(MAX_SCREEN_SIZE.Height - 100, (int)(MAX_SCREEN_SIZE.Width / 2));
            Bouncer bouncer = new Bouncer(70, 20, bouncerPosition, Color.White);

            Level level1 = new Level(brickList, ball, bouncer);
            LevelList.Add(level1);

            /* TODO: add levels and make the level constructor take arguments for positions of bricks etc*/
            //throw new NotImplementedException("Create Levels");
        }

        private List<Brick> CreateBrickList()
        {
            //Да се стави најлева точка Point и според неа да се додаваат до крај десно точки и може и редици евентуално
            List<Brick> brickList = new List<Brick>();
            Point brickPosition = new Point(300, (int)(MAX_SCREEN_SIZE.Width / 2));
            Brick brick = new Brick(60, 10,brickPosition, Color.Red, 3);
            return brickList;
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
            Controls.Clear();

            Button buttonPlay = CreateButton(80, 45, 225, 55, "Play");
            buttonPlay.Click += new EventHandler(BtnPlay_Click);
            Controls.Add(buttonPlay);

            Button buttonSaveGame = CreateButton(125, 115, 225, 55, "Save Game");
            buttonSaveGame.Click += new EventHandler(BtnSaveGame_Click);
            Controls.Add(buttonSaveGame);

            Button buttonLoadGame = CreateButton(80, 185, 225, 55, "Load Game");
            buttonLoadGame.Click += new EventHandler(BtnLoadGame_Click);
            Controls.Add(buttonLoadGame);

            Button buttonOptions = CreateButton(125, 255, 225, 55, "Options");
            buttonOptions.Click += new EventHandler(BtnOptions_Click);
            Controls.Add(buttonOptions);

            Button buttonQuit = CreateButton(80, 325, 225, 55, "Quit");
            buttonQuit.Click += new EventHandler(BtnQuit_Click);
            Controls.Add(buttonQuit);

            Label labelScore = CreateLabel(405, 95, 169, 53, "Level:");
            Controls.Add(labelScore);

            Label labelGameScore = CreateLabel(405, 140, 48, 53, game.CurrentLevel.ToString());
            Controls.Add(labelGameScore);

            Label labelLevel = CreateLabel(405, 235, 169, 53, "Score:");
            Controls.Add(labelLevel);

            Label labelGameLevel = CreateLabel(405, 280, 169, 53, game.CurrentScore.ToString());
            Controls.Add(labelGameLevel);

            status = Status.MAIN_MENU;
        }

        private void DrawSelectLevel()
        {
            Controls.Clear();

            
            
            Button level1 = CreateButton(40, 40, LEVEL_BUTTON, LEVEL_BUTTON, "Level 1");
            level1.Tag = "1";
            level1.Click += new EventHandler(LevelSelect_Click);
            Controls.Add(level1);
            
            Button level2 = CreateButton(140, 40, LEVEL_BUTTON, LEVEL_BUTTON, "Level 2");
            level2.Tag = "2";
            level2.Click += new EventHandler(LevelSelect_Click);
            Controls.Add(level2);
            
            status = Status.SELECT_LEVEL;
            // TODO: poveke leveli
            // TODO: back button sho ke go vika draw main menu 
            // throw new NotImplementedException();
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
            newLabel.BackColor = Color.Black;
            newLabel.ForeColor = Color.White;
            newLabel.Font = new Font("Showcard Gothic", 26, FontStyle.Regular);
            newLabel.Text = text;
            return newLabel;
        }
        private void LevelSelect_Click(object sender, EventArgs e)
        {
            int LevelIndex = Convert.ToInt32(((Button)sender).Tag);
            level = LevelList[LevelIndex-1];
            SelectedLevel = new LevelForm(level){ Size = MAX_SCREEN_SIZE };
            SelectedLevel.Show();
            
            //throw new NotImplementedException();
        }
        
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            //open menu for selecting level
            DrawSelectLevel();
            
            //throw new NotImplementedException("Play");
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
