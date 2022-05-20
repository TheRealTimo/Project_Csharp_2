using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ConflictGame
{
    class Splashscreen
    {
        private GraphicsDeviceManager graphics;
        private readonly Texture2D titleCard;
        private Vector2 titlePosition;
        private ContentManager content;
        public Splashscreen(Game1 game, ContentManager content, GraphicsDeviceManager graphics)
          //: base(game, graphicsDevice, content)
        {
            this.content = content;
            this.graphics = graphics;
            this.titleCard = content.Load<Texture2D>("ConflictPixelTinyLogo");
            this.titlePosition = new Vector2((int)(graphics.PreferredBackBufferWidth * 1.45), (int)(graphics.PreferredBackBufferHeight * 1.5));
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(content.Load<Texture2D>("Loadingbackground"), new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            spriteBatch.Draw(titleCard, titlePosition, Color.White);
            spriteBatch.End();
        }

        public  void PostUpdate(GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
