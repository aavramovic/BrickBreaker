using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Level
    {
        public int ID { get; set; }
        private List<Brick> BrickList { get; set; }
        public List<Brick> BrickListTemp { get; set; }
        public Ball BallI { get; set; } // Ball Instance
        private Bouncer BouncerI { get; set; } // Bouncer Instance
        private readonly Color BACKGROUND_COLOR = Color.Black;
        readonly Size FULLSCREEN_SIZE;
        readonly int BOUNCER_WIDTH = 180;
        readonly int BOUNCER_POSITION;
        public Rectangle Border { get; set; }
        public static Random r = new Random();
        public int PlayerLives = 3;
        bool isDead = false;

        public BrickForm f1 { get; set; }
        public Label DeathLabel { get; set; }

        public int Score { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CurrentScore { get; set; }

        public enum Direction
        {
            TOP,
            BOTTOM,
            LEFT,
            RIGHT
        }
        public Level(List<Brick> brickList, Size fullscreen_size, int id)
        {
            ID = id;
            FULLSCREEN_SIZE = fullscreen_size;
            BrickList = brickList;
            BrickListTemp = new List<Brick>(BrickList);

            BallI = new Ball(20, new Point((int)FULLSCREEN_SIZE.Width / 2, FULLSCREEN_SIZE.Height - 400), Color.Orange);
            BOUNCER_POSITION = FULLSCREEN_SIZE.Width / 2 - (BOUNCER_WIDTH) / 2;
            BouncerI = new Bouncer(BOUNCER_WIDTH, 25, new Point(BOUNCER_POSITION, FULLSCREEN_SIZE.Height - 60), Color.White);
            Border = new Rectangle(0, 40, FULLSCREEN_SIZE.Width, FULLSCREEN_SIZE.Height - 72);

            Start = DateTime.Now;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.LightGray, 3);
            g.DrawRectangle(pen, Border);
            foreach (Brick brick in BrickListTemp)
                brick.Draw(g);
            BallI.Draw(g);
            BouncerI.Draw(g);
            if (isDead)
            {
                if (PlayerLives > 0)
                    System.Threading.Thread.Sleep(420);
                else
                    ShowEndMessage();

                isDead = false;
            }
            pen.Dispose();
        }

        public void MoveBouncer(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left && BouncerI.Position.X > Border.Location.X)
            {
                BouncerI.MoveLeft();

            }
            if (e.KeyData == Keys.Right && BouncerI.Position.X + BouncerI.Width < Border.Width)
            {
                BouncerI.MoveRight();
            }
        }

        public void MoveBall(Graphics g)
        {

            List<Brick> BricksLeft = new List<Brick>(BrickListTemp);

            if (BouncerI.HitBox.IntersectsWith(BallI.HitBox))
            {
                float modifier = BouncerI.Position.X + BouncerI.Width / 2 - BallI.Position.X;
                BallI.velocityY = -BallI.velocityY;
                BallI.velocityX = BallI.velocityX - modifier / BouncerI.Width;
            }

            if (BrickListTemp.Count > 0)
                foreach (Brick b in BrickListTemp)
                {
                    if (BallI.HitBox.IntersectsWith(b.HitBox))
                    {
                        if (BallI.HitBox.Top <= b.HitBox.Bottom)
                        {
                            BallI.velocityY = -BallI.velocityY;
                            BallI.Position = new Point(BallI.Position.X, BallI.Position.Y + 5);
                            if (Math.Abs(BallI.velocityY) < 0.5)
                                BallI.ChangeBallVelocity('Y');
                        }
                        if (BallI.HitBox.Bottom <= b.HitBox.Top)
                        {
                            BallI.velocityY = -BallI.velocityY;
                            BallI.Position = new Point(BallI.Position.X, BallI.Position.Y - 5);
                            if (Math.Abs(BallI.velocityY) < 0.5)
                                BallI.ChangeBallVelocity('Y');
                        }
                        if (BallI.HitBox.Left >= b.HitBox.Right)
                        {
                            BallI.velocityX = -BallI.velocityX;
                            BallI.Position = new Point(BallI.Position.X + 2, BallI.Position.Y);
                            if (Math.Abs(BallI.velocityX) < 0.5)
                                BallI.ChangeBallVelocity('X');
                        }
                        if (BallI.HitBox.Right <= b.HitBox.Left)
                        {
                            BallI.velocityX = -BallI.velocityX;

                            BallI.Position = new Point(BallI.Position.X - 2, BallI.Position.Y);
                            if (Math.Abs(BallI.velocityX) < 0.5)
                                BallI.ChangeBallVelocity('X');
                        }
                        if (b.Lives <= 1)
                        {
                            BricksLeft.Remove(b);
                            CurrentScore += 10;
                        }
                        b.Lives -= 1;
                        b.SetColorBasedOnLives();
                        break;
                    }
                }

            int Padding = 3;
            if (BallI.HitBox.Top < Border.Top)
            {
                BallI.velocityY = -BallI.velocityY;
                BallI.Position = new Point(BallI.Position.X, BallI.Position.Y + Padding);
            }

            else if (BallI.HitBox.Bottom > Border.Bottom)
            {
                BallI.ResetProperties(new Point(FULLSCREEN_SIZE.Width / 2, FULLSCREEN_SIZE.Height - 400));
                BouncerI.ResetProperties(new Point(BOUNCER_POSITION, FULLSCREEN_SIZE.Height - 60));
                isDead = true;
                PlayerLives -= 1;
            }
            else if (BallI.HitBox.Left < Border.Left)
            {
                BallI.velocityX = -BallI.velocityX;
                BallI.Position = new Point(BallI.Position.X + Padding, BallI.Position.Y);
            }
            else if (BallI.HitBox.Right > Border.Right)
            {
                BallI.velocityX = -BallI.velocityX;
                BallI.Position = new Point(BallI.Position.X - Padding, BallI.Position.Y);
            }
            if (BallI.Position.X == 22)
                BallI.velocityX = 0.55F;

            BrickListTemp = BricksLeft;
            BallI.Move();
        }

        public void ShowEndMessage()
        {
            End = DateTime.Now;
            Score = BrickList.Count - BrickListTemp.Count;
            f1.MoveTimer.Enabled = false;
            if (MessageBox.Show("Oh, no. It seems like all your lives are gone. Do you want to try again?", Score.ToString(), MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                f1.status = Status.MENU;
                f1.DrawMainMenu();
            }
            ResetLevel();
        }

        public void ResetLevel()
        {
            BrickListTemp = new List<Brick>(BrickList);
            PlayerLives = 3;
            CurrentScore = 0;
        }

        public bool IsCompleted()
        {
            return BrickListTemp.Count == 0;
        }


    }
}
