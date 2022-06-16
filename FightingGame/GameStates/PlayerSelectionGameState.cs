using FightingGame.GameComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FightingGame.GameStates
{
    public class PlayerSelectionGameState : GameState
    {
        public PlayerSelectionGameState(FightingGame game) : base(game) { }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.D1))
            {
                Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64)));

                Game.ChangeGameState(Game.GameStates["Play"]);
            }

            if (keyboardState.IsKeyDown(Keys.D2))
            {
                Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64)));
                Game.Players.Add(PlayerIndex.Two, new Player(Game.GameStates["Play"], new Vector2(32 * 10, 64)));

                Game.ChangeGameState(Game.GameStates["Play"]);
            }

            if (keyboardState.IsKeyDown(Keys.D3))
            {
                Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64)));
                Game.Players.Add(PlayerIndex.Two, new Player(Game.GameStates["Play"], new Vector2(32 * 10, 64)));
                Game.Players.Add(PlayerIndex.Three, new Player(Game.GameStates["Play"], new Vector2(32 * 15, 64)));

                Game.ChangeGameState(Game.GameStates["Play"]);
            }

            if (keyboardState.IsKeyDown(Keys.D4))
            {
                Game.Players.Add(PlayerIndex.One, new Player(Game.GameStates["Play"], new Vector2(32 * 5, 64)));
                Game.Players.Add(PlayerIndex.Two, new Player(Game.GameStates["Play"], new Vector2(32 * 10, 64)));
                Game.Players.Add(PlayerIndex.Three, new Player(Game.GameStates["Play"], new Vector2(32 * 15, 64)));
                Game.Players.Add(PlayerIndex.Four, new Player(Game.GameStates["Play"], new Vector2(32 * 20, 64)));

                Game.ChangeGameState(Game.GameStates["Play"]);
            }
        }
    }
}
