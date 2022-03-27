using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2022
{
   public class PlayerSnake : DrawableGameComponent
    {
        public const int updateInterval = 48;
        public int size = 0;
        public int score { get; set; } = 0;
        public int posX { get; set; }
        public int posY { get; set; }
        public int oldPosX = 0;
        public int oldPosY = 0;
        public int dirX { get; set; } = 1;
        public int dirY { get; set; } = 0;

        public int millisecfromLastUpdate = 0;

        public SpriteBatch _spriteBatch;
        public Texture2D pixel;
        public bool run { get; set; } = true;

        private List<Rectangle> tails;
        

        public PlayerSnake(Game game, GraphicsDevice graphics, SpriteBatch spritebatch, int size) : base(game)
        {
            this.size = size;
            _spriteBatch = spritebatch;

            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] { Color.Purple});

            posX = graphics.Viewport.Width / 2;
            posY = graphics.Viewport.Height / 2;

            tails = new List<Rectangle>();
            tails.Add(new Rectangle(posX, posY, size, size));
        }

        public override void Update(GameTime gametime)
        {
            millisecfromLastUpdate += gametime.ElapsedGameTime.Milliseconds;
            if (millisecfromLastUpdate >= updateInterval && run)
            {
                millisecfromLastUpdate = 0;

                oldPosX = posX;
                oldPosY = posY;

                posX = posX + dirX * size;
                posY = posY + dirY * size;

                if (tails.Count > 1)
                {
                    for (int i = tails.Count - 1; i > 0; i-- )
                    {
                        tails[i] = new Rectangle(tails[i-1].X, tails[i-1].Y, size, size);
                    }
                }
            }
            tails[0] = new Rectangle(posX, posY, size, size);


            base.Update(gametime);
        }

        public void Addtail()
        {
            tails.Add(new Rectangle(posX, posY, size, size));
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            if (run) {
                foreach (var item in tails)
                {
                    _spriteBatch.Draw(pixel, new Rectangle(item.X - 1, item.Y - 1, size + 2, size + 2), Color.Black);
                    _spriteBatch.Draw(pixel, item, Color.White);
                }
            }
            else
            {
                foreach (var item in tails)
                {
                    _spriteBatch.Draw(pixel, new Rectangle(item.X - 1, item.Y - 1, size + 2, size + 2), Color.Black);
                    _spriteBatch.Draw(pixel, item, Color.Red);
                }
            }
           // _spriteBatch.Draw(pixel, new Rectangle(), Color.White);

            _spriteBatch.End();
        }

    }
}
