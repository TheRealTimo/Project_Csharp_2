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
        Character player;

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

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            //draw backround
            spriteBatch.Draw(_tempBackgroundTexture, new Vector2(0, 0), Color.White);

            //draw player character
            player.Draw(spriteBatch);

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

            //updating the collision detection in platform class with player character
            foreach (Platform platform in platform)
            {
                platform.Update(player);
            }

            //Code for more than 1 player
            PlayerIndex playerindex = PlayerIndex.One;
            PlayerIndex[] players = new PlayerIndex[] { PlayerIndex.One };

            foreach (PlayerIndex index in players)
            {
                //Gamepad to player connection
                GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

                //getting gamepad state
                GamePadState gstate = Gamepad.GetState();

                //Gamepad joystick detection for movment
                if (capabilities.HasLeftXThumbStick)
                {
                    player.position.X += gstate.ThumbSticks.Left.X * 10.0f;//uses the angle of joystick to determine movement speed
                }
                //Gamepad A/X button for jumping
                if (capabilities.HasAButton && gstate.IsButtonDown(Buttons.A))
                {
                    player.Jump(); //calls jump function from player
                }
            }
        }
    }
}