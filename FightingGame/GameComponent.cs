using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FightingGame
{
    public abstract class GameComponent
    {
        private readonly GameState _gameState;

        private Rectangle _boundingBox;
        private Vector2 _position;

        public GameComponent(GameState gameState, Vector2 position, Rectangle boundingBox = default, Texture2D texture = default)
        {
            _gameState = gameState;
            _position = position;

            _boundingBox = boundingBox;
            
            _boundingBox.X = (int) position.X;
            _boundingBox.Y = (int) position.Y;
        }

        public Rectangle BoundingBox
        {
            get
            {
                _boundingBox.X = (int) _position.X;
                _boundingBox.Y = (int) _position.Y;

                return _boundingBox;
            }

            set
            {
                _boundingBox = value;
            }
        }

        public GameState GameState
        {
            get
            {
                return _gameState;
            }
        }

        public Vector2 Position {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public virtual void LoadContent() { }

        public abstract void Update(GameTime gameTime);
    }
}
