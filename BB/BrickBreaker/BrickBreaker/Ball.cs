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
        public int Radius { get; set; }
        public Point Position { get; set; }
        public Color Coloring { get; set; }
        public int Speed { get; set; }
        public int DirectionAngle { get; set; }
        public Rectangle HitBox { get; set; }


        public Ball(int radius, Point position, Color coloring)
        {
            Radius = radius;
            Position = position;
            Coloring = coloring;
            //TODO: add speed to constructor once the move method is implemented
            // or maybe even make it a static speed
            Speed = 1;
            DirectionAngle = 180;
            HitBox = new Rectangle(Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);

            //Testing Hitboxes
            Pen p = new Pen(Color.Red, 2);
            g.DrawRectangle(p, HitBox);
        }
        public void Move()
        {
            //Definitivno treba da se smeni ova
            int BallX = Position.X + (DirectionAngle % 180 ) * Speed;
            int BallY = Position.Y + (DirectionAngle / 180 ) * Speed;
            Position = new Point(BallX, BallY);
            HitBox = new Rectangle(Position.X - Radius, Position.Y - Radius, Radius*2-1, Radius*2-1);
        }
    }
}
