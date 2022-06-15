using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightingGame
{
    public abstract class GameComponent
    {
        public GameComponent(Vector2 position)
        {
            Position = position;
        }

        public Vector2 Position {
            get;
            set;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
