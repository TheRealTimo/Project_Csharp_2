using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BattleGame2D.Controls;

namespace BattleGame2D.States
{

    public class MenuState : State
    {
        private List<Component> _components;
        //values for the current screen size
        private readonly int bufferWidth;
        private readonly int bufferHeight;
        // texture and position value for title icon
        private readonly Texture2D titleCard;
        private Vector2 titlePosition;


        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int bufferWidth, int bufferHeight)
          : base(game, graphicsDevice, content)
        {
            this.bufferWidth = bufferWidth;
            this.bufferHeight = bufferHeight;

            titleCard = _content.Load<Texture2D>("ConflictPixelLogo");
            titlePosition = new Vector2((int)(bufferWidth / 3.2), bufferHeight / 10);

            var buttonTexture = _content.Load<Texture2D>("Controls/PlayButton");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            // using current screen size to determine position vectors
            int width = (int)(this.bufferWidth / 1.35);
            int height = this.bufferHeight;
            // creating play button
            var playButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((int)(width / 3.3), height / 2),
                Text = "PLAY NOW"
            };
            // assigning button click to function
            playButton.Click += NewGameButton_Click;
            // creating settings button
            var settingsButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(width, (int)(height / 2)),
                Text = "Settings",
            };
            // assigning settings button click to function
            settingsButton.Click += SettingsButton_Click;
            // creating quit button
            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((int)(width * 1.7), (int)(height / 2)),
                Text = "Quit Game",
            };
            // assigning quit game button click to function
            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
              {
                playButton,
                settingsButton,
                quitGameButton,
              };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(titleCard, titlePosition, Color.White);
            foreach (var component in _components)
            component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
        // function for setting button
        private void SettingsButton_Click(object sender, EventArgs e)
        {

        }
        // function for playbutton called new game to change to game state
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
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
