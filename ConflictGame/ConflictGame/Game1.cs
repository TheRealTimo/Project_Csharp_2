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
        private Splashscreen splashscreen;


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

            //_graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            isLoading = true;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTask = new Task(this.BackgroundTask);
            backgroundTask.Start();
            // Main thread builds splashscreen
            splashscreen = new Splashscreen(this, Content, _graphics);
           // _currentState = loadingState;
            // TODO: use this.Content to load your game content here
        }
        public void BackgroundTask()
        {
            // field for backround task to be done while splashscreen is displayed
            //backgroundTask.Wait(200);
        }

        protected override void Update(GameTime gameTime)
        {
            if (backgroundTask.IsCompleted)
            {
                backgroundTask.Dispose();
                isLoading = false;
                // Change State
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (isLoading) { splashscreen.Draw(gameTime, _spriteBatch); }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
