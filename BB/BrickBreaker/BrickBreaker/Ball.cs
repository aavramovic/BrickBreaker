using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Ball
    {
        public float Radius { get; set; }
        public Point Position { get; set; }
        public Color Coloring { get; set; }
        //Optional
        public double Speed { get; set; }

        
        public Ball(float radius, Point position, Color coloring)
        {
            Radius = radius;
            Position = position;
            Coloring = coloring;
            //TODO: add speed to constructor once the move method is implemented
            // or maybe even make it a static speed
            Speed = 0;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);
        }
        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
