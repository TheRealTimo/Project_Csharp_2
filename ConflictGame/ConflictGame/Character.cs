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

        private GraphicsDeviceManager _graphics;
        

        bool hasJumped;

        public Character(Texture2D newTexture, Vector2 newPosition, GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
            texture = newTexture;
            position = newPosition;
            hasJumped = true;
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
                velocity.Y += 0.25f * i;
            }

            if(position.Y + texture.Height >= _graphics.PreferredBackBufferHeight)
            {
                hasJumped = false; 
            }

            if (hasJumped == false)
            {
                velocity.Y = 0f;
            }

            if (position.X > _graphics.PreferredBackBufferWidth - texture.Width / 2) //Checks that the ball cannot leave the game area
                position.X = _graphics.PreferredBackBufferWidth - texture.Width / 2;
            else if (position.X < texture.Width / 2)
                position.X = texture.Width / 2;

            if (position.Y > _graphics.PreferredBackBufferHeight - texture.Height / 2)
                position.Y = _graphics.PreferredBackBufferHeight - texture.Height / 2;
            else if (position.Y < texture.Height / 2)
                position.Y = texture.Height / 2;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,
                position,
                null, //source rectangle
                Color.White,
                0f, // rotation
                new Vector2(texture.Width / 2, texture.Height / 2),
                Vector2.One, //scale
                SpriteEffects.None,
                0f // layer depth
                );
        }
    }
}
