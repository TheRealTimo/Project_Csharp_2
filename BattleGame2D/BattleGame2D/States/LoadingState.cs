using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BattleGame2D.States
{
    public class LoadingState : State
    {
        private int bufferWidth;
        private int bufferHeight;
        GraphicsDeviceManager graphics;
        Texture2D titleCard;
        Vector2 titlePosition;
        public LoadingState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int bufferWidth, int bufferHeight, GraphicsDeviceManager graphics)
          : base(game, graphicsDevice, content)
        {
            this.bufferWidth = bufferWidth;
            this.bufferHeight = bufferHeight;
            this.graphics = graphics;
            this.titleCard = _content.Load<Texture2D>("ConflictPixelLogo");
            this.titlePosition = new Vector2(bufferWidth, bufferHeight);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_content.Load<Texture2D>("Loadingbackground"), new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

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
