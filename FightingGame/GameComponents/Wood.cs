using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightingGame.GameComponents
{
    public class Wood : Block
    {
        public Wood(GameState gameState, Vector2 position) : base(gameState, position)
        {
            BoundingBox = new Rectangle(0, 0, 32, 32);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GameState.Game.Textures["Wood"], BoundingBox, Color.White);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}