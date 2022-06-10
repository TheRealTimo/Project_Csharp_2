using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ConflictGame.States
{
    public class Splashscreen : State
    {
        private GraphicsDeviceManager graphics;
        private readonly Texture2D titleCard;
        private Vector2 titlePosition;
        public Splashscreen(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, GraphicsDeviceManager graphics)
          : base(game, graphicsDevice, content)
        {
            this.graphics = graphics;
            this.titleCard = _content.Load<Texture2D>("ConflictPixelLogo");
            this.titlePosition = new Vector2((int)(graphics.PreferredBackBufferWidth / 4.5), (int)(graphics.PreferredBackBufferHeight / 3));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           
           graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(titleCard, titlePosition, Color.White);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
