using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ConflictGame
{
    class Platform
    {
        Rectangle rectangle;
        Texture2D image;

        public Platform(ContentManager content ,double posWidth, double posHeight, int sizeWidth, int sizeHeight)
        {
            image = content.Load<Texture2D>("wip1-industrial-brick_height");
            rectangle = new Rectangle((int)(posWidth), (int)(posHeight), sizeWidth, sizeHeight);
        }

        //Update
        public void Update(Character player)
        {
            /*player.OffPlat();
            if(player.position.X > rectangle.Left - player.texture.Width / 2 && player.position.X - player.texture.Width / 2 < rectangle.Right && player.position.Y + player.texture.Height / 2 > rectangle.Top && player.position.Y - player.texture.Height /2 < rectangle.Bottom)
            {//Checks if player extends crosses left of platform && Checks if player extends crosses Right of platform && Checks if player extends crosses Top of platform && Checks if player extends crosses Bootom of platform

                if (player.position.Y < rectangle.Top)
                {                     //checks if player center is above the platform
                    player.position.Y = rectangle.Top - player.texture.Height / 2;
                    player.PlatStand();
                }
                else if (player.position.X < rectangle.Left)
                {                //checks if player center is above the platform
                    player.position.X = rectangle.Left - player.texture.Width / 2;
                }
                else if (player.position.Y > rectangle.Bottom)
                {     //checks if player center is above the platform
                    player.position.Y = rectangle.Bottom + player.texture.Height / 2;
                }
                else
                {                         // else player is Right of platform
                    player.position.X = rectangle.Right + player.texture.Width / 2;
                }*/
            //}


        }

        //Draw
        public void Draw(GameTime gameTime, SpriteBatch sp)
        {

            Color col = Color.White;
            sp.Draw(image, rectangle, col);

        }

    }
}
