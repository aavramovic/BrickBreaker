using System;
using System.Drawing;

namespace BrickBreaker
{
    public class Ball
    {
        public int Radius { get; set; }
        public Point Position { get; set; }
        public Color Coloring { get; set; }
        public double Velocity { get; set; }
        public double Angle { get; set; }
        private double StartingDouble { get; set; }
        public static Random r = new Random();
        public float velocityX;
        public float velocityY;
        public Rectangle HitBox { get; set; }


        public Ball(int radius, Point position, Color coloring)
        {
            Radius = radius;
            Position = position;
            Coloring = coloring;
            Velocity = 9;
            StartingDouble = 0.25;
            Angle = StartingDouble*2* Math.PI;
            velocityX = (float)(Math.Cos(Angle) * Velocity);
            velocityY = (float)(Math.Sin(Angle) * Velocity);

            HitBox = new Rectangle(Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);
            brush.Dispose();

            //Testing Hitboxes
            /*Pen p = new Pen(Color.Red, 2);
            g.DrawRectangle(p, HitBox);
            p.Dispose();*/
        }
        public void Move()
        {
            double BallX = Position.X + velocityX;
            double BallY = Position.Y + velocityY;

            Position = new Point((int)(BallX + velocityX), (int)(BallY + velocityY));
            HitBox = new Rectangle(Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
        }
        public void ResetProperties(Point p)
        {
            Position = p;
            Velocity = this.Velocity;
            StartingDouble = 0.75;
            Angle = StartingDouble * 2 * Math.PI;
            velocityX = (float)(Math.Cos(Angle) * Velocity);
            velocityY = (float)(Math.Sin(Angle) * Velocity);

            HitBox = new Rectangle(Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
        }
        public void ChangeBallVelocity(Char c)
        {
            float k = 0.6F;
            if (c == 'X')
                if (velocityX < 0)
                    velocityX = -k;
                else
                    velocityX = k;
            if(c== 'Y')
                if (velocityY < 0)
                    velocityY = -k;
                else
                    velocityY = k;
            Position = new Point(Position.X, Position.Y + 5);
        }
    }
}
