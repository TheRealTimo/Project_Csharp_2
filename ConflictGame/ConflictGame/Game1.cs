using ConflictGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;

namespace ConflictGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        private Task backgroundTask;
        private bool isLoading;

        private State _currentState;
        private State _nextState;
        private State splashscreen;
        private State gameState;
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;

            _graphics.IsFullScreen = true;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            isLoading = true;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTask = new Task(this.BackgroundTask);
            backgroundTask.Start();
            // Main thread builds splashscreen
            splashscreen = new Splashscreen(this, _graphics.GraphicsDevice, Content, _graphics);
            _currentState = splashscreen;
            // TODO: use this.Content to load your game content here
        }
        public void BackgroundTask()
        {
            // field for backround task to be done while splashscreen is displayed
            gameState = new GameState(this, _graphics.GraphicsDevice, Content, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            backgroundTask.Wait(1500);
        }

        protected override void Update(GameTime gameTime)
        {
            if (backgroundTask.IsCompleted)
            {
                backgroundTask.Dispose();
                isLoading = false;
                _nextState = gameState;
            }
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // ensures that any previous spritebatch begins are ended if any
            try
            {
                _spriteBatch.Begin();
            }
            catch (System.Exception e)
            {
                _spriteBatch.End();
                _spriteBatch.Begin();
            }
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (isLoading) { splashscreen.Draw(gameTime, _spriteBatch); }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
