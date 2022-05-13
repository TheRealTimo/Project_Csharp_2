using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BattleGame2D.States;
using System;
using System.Threading.Tasks;

namespace BattleGame2D
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //creating thread for running in backround
        Task backgroundTask;

        private State _currentState;
        private State menuState;

        private State _nextState;
        //function for changing State 
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Assigning backround task to building main menu while splash screen is drawn
            backgroundTask = new Task(this.BuildMenuState);
            backgroundTask.Start();
            // Main thread builds splashscreen
            _currentState = new LoadingState(this, graphics.GraphicsDevice, Content, graphics);

        }

        // Function for building main menu state
        public void BuildMenuState()
        {
            menuState = new MenuState(this, graphics.GraphicsDevice, Content, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // checks if backround task is complete before changing state from splashscreen 
            if (backgroundTask.IsCompleted)
            {
                backgroundTask.Dispose();
                _nextState = menuState;
            }
            // ensures that state only load once
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // ensures that any previous spritebatch begins are ended if any
            try
            {
                spriteBatch.Begin();
            }
            catch (Exception e)
            {
                spriteBatch.End();
                spriteBatch.Begin();
            }

            spriteBatch.Draw(Content.Load<Texture2D>("background"), new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Changing screen size
            graphics.PreferredBackBufferWidth = 1580;
            graphics.PreferredBackBufferHeight = 853;
            graphics.ApplyChanges();
            GraphicsDevice.Clear(Color.WhiteSmoke);
            //spriteBatch.Begin();

            _currentState.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}
