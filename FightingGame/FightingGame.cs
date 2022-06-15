using FightingGame.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FightingGame
{
    public class FightingGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;

        private GameState _gameState;
        private SpriteBatch _spriteBatch;

        public FightingGame()
        {
            _graphics = new GraphicsDeviceManager(this);

            GameStates = new Dictionary<string, GameState>
            {
                { "Menu", new MenuGameState(this) },
                { "Play", new PlayGameState(this) }
            };

            ChangeGameState(GameStates["Menu"]);

            Textures = new Dictionary<string, Texture2D>();

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        public Dictionary<string, GameState> GameStates
        {
            get;
        }

        public Dictionary<string, Texture2D> Textures
        {
            get;
        }

        public void ChangeGameState(GameState gameState)
        {
            if (_gameState != null)
            {
                _gameState.OnExit();
            }

            _gameState = gameState;

            _gameState.OnEnter();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            DrawGameState(gameTime);
        }

        protected void DrawGameState(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _gameState.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();
        }

        protected override void Initialize()
        {
            base.Initialize();

            _graphics.PreferredBackBufferWidth = 1920; // GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = 1080; // GraphicsDevice.DisplayMode.Height;

            _graphics.IsFullScreen = false;

            _graphics.ApplyChanges();

            _gameState.LoadContent();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Textures.Add("Background", Content.Load<Texture2D>("Background"));

            Textures.Add("OptionsButton", Content.Load<Texture2D>("Controls/OptionsButton"));
            Textures.Add("PlayButton", Content.Load<Texture2D>("Controls/PlayButton"));
            Textures.Add("QuitButton", Content.Load<Texture2D>("Controls/QuitButton"));
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _gameState.Update(gameTime);
        }
    }
}
