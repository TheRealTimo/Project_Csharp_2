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
            _optionsButton = new Button(new Vector2(200, 550));
            _playButton = new Button(new Vector2(250, 300));
            _quitButton = new Button(new Vector2(150, 800));

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

        public void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), new Color(255, 255, 255));
        }

        public override void LoadContent()
        {
            base.LoadContent();

            _backgroundTexture = Game.Textures["Background"];

            _optionsButton.Texture = Game.Textures["OptionsButton"];
            _playButton.Texture = Game.Textures["PlayButton"];
            _quitButton.Texture = Game.Textures["QuitButton"];
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void OnPlayButtonClick(object sender, EventArgs e)
        {
            Game.ChangeGameState(Game.GameStates["play"]);
        }

        private void OnSettingsButtonClick(object sender, EventArgs e)
        {
            Game.ChangeGameState(Game.GameStates["options"]);
        }

        private void OnQuitButtonClick(object sender, EventArgs e)
        {
            Game.Exit();
        }
    }
}
