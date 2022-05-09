using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Project4
{
    class cButton
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size;

        public cButton(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;

            //screen (tutorial) = 800 x 600
            // img (tutorial) = 100 x 20

            //screen (game) = 1920 x 1080
            //img (game) = 28 x 36

            size = new Vector2(graphics.Viewport.Width / 10, graphics.Viewport.Height / 20);
        }

        bool down;
        public bool isClickedDown;
        private Texture2D buttonTexture;

        public Vector2 Position { get; internal set; }

        public cButton()
        {

        }

        public cButton(Texture2D buttonTexture)
        {
            this.buttonTexture = buttonTexture;
        }

        public void Load(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
        }
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)(position.X - size.X / 2), (int)(position.Y - size.Y / 2), (int)size.X,(int)size.Y);


            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if(mouseRectangle.Intersects(rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 3; else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClickedDown = true;
            }

            else if (colour.A < 255)
            {
                colour.A += 3;
                isClickedDown = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);
        }
    }
}
