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
        public Texture2D texture;

        public Vector2 position;
        Vector2 velocity;

        private GraphicsDeviceManager _graphics;
        

        public bool hasJumped;

        public Character(Texture2D newTexture, Vector2 newPosition, GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
            texture = newTexture;
            position = newPosition;
            hasJumped = true;
        }

        public void Jump()
        {
            if (hasJumped == false) {
                position.Y -= 20f;
                velocity.Y = -10f;
                hasJumped = true;
            }
        }
        public void MoveRight()
        {
            velocity.X = 3f;
        }
        public void MoveLeft()
        {
            velocity.X = -3f;
        }

        public void OffPlat()
        {
            if (position.Y + texture.Height < _graphics.PreferredBackBufferHeight)
            {
                hasJumped = true;
            }
        }

        public void PlatStand()
        {
            velocity.Y = 0;
            hasJumped = false;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                MoveRight();

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                MoveLeft();

            else
                velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Jump();
            }

            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.20f * i;
            }
            else
            {
                velocity.Y = 5f;
            }

            if (position.Y + texture.Height >= _graphics.PreferredBackBufferHeight)
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
