using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Level
    {
        private List<Brick> BrickList { get; set; }
        public Ball BallI { get; set; } // Ball Instance
        private Bouncer BouncerI { get; set; } // Bouncer Instance
        private readonly Color BACKGROUND_COLOR = Color.Black;
        readonly Size FULLSCREEN_SIZE;
        private Rectangle Border;
        public static Random r = new Random();
        bool isDead = false;


        public BrickForm f1;
        public Label DeathLabel;
        
        public enum Direction
        {
            TOP,
            BOTTOM,
            LEFT,
            RIGHT
        }
        public Level(List<Brick> brickList, Size fulscreen_size)
        {
            FULLSCREEN_SIZE = fulscreen_size;
            BrickList = brickList;
            BallI = new Ball(20, new Point((int)FULLSCREEN_SIZE.Width / 2, FULLSCREEN_SIZE.Height - 400), Color.Orange);
            int BOUNCER_WIDTH = 180;
            int BOUNCER_POSITION = (int)FULLSCREEN_SIZE.Width / 2 - (int)(BOUNCER_WIDTH) / 2;
            BouncerI = new Bouncer(BOUNCER_WIDTH, 25, new Point(BOUNCER_POSITION, FULLSCREEN_SIZE.Height - 60), Color.White);
            Border = new Rectangle(0, 40, FULLSCREEN_SIZE.Width, FULLSCREEN_SIZE.Height - 72);

            
        }
        //WORK IN PROGRESS
        public void DrawDeathTimer(Graphics g)
        {
            //
            g.Clear(Color.Yellow) ;
            System.Threading.Thread.Sleep(100);

            g.DrawString("3", new Font("Arial", 120)
                      , new SolidBrush(Color.White)
                      , new Point((int)FULLSCREEN_SIZE.Width / 2 - 40, FULLSCREEN_SIZE.Height - 440));
            System.Threading.Thread.Sleep(200);
            isDead = false;
        }
        public void Draw(Graphics g)
        {
            if (isDead)
            {
                DrawDeathTimer(g);

            }

            Pen pen = new Pen(Color.LightGray, 3);
            g.DrawRectangle(pen, Border);
            foreach (Brick brick in BrickList)
            {
                brick.Draw(g);
            }
            BallI.Draw(g);
            BouncerI.Draw(g);
        }

        public void AddBrick(Brick b)
        {
            BrickList.Add(b);
        }
        public void AddBricks(List<Brick> b)
        {
            foreach (Brick brick in b)
            {
                BrickList.Add(brick);
            }
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
            List<Brick> BricksLeft = new List<Brick>();


            foreach (Brick b in BrickList)
                BricksLeft.Add(b);
            
            if (BouncerI.HitBox.IntersectsWith(BallI.HitBox))
            {
                float modifier = BouncerI.Position.X + BouncerI.Width / 2 - BallI.Position.X;
                BallI.velocityY = -BallI.velocityY;
                BallI.velocityX = BallI.velocityX-modifier / BouncerI.Width;
            }

            if (BrickList.Count > 0)
                foreach (Brick b in BrickList)
                {
                    if (BallI.HitBox.IntersectsWith(b.HitBox))
                    {
                        if (BallI.HitBox.Top <= b.HitBox.Bottom)
                        {
                            BallI.velocityY = -BallI.velocityY;
                            BallI.Position = new Point(BallI.Position.X, BallI.Position.Y + 5);
                        }
                        if (BallI.HitBox.Bottom <= b.HitBox.Top)
                        {
                            BallI.velocityY = -BallI.velocityY;
                            BallI.Position = new Point(BallI.Position.X, BallI.Position.Y - 5);
                        }
                        if (BallI.HitBox.Left >= b.HitBox.Right)
                        {
                            BallI.velocityX = -BallI.velocityX;
                            BallI.Position = new Point(BallI.Position.X + 2, BallI.Position.Y);
                        }
                        if (BallI.HitBox.Right <= b.HitBox.Left)
                        {
                            BallI.velocityX = -BallI.velocityX;
                            BallI.Position = new Point(BallI.Position.X - 2, BallI.Position.Y);
                        }
                        if (b.Lives == 1)
                            BricksLeft.Remove(b);
                        b.Lives -= 1;
                        break;
                    }
                }
            int Padding = 3;
            if (BallI.HitBox.Top < Border.Top)
            {
                BallI.velocityY = -BallI.velocityY ;
                BallI.Position = new Point(BallI.Position.X, BallI.Position.Y + Padding);
            }
            ///***WORK IN PROGRESS***///
            else if (BallI.HitBox.Bottom > Border.Bottom)
            {
                BallI.ResetProperties(new Point((int)FULLSCREEN_SIZE.Width / 2, FULLSCREEN_SIZE.Height - 400));
                //treba da se sredi nekako zatoa shto crtanjeto ispagja koe se nacrta prvo gi pokriva drugite i ne se gleda tajmerot
                DrawDeathTimer(g);
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

            /**
            * Za dolu ne se proveruva deka tamu ke se resetira ke stavime poseben metod sho ke odzema zivoti moze i gore srcenca sho 
            * gi snemuva 
            * Ima bug ako vlezesh so bouncerot vo topceto kako sho pagja od strana go cuva vo mesto
            */

            BrickList = BricksLeft;
            //BrickList = new List<Brick>();

            BallI.Move();
        }
    }
}
