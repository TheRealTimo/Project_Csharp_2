using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConflictGame
{
    class Player
    {
        public AnimatedSprite sprite;
        public int height = 32;
        public int width = 22;
        public Vector2 position = new Vector2(640, 304);
        private Vector2 velocity;
        private Rectangle rectangle;
        public int attackPressedTime = 0;

        private bool hasJumped = false;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Player() { }

        public void Load(AnimatedSprite newSprite, ContentManager Content)
        {
            velocity.Y = 1f; sprite = newSprite;
            hasJumped = true;       
        }
        public void Jump()
        {
            if (hasJumped == false)
            {
                sprite.Play("jump");
                position.Y -= 20f;
                velocity.Y = -10f;
                hasJumped = true;
            }
        }

        public void Punch()
        {
            if (attackPressedTime == 0)
            {
                attackPressedTime = 50;
                sprite.Play("punch");
            }
        }
        public void MoveRight()
        {
            
            if (attackPressedTime == 0 && !hasJumped)
                sprite.Play("runright");
        }
        public void MoveLeft()
        {
            
            if (attackPressedTime == 0 && !hasJumped)
                sprite.Play("runleft");
        }

        public void Update(GameTime gameTime)
        {
            var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            Input(gameTime);

            if (velocity.Y < 20 )
                velocity.Y += 0.4f;

            if (attackPressedTime > 0)
                attackPressedTime--;

            sprite.Update(deltaSeconds);
        }

        private void Input(GameTime gameTime)
        {
            var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                Punch();

            if (Keyboard.GetState().IsKeyDown(Keys.Right)) {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                MoveRight();
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                MoveLeft();
            }
            
            else velocity.X = 0f;

            if(Keyboard.GetState().IsKeyDown(Keys.Space)) 
            {
                Jump();
            }
        }
        

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }
            if (rectangle.Intersects(newRectangle) && !hasJumped) {
                if (rectangle.TouchLeftOf(newRectangle))
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
            _spriteBatch.Draw(sprite, position);
        }
    }
}
