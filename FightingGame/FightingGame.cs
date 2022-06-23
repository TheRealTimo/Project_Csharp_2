using FightingGame.GameComponents;
using FightingGame.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System.Collections.Generic;

namespace FightingGame
{
    public class FightingGame : Game
    {
        private readonly Dictionary<string, GameState> _gameStates;
        private readonly GraphicsDeviceManager _graphics;
        private readonly Dictionary<PlayerIndex, Player> _players = new Dictionary<PlayerIndex, Player>();
        private readonly Dictionary<string, SpriteSheet> _spriteSheets;
        private readonly Dictionary<string, Texture2D> _textures;

        private GameState _gameState;
        private SpriteBatch _spriteBatch;

        public FightingGame()
        {
           _gameStates = new Dictionary<string, GameState>
            {
                { "Menu", new MenuGameState(this) },
                { "Options", new OptionsGameState(this) },
                { "Play", new PlayGameState(this) },
                { "PlayerSelection", new PlayerSelectionGameState(this) }
            };

            _graphics = new GraphicsDeviceManager(this);

            _spriteSheets = new Dictionary<string, SpriteSheet>();
            _textures = new Dictionary<string, Texture2D>();

            Content.RootDirectory = "Content";

            IsMouseVisible = true;

            ChangeGameState(_gameStates["Menu"]);
        }

        public GameState GameState
        {
            get
            {
                return _gameState;
            }
        }

        public Dictionary<string, GameState> GameStates
        {
            get
            {
                return _gameStates;
            }
        }

        public Dictionary<PlayerIndex, Player> Players
        {
            get
            {
                return _players;
            }
        }

        public Dictionary <string, SpriteSheet> SpriteSheets
        {
            get
            {
                return _spriteSheets;
            }
        }

        public Dictionary<string, Texture2D> Textures
        {
            get
            {
                return _textures;
            }
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
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteSheets.Add("Player", Content.Load<SpriteSheet>("Player.sf", new JsonContentLoader()));

            _textures.Add("RedBackground", Content.Load<Texture2D>("RedBackground"));

            _textures.Add("OptionsButton", Content.Load<Texture2D>("Controls/OptionsButton"));
            _textures.Add("PlayButton", Content.Load<Texture2D>("Controls/PlayButton"));
            _textures.Add("QuitButton", Content.Load<Texture2D>("Controls/QuitButton"));
            _textures.Add("OnePlayer", Content.Load<Texture2D>("Controls/OnePlayer"));
            _textures.Add("TwoPlayer", Content.Load<Texture2D>("Controls/TwoPlayer"));
            _textures.Add("ThreePlayer", Content.Load<Texture2D>("Controls/ThreePlayer"));
            _textures.Add("FourPlayer", Content.Load<Texture2D>("Controls/FourPlayer"));
            _textures.Add("BackButton", Content.Load<Texture2D>("Controls/BackButton"));
            _textures.Add("PlayerHeart1", Content.Load<Texture2D>("PlayerHeart1"));
            _textures.Add("PlayerHeart2", Content.Load<Texture2D>("PlayerHeart2"));
            _textures.Add("PlayerHeart3", Content.Load<Texture2D>("PlayerHeart3"));
            _textures.Add("PlayerHeart4", Content.Load<Texture2D>("PlayerHeart4"));
            _textures.Add("PlayerCount1", Content.Load<Texture2D>("PlayerCount1"));
            _textures.Add("PlayerCount2", Content.Load<Texture2D>("PlayerCount2"));
            _textures.Add("PlayerCount3", Content.Load<Texture2D>("PlayerCount3"));
            _textures.Add("PlayerCount4", Content.Load<Texture2D>("PlayerCount4"));


            _textures.Add("Block", Content.Load<Texture2D>("Block"));
            _textures.Add("Player", Content.Load<Texture2D>("Player"));

            foreach (GameState gameState in _gameStates.Values)
            {
                gameState.LoadContent();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _gameState.Update(gameTime);
        }
    }
}
