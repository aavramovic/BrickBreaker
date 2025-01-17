﻿using System;
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
        public Game.BrickColor BrickColor { get; set; }
        public int Lives { get; set; }
        public Rectangle HitBox { get; set; }

        public Brick(int width, int height, Point position, Game.BrickColor brickColor,int lives)
        {
            Width = width;
            Height = height;
            Position = position;
            Lives = lives;
            BrickColor = brickColor;
            SetColorBasedOnLives();
            HitBox = new Rectangle(Position.X, Position.Y, Width, Height);
        }

        public void SetColorBasedOnLives()
        {
            if (Lives < 1)
                Lives = Level.r.Next(1, 4);
            if (BrickColor == Game.BrickColor.RED)
            {
                if (Lives == 3)
                    Coloring = Color.FromArgb(100, 00, 00);
                else if (Lives == 2)
                    Coloring = Color.FromArgb(128, 00, 00);
                else if (Lives == 1)
                    Coloring = Color.FromArgb(238, 144, 144);
            }
            else if (BrickColor == Game.BrickColor.GREEN)
            {
                if (Lives == 3)
                    Coloring = Color.FromArgb(00, 100, 00);
                else if (Lives == 2)
                    Coloring = Color.FromArgb(00, 128, 00);
                else if (Lives == 1)
                    Coloring = Color.FromArgb(144, 238, 144);
            }
            else if (BrickColor == Game.BrickColor.BLUE)
            {
                if (Lives == 3)
                    Coloring = Color.FromArgb(00, 00, 100);
                else if (Lives == 2)
                    Coloring = Color.FromArgb(00, 00, 128);
                else if (Lives == 1)
                    Coloring = Color.FromArgb(144, 144, 238);
            }
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Coloring);
            g.FillRectangle(brush, Position.X, Position.Y, Width, Height);
            brush.Dispose();
            Pen p = new Pen(Color.DimGray, 1);
            g.DrawRectangle(p, HitBox);
            p.Dispose();
        }
    }
}
