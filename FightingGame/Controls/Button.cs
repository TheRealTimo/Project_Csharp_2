using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FightingGame.Controls
{
    public class Button : GameComponent
    {
        public Button(Vector2 position) : base(position) { }

        public event EventHandler OnClick;

        public Texture2D Texture
        {
            get;
            set;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, new Color(255, 255, 255));
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
