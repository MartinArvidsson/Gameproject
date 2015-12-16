using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class BallSimulation
    {
        private List<Ball> balls = new List<Ball>();
        public Ball ball;
        Random rand = new Random();
        int numberofballs = 4;
        public BallSimulation()
        {
            for (int i = 0; i < numberofballs; i++)
            {
                balls.Add(ball = new Ball(rand)); //new ball object
            }
        }

        public void UpdateBall(float Elapsedtime,Vector2 convertedcoords)
        {
            foreach (Ball ball in balls)
            {
                hitwall(ball, convertedcoords);
                ball.updatecurrentpos(Elapsedtime);
            }
        }
        public void hitwall(Ball ball, Vector2 convertedcoords)
        {

            if ((ball.BallPos.X + ball.getballradius) > convertedcoords.X || (ball.BallPos.X - ball.getballradius) < 0.15) //If ball bounces <---->
            {
                ball.setballVelocityX();
            }
            if ((ball.BallPos.Y + ball.getballradius) > convertedcoords.Y || (ball.BallPos.Y - ball.getballradius) < 0.15) //If ball bounces ^ v
            {
                ball.setballVelocityY();
            }

        }

        public List<Ball> getballs()
        {
            return balls;
        }
    }
}