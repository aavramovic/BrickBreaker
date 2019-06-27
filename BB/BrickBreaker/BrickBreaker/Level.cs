using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
        public Level(List<Brick> brickList, Size fulscreen_size)
        {
            FULLSCREEN_SIZE = fulscreen_size;
            BrickList = brickList;
            BallI = new Ball(20, new Point((int)FULLSCREEN_SIZE.Width/2,FULLSCREEN_SIZE.Height-400), Color.Orange);
            int BOUNCER_WIDTH = 180;
            int BOUNCER_POSITION = (int)FULLSCREEN_SIZE.Width / 2 - (int)(BOUNCER_WIDTH) / 2;
            BouncerI = new Bouncer(BOUNCER_WIDTH, 25, new Point(BOUNCER_POSITION, FULLSCREEN_SIZE.Height - 60), Color.White);
            Border = new Rectangle(0,40,FULLSCREEN_SIZE.Width, FULLSCREEN_SIZE.Height-72);
        }

        public void Draw(Graphics g)
        {
            g.Clear(BACKGROUND_COLOR);

            Pen pen = new Pen(Color.LightGray, 3);
            g.DrawRectangle(pen, Border);
            foreach(Brick brick in BrickList)
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
            foreach(Brick brick in b)
            {
                BrickList.Add(brick);
            }
        }

        public void MoveBouncer(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Left && BouncerI.Position.X > Border.Location.X)
            {
                BouncerI.MoveLeft();
                
            }
            if(e.KeyData == Keys.Right && BouncerI.Position.X+BouncerI.Width < Border.Width)
            {
                BouncerI.MoveRight();
            }
        }

        public void MoveBall()
        {
        if (CheckCollision())
            {
                //Tuka ke odi direction change spored centri sth sth i so ova ke se istestira dali e dobra mathot za dvizenjeto vo ball
                BallI.Speed = BallI.Speed * (-1);
            }
            BallI.Move();  
        }

        private bool CheckCollision()
        {
            bool doesCollide = false;
            List<Brick> BricksLeft = new List<Brick>();
            if (BallI.HitBox.IntersectsWith(BouncerI.HitBox))
                doesCollide = true;
            foreach(Brick b in BrickList)
            {
                //Dali e podobro ovde namesto da se stava pa vadi brick da ima dva ifa obratni sho ne go dodava ako intersecta valjda ne
                BricksLeft.Add(b);
                if (BallI.HitBox.IntersectsWith(b.HitBox))
                {

                    doesCollide = true;
                    BricksLeft.Remove(b);
                }
            }
            if (BallI.HitBox.Top < Border.Top || BallI.HitBox.Left < Border.Left || BallI.HitBox.Right > Border.Right)
                doesCollide = true;

            /**
            * Za dolu ne se proveruva deka tamu ke se resetira ke stavime poseben metod sho ke odzema zivoti moze i gore srcenca sho 
            * gi snemuva 
            * Ima bug ako vlezesh so bouncerot vo topceto kako sho pagja od strana go cuva vo mesto
            */
            BrickList = BricksLeft;
            return doesCollide;
        }
    }
}
