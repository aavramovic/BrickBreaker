using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Bouncer
    {

        public int Width { get; set; }
        public int Height { get; set; }
        public Point Position { get; set; }
        Color Coloring { get; set; }
        public int Speed { get; set; }
        public Rectangle HitBox { get; set; }


        public Bouncer(int width, int height, Point position, Color coloring)
        {
            Width = width;
            Height = height;
            Position = position;
            Coloring = coloring;
            Speed = 90;
            HitBox = new Rectangle(Position.X, Position.Y, Width, Height);
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Coloring);
            g.FillRectangle(brush, Position.X, Position.Y, Width, Height);
            brush.Dispose();

            //Testing Hitboxes
            Pen p = new Pen(Color.Red, 2);
            g.DrawRectangle(p, HitBox);
            p.Dispose();
        }

        internal void MoveLeft()
        {
            Position = new Point(Position.X - Speed, Position.Y);
            MoveHitBox();
        }

        internal void MoveRight()
        {
            Position = new Point(Position.X + Speed, Position.Y);
            MoveHitBox();
        }

        private void MoveHitBox()
        {
            HitBox = new Rectangle(Position.X, Position.Y, Width, Height);
        }
    }
}
