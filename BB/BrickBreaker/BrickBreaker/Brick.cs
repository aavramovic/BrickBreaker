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
        public float Width { get; set; }
        public float Height { get; set; }
        public Point Position { get; set; }
        public Color Coloring { get; set; }
        public int Lives { get; set; }

        public Brick(float width, float height, Point position, Color coloring, int lives)
        {
            Width = width;
            Height = height;
            Position = position;
            Coloring = coloring;
            Lives = lives;
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Coloring);
            g.FillRectangle(brush, Position.X, Position.Y, Width, Height);
        }
    }
}
