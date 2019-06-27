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
        private Ball BallInstance { get; set; }
        private Bouncer BouncerInstance { get; set; }
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
            BallInstance = new Ball(20, new Point((int)FULLSCREEN_SIZE.Width/2,FULLSCREEN_SIZE.Height-400), Color.Orange);
            int BOUNCER_WIDTH = 180;
            int BOUNCER_POSITION = (int)FULLSCREEN_SIZE.Width / 2 - (int)(BOUNCER_WIDTH) / 2;
            BouncerInstance = new Bouncer(BOUNCER_WIDTH, 25, new Point(BOUNCER_POSITION, FULLSCREEN_SIZE.Height - 60), Color.White);
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
            BallInstance.Draw(g);
            BouncerInstance.Draw(g);
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
            if(e.KeyData == Keys.Left && BouncerInstance.Position.X > Border.Location.X)
            {              
                BouncerInstance.Position = new Point(BouncerInstance.Position.X - BouncerInstance.Speed, BouncerInstance.Position.Y);
            }
            if(e.KeyData == Keys.Right && BouncerInstance.Position.X+BouncerInstance.Width < Border.Width)
            {
                BouncerInstance.Position = new Point(BouncerInstance.Position.X + BouncerInstance.Speed, BouncerInstance.Position.Y);
            }
        }

        public void MoveBall()
        {
            //BallInstance.Position = 
        }
    }
}
