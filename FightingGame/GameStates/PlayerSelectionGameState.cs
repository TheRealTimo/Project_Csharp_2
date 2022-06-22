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
        private readonly Button _onePlayer;
        private readonly Button _twoPlayer;
        private readonly Button _threePlayer;
        private readonly Button _fourPlayer;
        private readonly Button _backButton;


        public PlayerSelectionGameState(FightingGame game) : base(game)
        {
            _onePlayer = new Button(this, new Vector2(447, 392), new Rectangle(0, 0, 413, 98));
            _twoPlayer = new Button(this, new Vector2(1060, 392), new Rectangle(0, 0, 413, 98));
            _threePlayer = new Button(this, new Vector2(447, 492), new Rectangle(0, 0, 413, 98));
            _fourPlayer = new Button(this, new Vector2(1060, 492), new Rectangle(0, 0, 413, 98));
            _backButton = new Button(this, new Vector2(753, 750), new Rectangle(0, 0, 413, 98));

            _onePlayer.OnClick += OnOnePlayerClick;
            _twoPlayer.OnClick += OnTwoPlayerClick;
            _threePlayer.OnClick += OnThreePlayerClick;
            _fourPlayer.OnClick += OnFourPlayerClick;
            _backButton.OnClick += OnBackButtonClick;

            GameComponents.Add(_onePlayer);
            GameComponents.Add(_twoPlayer);
            GameComponents.Add(_threePlayer);
            GameComponents.Add(_fourPlayer);
            GameComponents.Add(_backButton);


        }

        public override void LoadContent()
        {
            base.LoadContent();

            _onePlayer.Texture = Game.Textures["OnePlayer"];
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

        private void OnOnePlayerClick(object sender, EventArgs e)
        {
            Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64)));

            Game.ChangeGameState(Game.GameStates["Play"]);
        }

        private void OnTwoPlayerClick(object sender, EventArgs e)
        {
            Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64)));
            Game.Players.Add(PlayerIndex.Two, new Player(Game.GameStates["Play"], new Vector2(32 * 10, 64)));

            Game.ChangeGameState(Game.GameStates["Play"]);
        }

        private void OnThreePlayerClick(object sender, EventArgs e)
        {
            Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64)));
            Game.Players.Add(PlayerIndex.Two, new Player(Game.GameStates["Play"], new Vector2(32 * 10, 64)));
            Game.Players.Add(PlayerIndex.Three, new Player(Game.GameStates["Play"], new Vector2(32 * 15, 64)));

            Game.ChangeGameState(Game.GameStates["Play"]);
        }

        private void OnFourPlayerClick(object sender, EventArgs e)
        {
            Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64)));
            Game.Players.Add(PlayerIndex.Two, new Player(Game.GameStates["Play"], new Vector2(32 * 10, 64)));
            Game.Players.Add(PlayerIndex.Three, new Player(Game.GameStates["Play"], new Vector2(32 * 15, 64)));
            Game.Players.Add(PlayerIndex.Four, new Player(Game.GameStates["Play"], new Vector2(32 * 20, 64)));

            Game.ChangeGameState(Game.GameStates["Play"]);
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            Game.ChangeGameState(Game.GameStates["Menu"]);
        }
    }
}
