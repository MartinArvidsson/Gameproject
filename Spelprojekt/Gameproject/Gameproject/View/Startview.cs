using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Model;
namespace View
{
    class Startview
    {

        private ContentManager content;
        private Camera camera;
        private SpriteBatch spritebatch;
        private BallSimulation ballsim;
        private GraphicsDeviceManager graphics;

        private Texture2D balltexture;
        private Texture2D ballbackground;
        private Texture2D playerbackground;
        private Vector2 ballcenter;
        private Vector2 centerrect;
        private Rectangle ballrectangle;
        private Rectangle playerrectangle;
        private int ballarea;
        private int playerarea;
        private int bordersize;
        public Startview(ContentManager _content, Camera _camera, SpriteBatch _spritebatch, BallSimulation _ballsim, GraphicsDeviceManager _graphics)
        {
            content = _content;
            camera = _camera;
            spritebatch = _spritebatch;
            ballsim = _ballsim;
            graphics = _graphics;

            playerarea = camera.ReturnFieldsize();
            ballarea = (int)Math.Ceiling(camera.ReturnFieldsize() * 0.85f);
            bordersize = camera.ReturnBorder();

            ballrectangle = new Rectangle(bordersize, bordersize, ballarea, ballarea);
            playerrectangle = new Rectangle(bordersize, bordersize, playerarea, playerarea);
            balltexture = content.Load<Texture2D>("BALL");
            ballcenter = new Vector2(balltexture.Width / 2, balltexture.Height / 2);
            ballbackground = new Texture2D(graphics.GraphicsDevice, 1, 1);
            ballbackground.SetData(new Color[] { Color.WhiteSmoke });

            playerbackground = new Texture2D(graphics.GraphicsDevice, 1, 1);
            playerbackground.SetData(new Color[] { Color.Black });
        }

        public void Draw(float elapsedtime)
        {
            spritebatch.Begin(SpriteSortMode.FrontToBack);

            DrawBalls();

            spritebatch.End();
        }

        public void DrawBalls()
        {
            centerrect = new Vector2(ballrectangle.Width / 2,ballrectangle.Height / 2);

            Vector2 rectpos = new Vector2(0.5f, 0.5f);

            float rectscale = camera.Scale(0.85f, ballarea);

            spritebatch.Draw(ballbackground, camera.Converttovisualcoords(rectpos, rectscale), ballrectangle, Color.White, 0, centerrect, rectscale, SpriteEffects.None, 0.8f);
            spritebatch.Draw(playerbackground, playerrectangle, Color.White);
            
            foreach (Ball ball in ballsim.getballs())
            {               
                Vector2 currentballpos = ball.getballpos;

                float scale = camera.Scale(ball.getballradius * 2, balltexture.Width);

                var ballvisualpos = camera.Converttovisualcoords(currentballpos, scale);

                spritebatch.Draw(balltexture, ballvisualpos, null, Color.White, 0, ballcenter, scale, SpriteEffects.None, 1f);
            }
        }

        public Vector2 getrect()
        {
            Vector2 convertedcoords = new Vector2(ballrectangle.Width, ballrectangle.Height);
            return camera.convertologicalcoords(convertedcoords);
        }
    }
}
