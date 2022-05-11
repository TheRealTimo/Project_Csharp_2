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
        int COUNTER = 250;

        int timer;
        private GraphicsDeviceManager graphics;
        private Texture2D titleCard;
        private Vector2 titlePosition;
        private State nextState;
        public LoadingState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, GraphicsDeviceManager graphics, State nextState)
          : base(game, graphicsDevice, content)
        {
            this.timer = 0;
            this.graphics = graphics;
            this.nextState = nextState;
            this.titleCard = _content.Load<Texture2D>("ConflictPixelLogo");
            this.titlePosition = new Vector2(graphics.PreferredBackBufferWidth/10, graphics.PreferredBackBufferHeight/8);
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
            timer++;
            if (timer == COUNTER)
            {
                ChangeState();
            }
        }

        private void ChangeState()
        {
            _game.ChangeState(nextState);
        }
    }
}
