using FightingGame.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FightingGame.GameStates
{
    public class EndGameState : GameState
    {
        private readonly Button _playAgainButton;
        private readonly Button _quitButton;

        private Texture2D _backgroundTexture;

        public EndGameState(FightingGame game) : base(game)
        {
            
            _playAgainButton = new Button(this, new Vector2(250, 300), new Rectangle(0, 0, 413, 98));
            _quitButton = new Button(this, new Vector2(250, 550), new Rectangle(0, 0, 413, 98));

            _playAgainButton.OnClick += OnPlayButtonClick;
            _quitButton.OnClick += OnQuitButtonClick;

            GameComponents.Add(_playAgainButton);
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

            _playAgainButton.Texture = Game.Textures["PlayButton"];
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

        private void OnQuitButtonClick(object sender, EventArgs e)
        {
            Game.Exit();
        }
    }
}
