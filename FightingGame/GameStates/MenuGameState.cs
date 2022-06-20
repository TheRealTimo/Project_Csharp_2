using FightingGame.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FightingGame.GameStates
{
    public class MenuGameState : GameState
    {
        private readonly Button _optionsButton;
        private readonly Button _playButton;
        private readonly Button _quitButton;

        private Texture2D _backgroundTexture;

        public MenuGameState(FightingGame game) : base(game)
        {
            _optionsButton = new Button(this, new Vector2(200, 550), new Rectangle(0, 0, 413, 98));
            _playButton = new Button(this, new Vector2(250, 300), new Rectangle(0, 0, 413, 98));
            _quitButton = new Button(this, new Vector2(150, 800), new Rectangle(0, 0, 413, 98));

            _optionsButton.OnClick += OnSettingsButtonClick;
            _playButton.OnClick += OnPlayButtonClick;
            _quitButton.OnClick += OnQuitButtonClick;

            GameComponents.Add(_optionsButton);
            GameComponents.Add(_playButton);
            GameComponents.Add(_quitButton);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawBackground(spriteBatch);

            base.Draw(gameTime, spriteBatch);
        }

        public override void LoadContent()
        {
            base.LoadContent();

            _backgroundTexture = Game.Textures["RedBackground"];

            _optionsButton.Texture = Game.Textures["OptionsButton"];
            _playButton.Texture = Game.Textures["PlayButton"];
            _quitButton.Texture = Game.Textures["QuitButton"];
        }

        private void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), new Color(255, 255, 255));
        }

        private void OnPlayButtonClick(object sender, EventArgs e)
        {
            Game.ChangeGameState(Game.GameStates["PlayerSelection"]);
        }

        private void OnSettingsButtonClick(object sender, EventArgs e)
        {
            Game.ChangeGameState(Game.GameStates["Options"]);
        }

        private void OnQuitButtonClick(object sender, EventArgs e)
        {
            Game.Exit();
        }
    }
}
