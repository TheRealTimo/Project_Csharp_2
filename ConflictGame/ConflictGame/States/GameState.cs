using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ConflictGame.States
{
    public class GameState : State
    {
        bool jumping;
        Texture2D ballTexture;  //Loads the texture of the ball in 2D
        Platform platform;
        Vector2 ballPosition; //Saves the X and Y axis as vector
        float ballSpeed;  //RemoveAll
        private int bufferWidth;
        private int bufferHeight;
        private float gravity;
        

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int bufferWidth, int bufferHeight)
          : base(game, graphicsDevice, content)
        {
            jumping = false;
            this.bufferWidth = bufferWidth;
            this.bufferHeight = bufferHeight;
            ballPosition = new Vector2(bufferWidth / 2, //From here
            bufferHeight / 2);
            ballSpeed = 500f;  //Till here
            ballTexture = content.Load<Texture2D>("3guys");
            // gravity value
            this.gravity = 300f;
            // creating platform with collision handling
            this.platform = new Platform(content, bufferWidth / 2, bufferHeight / 2, 400, 150);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //draw player
            spriteBatch.Draw(ballTexture,
            ballPosition, //Centers the ball position to the center of the png
            null,
            Color.White,
            0f,
            new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
            1,
            SpriteEffects.None,
            0f
            );

            //Draw platform 
            platform.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            


            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            GamePadState gstate = Gamepad.GetState();

            if (capabilities.HasLeftXThumbStick)
            {
                ballPosition.X += gstate.ThumbSticks.Left.X * 10.0f;
            }

            if (capabilities.HasAButton && gstate.IsButtonDown(Buttons.A))
            {
                ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                jumping = true;
            }
            else { jumping = false; }

            //Checks that the ball cannot leave the game area
            if (ballPosition.X > bufferWidth - ballTexture.Width / 2)
                ballPosition.X = bufferWidth - ballTexture.Width / 2;
            else if (ballPosition.X < ballTexture.Width / 2)
                ballPosition.X = ballTexture.Width / 2;

            if (ballPosition.Y > bufferHeight - ballTexture.Height / 2)
            {
                ballPosition.Y = bufferHeight - ballTexture.Height / 2;
            }
            else if (ballPosition.Y < ballTexture.Height / 2)
                ballPosition.Y = ballTexture.Height / 2;

            //checks that the ball collides with platform
            ballPosition = platform.Update(ballPosition, ballTexture.Width, ballTexture.Height);
            //Until here
            if (!jumping)
            {
                ballPosition.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

        }
    }
}