﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project4.Content
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch _spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
