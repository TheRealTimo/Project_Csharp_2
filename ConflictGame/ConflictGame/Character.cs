using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;

namespace ConflictGame
{
    class Character
    {
        public AnimatedSprite sprite;
        public int height = 32;
        public int width = 22;

        public Vector2 position;
        Vector2 velocity;

        private GraphicsDeviceManager _graphics;
        
        public bool hasJumped;
        public int attackPressedTime = 0;

        public Character(AnimatedSprite newSprite, Vector2 newPosition, GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
            sprite = newSprite;
            position = newPosition;
            hasJumped = true;
        }

        public void Jump()
        {
            if (hasJumped == false) {
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
            velocity.X = 3f;
            if (attackPressedTime == 0 && !hasJumped)
                sprite.Play("runright");
        }
        public void MoveLeft()
        {
            velocity.X = -3f;
            if (attackPressedTime == 0 && !hasJumped)
                sprite.Play("runleft");
        }

        public void OffPlat()
        {
            if (position.Y + height < _graphics.PreferredBackBufferHeight)
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
            var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                Punch();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                MoveRight();

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                MoveLeft();

            else
            {
                velocity.X = 0f;
                if (attackPressedTime == 0 && !hasJumped)
                    sprite.Play("idle");
            }

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

            if (position.Y + height >= _graphics.PreferredBackBufferHeight)
            {
                hasJumped = false; 
            }

            if (hasJumped == false)
            {
                velocity.Y = 0f;
            }

            if (position.X > _graphics.PreferredBackBufferWidth - width / 2) //Checks that the ball cannot leave the game area
                position.X = _graphics.PreferredBackBufferWidth - width / 2;
            else if (position.X < width / 2)
                position.X = width / 2;

            if (position.Y > _graphics.PreferredBackBufferHeight - height / 2)
                position.Y = _graphics.PreferredBackBufferHeight - height / 2;
            else if (position.Y < height / 2)
                position.Y = height / 2;

            if (attackPressedTime > 0)
                attackPressedTime--;

            sprite.Update(deltaSeconds);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /*spriteBatch.Draw(
                texture,
                position,
                null, //source rectangle
                Color.White,
                0f, // rotation
                new Vector2(width / 2, height / 2),
                Vector2.One, //scale
                SpriteEffects.None,
                0f // layer depth
                );*/
            spriteBatch.Draw(sprite, position);
        }

       
    }
}
