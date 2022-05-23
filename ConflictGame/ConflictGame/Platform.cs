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
        public Vector2 Update(Vector2 playerPos, int playerWidth, int playerHeight)
        {

            if(playerPos.X > rectangle.Left - playerWidth / 2 && playerPos.X - playerWidth / 2 < rectangle.Right && playerPos.Y + playerHeight/2 > rectangle.Top && playerPos.Y - playerHeight/2 < rectangle.Bottom)
            {//Checks if player extends crosses left of platform && Checks if player extends crosses Right of platform && Checks if player extends crosses Top of platform && Checks if player extends crosses Bootom of platform

                if (playerPos.Y < rectangle.Top)                        //checks if player center is above the platform
                    playerPos.Y = rectangle.Top - playerHeight / 2;
                else if (playerPos.X < rectangle.Left)                  //checks if player center is above the platform
                    playerPos.X = rectangle.Left - playerWidth/2;
                else if (playerPos.Y > rectangle.Bottom)                //checks if player center is above the platform
                    playerPos.Y = rectangle.Bottom + playerHeight / 2;
                else                                                    // else player is Right of platform
                    playerPos.X = rectangle.Right + playerWidth/2;
            }
            
            return playerPos;


        }

        //Draw
        public void Draw(GameTime gameTime, SpriteBatch sp)
        {

            Color col = Color.White;
            sp.Draw(image, rectangle, col);

        }

    }
}
