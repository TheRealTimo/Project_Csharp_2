using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ConflictGame
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MouseState mouseState, previousMouseState;
        KeyboardState ks;
        Color col;

        const byte MENU = 0, PLAYGAME = 1, GAMEOVER = 2, OPTIONS = 3;
        int CurrentScreen = MENU;

        //Variables for the MENU Screen
        Texture2D optionText, playgameText;
        Button playGameButton, optionsButton;
        float screenwidth, screenheight;
        Texture2D bgimage;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        
        protected override void Initialize()
        {
            col = Color.White;
            screenheight = graphics.GraphicsDevice.Viewport.Height;
            screenwidth = graphics.GraphicsDevice.Viewport.Width;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Things we want to load in the MENU screen.
            optionText = Content.Load<Texture2D>("options");
            playgameText = Content.Load<Texture2D>("playgame");
            bgimage = Content.Load<Texture2D>("Background");

            optionsButton = new Button(new Rectangle(300, 200, optionText.Width, optionText.Height), true);
            optionsButton.load(Content, "options");

            playGameButton = new Button(new Rectangle(300, 100, playgameText.Width, playgameText.Height), true);
            playGameButton.load(Content, "playgame");

        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //Checking the state of our mouse.
            mouseState = Mouse.GetState();
            ks = Keyboard.GetState();


            switch (CurrentScreen)
            {
                case MENU:
                    //What we want to happen in the MENU screen goes in here.
                    //GO TO PLAYGAME SCREEN
                    if (playGameButton.update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != previousMouseState && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        CurrentScreen = PLAYGAME;
                    }

                    //GO TO OPTIONS SCREEN
                    if (optionsButton.update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != previousMouseState && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        CurrentScreen = OPTIONS;
                    }

                    break;

                case OPTIONS:
                    //Whatever Options you want to DISPLAY
                    if (ks.IsKeyDown(Keys.A))
                    {
                        CurrentScreen = MENU;
                    }
                    break;

                case PLAYGAME:
                    //What we want to happen when we play our GAME goes in here.
                    if (ks.IsKeyDown(Keys.A))
                    {
                        CurrentScreen = MENU;
                    }
                    break;

                case GAMEOVER:
                    //What we want to happen when our GAME is OVER goes in here.
                    break;

            }

            previousMouseState = mouseState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();


            switch (CurrentScreen)
            {
                case MENU:
                    spriteBatch.Draw(bgimage, new Rectangle(0, 0, bgimage.Width, bgimage.Height), Color.White);
                    spriteBatch.Draw(playgameText, new Rectangle(100, 100, playgameText.Width, playgameText.Height), Color.White);
                    spriteBatch.Draw(optionText, new Rectangle(100, 200, optionText.Width, optionText.Height), Color.White);
                    // spriteBatch.Draw(bgimage, new Rectangle(800, 420, bgimage.Width, bgimage.Height), Color.White);
                    break;

                case OPTIONS:
                    spriteBatch.Draw(optionText, new Rectangle(300, 200, optionText.Width, optionText.Height), Color.White);
                    break;

                case PLAYGAME:
                    //What we want to happen when we play our GAME goes in here.
                    spriteBatch.Draw(playgameText, new Rectangle(300, 100, playgameText.Width, playgameText.Height), Color.White);
                    spriteBatch.Draw(playgameText, new Rectangle(300, 200, playgameText.Width, playgameText.Height), Color.White);
                    spriteBatch.Draw(playgameText, new Rectangle(300, 300, playgameText.Width, playgameText.Height), Color.White);
                    break;

                case GAMEOVER:
                    //What we want to happen when our GAME is OVER goes in here.
                    break;

            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
