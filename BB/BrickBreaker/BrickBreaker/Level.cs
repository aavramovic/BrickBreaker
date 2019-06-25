using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Level
    {
        List<Brick> BrickList { get; set; }
        Ball BallInstance { get; set; }
        Bouncer BouncerInstance { get; set; }

        private readonly Color BACKGROUND_COLOR = Color.Black;

        public Level(List<Brick> brickList, Ball ballInstance, Bouncer bouncerInstance)
        {
            BrickList = brickList;
            BallInstance = ballInstance;
            BouncerInstance = bouncerInstance;
        }

        public void Draw(Graphics g)
        {
            g.Clear(BACKGROUND_COLOR);

            foreach(Brick brick in BrickList)
            {
                brick.Draw(g);
            }
            BallInstance.Draw(g);
            BouncerInstance.Draw(g);

            //throw new NotImplementedException("Draw Level");
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
    }
}
