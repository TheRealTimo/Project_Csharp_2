using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FightingGame.Controls;
using System;

namespace FightingGame.GameStates
{
    public class OptionsGameState : GameState
    {
        private readonly Button _backButton;

        public OptionsGameState(FightingGame game) : base(game)
        {
            _backButton = new Button(this, new Vector2(753, 750), new Rectangle(0, 0, 413, 98));

            _backButton.OnClick += OnBackButtonClick;

            GameComponents.Add(_backButton);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _backButton.Texture = Game.Textures["BackButton"];
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        private void OnBackButtonClick(object sender, EventArgs e)
        {
            Game.ChangeGameState(Game.GameStates["Menu"]);
        }
    }
}
