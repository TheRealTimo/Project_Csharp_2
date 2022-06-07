using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConflictGame
{
    class Player
    {
        private Texture2D texture;
        public Vector2 position = new Vector2(640, 304);
        private Vector2 velocity;
        private Rectangle rectangle;

        private bool hasJumped = false;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Player() { }

        public void Load(ContentManager Content)
        {
            velocity.Y = 1f;
            texture = Content.Load<Texture2D>("Player/azazel3");           
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            Input(gameTime);

            if (velocity.Y < 20 )
                velocity.Y += 0.4f;
        }

        private void Input(GameTime gameTime)
        { 
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else velocity.X = 0f;

            if(Keyboard.GetState().IsKeyDown(Keys.Space)) 
            {
                Jump();
            }
        }
        public void Jump()
        {
            if (hasJumped == false)
            {
                position.Y -= 2f;
                velocity.Y = -12f;
                hasJumped = true;
            }
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.Intersects(newRectangle)) {
                if (rectangle.TouchTopOf(newRectangle))
                {
                    rectangle.Y = newRectangle.Y - rectangle.Height;
                    velocity.Y = 0f;
                    hasJumped = false;
                }

                else if (rectangle.TouchLeftOf(newRectangle))
                {
                    position.X = newRectangle.X - rectangle.Width - 2;
                }

                else if (rectangle.TouchBottomOf(newRectangle))
                {
                    position.Y = newRectangle.Top - rectangle.Height + 2;
                    velocity.Y = -5f;
                }
                else if(position.X < newRectangle.Right && position.X > newRectangle.Left)
                {
                    position.X = newRectangle.Right;
                }
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (rectangle.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
