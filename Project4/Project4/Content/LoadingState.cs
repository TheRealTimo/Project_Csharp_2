﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project4.Content.States
{
    public class LoadingState : State
    {
        private GraphicsDeviceManager graphics;
        private readonly Texture2D titleCard;
        private Vector2 titlePosition;
        public LoadingState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, GraphicsDeviceManager graphics)
          : base(game, graphicsDevice, content)
        {
            this.graphics = graphics;
            this.titleCard = _content.Load<Texture2D>("ConflictPixelTinyLogo");
            this.titlePosition = new Vector2((int)(graphics.PreferredBackBufferWidth * 1.45), (int)(graphics.PreferredBackBufferHeight * 1.5));
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