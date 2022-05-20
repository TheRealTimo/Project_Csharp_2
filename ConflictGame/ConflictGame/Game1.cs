    using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;

namespace ConflictGame
{
    public class Game1 : Game
    {
        private AnimatedSprite _gerjanSprite;
        private Vector2 _gerjanPosition;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var spriteSheet = Content.Load<SpriteSheet>("gerjan.sf", new JsonContentLoader());
            var sprite = new AnimatedSprite(spriteSheet);

            sprite.Play("idle");
            _gerjanPosition = new Vector2(100, 100);
            _gerjanSprite = sprite;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var walkSpeed = deltaSeconds * 128;
            var keyboardState = Keyboard.GetState();
            var animation = "idle";

            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            {
                animation = "runright";
                _gerjanPosition.Y -= walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            {
                animation = "runright";
                _gerjanPosition.Y += walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                animation = "runleft";
                _gerjanPosition.X -= walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                animation = "runright";
                _gerjanPosition.X += walkSpeed;
            }

            _gerjanSprite.Play(animation);

            _gerjanSprite.Update(deltaSeconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_gerjanSprite, _gerjanPosition);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
