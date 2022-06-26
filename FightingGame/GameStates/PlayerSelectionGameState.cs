using System;
using FightingGame.GameComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FightingGame.Controls;

namespace FightingGame.GameStates
{
    public class PlayerSelectionGameState : GameState
    {
        private readonly Button _twoPlayer;
        private readonly Button _threePlayer;
        private readonly Button _fourPlayer;
        private readonly Button _backButton;


        public PlayerSelectionGameState(FightingGame game) : base(game)
        {
            _twoPlayer = new Button(this, new Vector2(754, 270), new Rectangle(0, 0, 413, 98));
            _threePlayer = new Button(this, new Vector2(754, 405), new Rectangle(0, 0, 413, 98));
            _fourPlayer = new Button(this, new Vector2(754, 540), new Rectangle(0, 0, 413, 98));
            _backButton = new Button(this, new Vector2(754, 675), new Rectangle(0, 0, 413, 98));

            _twoPlayer.OnClick += OnTwoPlayerClick;
            _threePlayer.OnClick += OnThreePlayerClick;
            _fourPlayer.OnClick += OnFourPlayerClick;
            _backButton.OnClick += OnBackButtonClick;

            GameComponents.Add(_twoPlayer);
            GameComponents.Add(_threePlayer);
            GameComponents.Add(_fourPlayer);
            GameComponents.Add(_backButton);


        }

        public override void LoadContent()
        {
            base.LoadContent();

            _twoPlayer.Texture = Game.Textures["TwoPlayer"];
            _threePlayer.Texture = Game.Textures["ThreePlayer"];
            _fourPlayer.Texture = Game.Textures["FourPlayer"];
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

       

        private void OnTwoPlayerClick(object sender, EventArgs e)
        {
            Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64), 1));
            Game.Players.Add(PlayerIndex.Two, new Player(Game.GameStates["Play"], new Vector2(32 * 10, 64), 2));

            Game.ChangeGameState(Game.GameStates["Play"]);
        }

        private void OnThreePlayerClick(object sender, EventArgs e)
        {
            Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64), 1));
            Game.Players.Add(PlayerIndex.Two, new Player(Game.GameStates["Play"], new Vector2(32 * 10, 64), 2));
            Game.Players.Add(PlayerIndex.Three, new Player(Game.GameStates["Play"], new Vector2(32 * 15, 64), 3));

            Game.ChangeGameState(Game.GameStates["Play"]);
        }

        private void OnFourPlayerClick(object sender, EventArgs e)
        {
            Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64), 1));
            Game.Players.Add(PlayerIndex.Two, new Player(Game.GameStates["Play"], new Vector2(32 * 10, 64), 2));
            Game.Players.Add(PlayerIndex.Three, new Player(Game.GameStates["Play"], new Vector2(32 * 15, 64), 3));
            Game.Players.Add(PlayerIndex.Four, new Player(Game.GameStates["Play"], new Vector2(32 * 20, 64), 4));

            Game.ChangeGameState(Game.GameStates["Play"]);
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            Game.ChangeGameState(Game.GameStates["Menu"]);
        }
    }
}
