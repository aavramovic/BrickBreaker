using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Level
    {
        private List<Brick> BrickList { get; set; }
        private Ball BallI { get; set; } // Ball Instance
        private Bouncer BouncerI { get; set; } // Bouncer Instance
        private readonly Color BACKGROUND_COLOR = Color.Black;
        readonly Size FULLSCREEN_SIZE;
        private Rectangle Border;


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

        public void Draw(Graphics g)
        {
            g.Clear(BACKGROUND_COLOR);

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

        public void MoveBall()
        {
            CheckCollision();
        }

        private void CheckCollision()
        {
            List<Brick> BricksLeft = new List<Brick>();


            foreach (Brick b in BrickList)
                BricksLeft.Add(b);

            if (BouncerI.HitBox.IntersectsWith(BallI.HitBox))
            {
                BallI.velocityY = -BallI.velocityY;
            }

            if (BrickList.Count > 0)
                foreach (Brick b in BrickList)
                {
                    if (BallI.HitBox.IntersectsWith(b.HitBox))
                    {
                        if (BallI.HitBox.Top <= b.HitBox.Bottom)
                        {
                            BallI.velocityY = -BallI.velocityY;
                            BallI.Position = new Point(BallI.Position.X, BallI.Position.Y + 2);
                        }
                        if (BallI.HitBox.Bottom >= b.HitBox.Top)
                        {
                            BallI.velocityY = -BallI.velocityY;
                            BallI.Position = new Point(BallI.Position.X, BallI.Position.Y - 2);
                        }
                        if (BallI.HitBox.Left <= b.HitBox.Right)
                        {
                            BallI.velocityX = -BallI.velocityX;
                            BallI.Position = new Point(BallI.Position.X + 2, BallI.Position.Y);

                        }
                        if (BallI.HitBox.Right >= b.HitBox.Left)
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

            if (BallI.HitBox.Top < Border.Top)
            {
                BallI.velocityY = -BallI.velocityY;
                BallI.Position = new Point(BallI.Position.X, BallI.Position.Y + 2);
            }
            if (BallI.HitBox.Bottom > Border.Bottom)
            {
                BallI.velocityY = -BallI.velocityY;
                BallI.Position = new Point(BallI.Position.X, BallI.Position.Y - 2);
            }
            if (BallI.HitBox.Left < Border.Left)
            {
                BallI.velocityX = -BallI.velocityX;
                BallI.Position = new Point(BallI.Position.X + 2, BallI.Position.Y);
            }
            if (BallI.HitBox.Right > Border.Right)
            {
                BallI.velocityX = -BallI.velocityX;
                BallI.Position = new Point(BallI.Position.X - 2, BallI.Position.Y);
            }


            /**
            * Za dolu ne se proveruva deka tamu ke se resetira ke stavime poseben metod sho ke odzema zivoti moze i gore srcenca sho 
            * gi snemuva 
            * Ima bug ako vlezesh so bouncerot vo topceto kako sho pagja od strana go cuva vo mesto
            */

            BrickList = BricksLeft;

            BallI.Move();
        }
    }
}
