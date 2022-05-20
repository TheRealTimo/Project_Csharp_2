using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ConflictGame
{
    class Character
    {
        Texture2D texture;

        Vector2 position;
        Vector2 velocity;

        bool hasJumped;

        private GraphicsDeviceManager _graphics;

        public Character(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            hasJumped = true;
        }

        protected void Initialize()
        {
            // TODO: Add your initialization logic here

            position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);            
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                velocity.X = 3f;

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                velocity.X = -3f;

            else
                velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                hasJumped = true;
            }

            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }

            if(position.X + texture.Height >= 150)
            {
                hasJumped = false; 
            }

            if (hasJumped == false)
            {
                velocity.Y = 0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
