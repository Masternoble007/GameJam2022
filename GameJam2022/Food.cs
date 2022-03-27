using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using GameJam2022.Collisions;

namespace GameJam2022
{
    public class Food
    {
        private Vector2 position;
        private Texture2D texture;
        private BoundingCircle bounds;

        public int posX { get; set; }
        public int posY { get; set; }

        public BoundingCircle Bounds => bounds;

        public Food(Vector2 position)
        {
            this.position = position;
            this.bounds = new BoundingCircle(position + new Vector2(5,5),5);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("SomeObject");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
