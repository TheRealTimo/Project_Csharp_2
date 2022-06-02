﻿using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ConflictGame.States
{
    public class GameState : State
    {
        //platform creating
        Platform[] platform;

        //vales for screen size
        private int bufferWidth;
        private int bufferHeight;

        // Creating player 1
        private Character[] playerArray = new Character[]{};

        Character player;
        Character player2; //New: Adding a new player
        Character player3;
        Character player4;


        //background image
        private Texture2D _tempBackgroundTexture;


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, GraphicsDeviceManager graphics)
          : base(game, graphicsDevice, content)
        {
            //Values for screen size
            this.bufferWidth = graphics.PreferredBackBufferWidth;
            this.bufferHeight = graphics.PreferredBackBufferHeight;

            // creating platform with collision handling
            this.platform = new Platform[6] { 
                new Platform(content, (int)bufferWidth * 0.172, (int)bufferHeight * 0.97, 1260, 35),
                new Platform(content, (int)bufferWidth * 0.31, (int)bufferHeight * 0.623, 727, 35),
                new Platform(content, (int)bufferWidth * 0.755, (int)bufferHeight * 0.72, 150, 35),
                new Platform(content, (int)bufferWidth * 0.17, (int)bufferHeight * 0.72, 150, 35),
                new Platform(content, (int)bufferWidth * 0.0, (int)bufferHeight * 0.825, 280, 35),
                new Platform(content, (int)bufferWidth * 0.855, (int)bufferHeight * 0.825, 280, 35)
            };

            //choosing backround image texture
            _tempBackgroundTexture = content.Load<Texture2D>("Backgrounds/Level2");

            //creating player character
            player = new Character(content.Load<Texture2D>("Player/head"), new Vector2(50, 50), graphics);
            player2 = new Character(content.Load<Texture2D>("Player/head"), new Vector2(50, 50), graphics); //New: Creating new player
            player2.position.X = 300;


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            //draw backround
            spriteBatch.Draw(_tempBackgroundTexture, new Vector2(0, 0), Color.White);

            //draw player character
            player.Draw(spriteBatch);
            player2.Draw(spriteBatch); //New: Draw sprite for second player

            //Draw platform 
            foreach(Platform platform in platform)
            {
                platform.Draw(gameTime, spriteBatch);
            }
            

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            //updating character with gametime
            player.Update(gameTime);
            player2.Update(gameTime); //New: Update player with gametime

            //updating the collision detection in platform class with player character
            foreach (Platform platform in platform)
            {
                platform.Update(player);
                platform.Update(player2); //NEW
            }



            //Code for more than 1 player
            PlayerIndex[] players =  {PlayerIndex.One, PlayerIndex.Two};


            foreach (PlayerIndex index in players)
            {
                //Gamepad to player connection
                GamePadCapabilities capabilities = GamePad.GetCapabilities(index);

                //getting gamepad state
                GamePadState gstate = Gamepad.GetState(index);

                //Gamepad joystick detection for movment
                if (capabilities.HasLeftXThumbStick)
                {
                    switch (index)
                    {
                        case PlayerIndex.One:
                            player.position.X += gstate.ThumbSticks.Left.X * 10.0f; //uses the angle of joystick to determine movement speed
                            break;
                        case PlayerIndex.Two:
                            player2.position.X += gstate.ThumbSticks.Left.X * 10.0f; //uses the angle of joystick to determine movement speed
                            break;
                        case PlayerIndex.Three:
                            player3.position.X += gstate.ThumbSticks.Left.X * 10.0f; //uses the angle of joystick to determine movement speed
                            break;
                        case PlayerIndex.Four:
                            player4.position.X += gstate.ThumbSticks.Left.X * 10.0f; //uses the angle of joystick to determine movement speed
                            break;
                    }

                }

                //Gamepad A/X button for jumping
                if (capabilities.HasAButton && gstate.IsButtonDown(Buttons.A))
                {
                    switch (index)
                    {
                        case PlayerIndex.One:
                            player.Jump();
                            break;
                        case PlayerIndex.Two:
                            player2.Jump();
                            break;
                        case PlayerIndex.Three:
                            player3.Jump();
                            break;
                        case PlayerIndex.Four:
                            player4.Jump();
                            break;
                    }
                }
            }

        }
    }
}