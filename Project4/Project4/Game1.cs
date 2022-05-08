using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project4
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _characterTexture;

        Vector2 characterPosition;
        float characterSpeed;

        #region pause
        bool paused = false;
        Texture2D pausedTexture;
        Rectangle pausedRectangle;
        

        #endregion

        enum GameState 
        { 
            MainMenu,
            Pause,
            Playing,
        }

        GameState CurrentGameState = GameState.MainMenu;
        //screen adjustments (tutorial)
        
        int screenWidth = 1920; //800 in tut vid
        int screenHeight = 1080; //600 in tut vid         


        cButton btnPlay;
        Button btnContinue, btnQuit;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            #region game to fullscreen
            // Set game to fullscreen 
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;

            _graphics.IsFullScreen = true;

            _graphics.ApplyChanges();
            #endregion

            #region character position
            characterPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            characterSpeed = 100f;

            
            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _characterTexture = Content.Load< Texture2D > ("character");

            // TODO: use this.Content to load your game content here

            // screen stuffstuffs
            // graphics.PreferredBackBufferWidth = screenWidth;
            // graphics.PreferredBackBufferHeight = screenHeight;

            IsMouseVisible = true;

            #region playbutton main menu
            btnPlay = new cButton(Content.Load<Texture2D>("PlayButton"), _graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            #endregion

            #region pause menu v2
            pausedTexture = Content.Load<Texture2D>("paused");
            pausedRectangle = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);

            btnContinue = new Button(_graphics.GraphicsDevice);
            btnContinue.Load(Content.Load<Texture2D>("QuitButton"), new Vector2(350, 275));
            btnQuit = new Button(_graphics.GraphicsDevice);
            btnQuit.Load(Content.Load<Texture2D>("QuitButton"), new Vector2(350, 275));
            #endregion


            #region pause menu v1
            /*
            pausedTexture = Content.Load<Texture2D>("Paused");
            pausedRectangle = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);
            btnContinue = new cButton(Content.Load<Texture2D>("ContinueButton"), _graphics.GraphicsDevice);
            btnContinue.setPosition(new Vector2( _graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            btnQuit = new cButton(Content.Load<Texture2D>("QuitButton"), _graphics.GraphicsDevice);
            btnQuit.setPosition(new Vector2( _graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            */
            #endregion

        }

        protected override void Update(GameTime gameTime)
        {
           

            #region movement

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                characterPosition.Y -= characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                characterPosition.Y += characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                characterPosition.X -= characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                characterPosition.X += characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            #endregion

            #region confine to screen

            if (characterPosition.X > _graphics.PreferredBackBufferWidth - _characterTexture.Width / 2)
                characterPosition.X = _graphics.PreferredBackBufferWidth - _characterTexture.Width / 2;
            else if (characterPosition.X < _characterTexture.Width / 2)
                characterPosition.X = _characterTexture.Width / 2;

            if (characterPosition.Y > _graphics.PreferredBackBufferHeight - _characterTexture.Height / 2)
                characterPosition.Y = _graphics.PreferredBackBufferHeight - _characterTexture.Height / 2;
            else if (characterPosition.Y < _characterTexture.Height / 2)
                characterPosition.Y = _characterTexture.Height / 2;
            #endregion
            // TODO: Add your update logic here

            #region activate pause state

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouse = Mouse.GetState();

            if (!paused) 
            {
                if(Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    paused = true;
                    btnPlay.isClickedDown = false;
                }
                else if (paused) 
                {
                    if (btnPlay.isClickedDown)
                        paused = false;
                    if (btnQuit.isClickedDown)
                        Exit();
                }
            }

            switch(CurrentGameState)
            {
                case GameState.MainMenu:
                    // isClicked instead of isclickeddown?
                    if (btnPlay.isClickedDown == true) CurrentGameState = GameState.Playing;
                    btnPlay.Update(mouse);
                    break;

                case GameState.Playing:
                    break;      
            }
            #endregion

            if(paused)
            {
                btnQuit.Update(mouse);
                btnContinue.Update(mouse);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            #region draw character
            // draw first character, origin point set to center of sprite.
            _spriteBatch.Draw
                (
                    _characterTexture,
                    characterPosition,
                    null,
                    Color.White,
                    0f,
                    new Vector2(_characterTexture.Width / 2, _characterTexture.Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f
                );
            #endregion

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    //spritebatch.Draw
                    _spriteBatch.Draw(Content.Load<Texture2D>("background"), new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
                    btnPlay.Draw(_spriteBatch);
                    break;

                case GameState.Playing:
                    break;
            }

            if(paused)
            {
                _spriteBatch.Draw(pausedTexture, pausedRectangle, Color.White);
                btnContinue.Draw(_spriteBatch);
                btnQuit.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
