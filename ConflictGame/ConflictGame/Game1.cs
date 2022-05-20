using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ConflictGame
{
    public class Game1 : Game
    {
        Texture2D ballTexture;  //Loads the texture of the ball in 2D
        Vector2 ballPosition; //Saves the X and Y axis as vector
        float ballSpeed;  //RemoveAll

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, //From here
            _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 100f;  //Till here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ballTexture = Content.Load<Texture2D>("ball"); //Specifies the content that has to be loaded in; Remove

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            GamePadState gstate = Gamepad.GetState();

            if(capabilities.HasLeftXThumbStick)
            {
                ballPosition.X += gstate.ThumbSticks.Left.X * 10.0f;
            }

            if (capabilities.HasAButton && gstate.IsButtonDown(Buttons.A))
            {
                ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }


            if (ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2) //Checks that the ball cannot leave the game area
                ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
            else if (ballPosition.X < ballTexture.Width / 2)
                ballPosition.X = ballTexture.Width / 2;

            if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
                ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
            else if (ballPosition.Y < ballTexture.Height / 2)
                ballPosition.Y = ballTexture.Height / 2;

            base.Update(gameTime); //Until here

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();  //From here
            _spriteBatch.Draw(ballTexture,
            ballPosition, //Centers the ball position to the center of the png
            null,
            Color.White,
            0f,
            new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
            );
            _spriteBatch.End();  //Till here

            base.Draw(gameTime);
        }
    }
}
