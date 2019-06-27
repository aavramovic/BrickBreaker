using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Brick
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Position { get; set; }
        public Color Coloring { get; set; }
        public int Lives { get; set; }
        public Rectangle HitBox { get; set; }

        public Brick(int width, int height, Point position, Color coloring, int lives)
        {
            Width = width;
            Height = height;
            Position = position;
            Coloring = coloring;
            Lives = lives;
            HitBox = new Rectangle(Position.X, Position.Y, Width, Height);
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Coloring);
            g.FillRectangle(brush, Position.X, Position.Y, Width, Height);
            //Testing Hitboxes
            Pen p = new Pen(Color.Red, 2);
            g.DrawRectangle(p, HitBox);
            p.Dispose();
        }
    }
}
