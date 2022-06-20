using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FightingGame.Controls
{
    public class Button : GameComponent
    {
        private MouseState _previousMouseState;

        private Texture2D _texture;

        public Button(GameState gameState, Vector2 position, Rectangle boundingBox = default, Texture2D texture = default) : base(gameState, position, boundingBox, texture) { }

        public event EventHandler OnClick;

        public Texture2D Texture
        {
            get
            {
                return _texture;
            }

            set
            {
                _texture = value;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, BoundingBox, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (_previousMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                Point point = new Point(mouseState.X, mouseState.Y);

                if (BoundingBox.Contains(point))
                {
                    OnClick.Invoke(this, new EventArgs());
                }
            }

            _previousMouseState = mouseState;
        }
    }
}
