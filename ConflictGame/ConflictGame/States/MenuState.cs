using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ConflictGame.Controls;

namespace ConflictGame.States
{

    public class MenuState : State
    {
        private List<Component> _components;
        private GraphicsDevice _device;
        private Game1 _game;

        //values for the current screen size
        private readonly int bufferWidth;
        private readonly int bufferHeight;
        // texture and position value for title icon
        private readonly Texture2D titleCard;
        private Vector2 titlePosition;
        private State gameState;
        private State loadingState;


        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int bufferWidth, int bufferHeight)
          : base(game, graphicsDevice, content)
        {
            this._game = game;

            this.bufferWidth = bufferWidth;
            this.bufferHeight = bufferHeight;

            titleCard = _content.Load<Texture2D>("ConflictPixelLogo");
            titlePosition = new Vector2((int)(bufferWidth / 3.2), bufferHeight / 10);

            var buttonPlayTexture = _content.Load<Texture2D>("playgame");
            var buttonSettingsTexture = _content.Load<Texture2D>("options");
            var buttonQuitTexture = _content.Load<Texture2D>("RedBttn");
            var buttonFont = _content.Load<SpriteFont>("Font");

            // using current screen size to determine position vectors
            int width = (int)(this.bufferWidth);
            int height = this.bufferHeight;
            // creating play button
            var playButton = new Button(buttonPlayTexture, buttonFont)
            {
                Position = new Vector2(250, 300),
                Text = ""
            };
            // assigning button click to function
            playButton.Click += NewGameButton_Click;
            // creating settings button
            var settingsButton = new Button(buttonSettingsTexture, buttonFont)
            {
                Position = new Vector2(200, 550),
                Text = "",
            };
            // assigning settings button click to function
            settingsButton.Click += SettingsButton_Click;
            // creating quit button
            var quitGameButton = new Button(buttonQuitTexture, buttonFont)
            {
                Position = new Vector2(150, 800),
                Text = "Quit Game",
            };
            // assigning quit game button click to function
            quitGameButton.Click += QuitGameButton_Click;

            //list of buttons for drawing
            _components = new List<Component>()
              {
                playButton,
                settingsButton,
                quitGameButton,
              };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(titleCard, titlePosition, Color.White);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
        // function for setting button
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState("ss");
        }
        // function for playbutton called new game to change to game state
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState("gs");
        }
        // function for quit button 
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

    }
}