using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BattleGame2D.Controls;

namespace BattleGame2D.States
{
   
  public class MenuState : State
  {
    private List<Component> _components;

        private int bufferWidth;
        private int bufferHeight;
        GraphicsDeviceManager graphics;

        Texture2D titleCard;
        Vector2 titlePosition;


    public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int bufferWidth, int bufferHeight, GraphicsDeviceManager graphics) 
      : base(game, graphicsDevice, content)
    {
        this.bufferWidth = bufferWidth;
        this.bufferHeight = bufferHeight;
            this.graphics = graphics;
            titleCard = _content.Load<Texture2D>("ConflictPixelLogo");
            titlePosition = new Vector2((int)(bufferWidth/3.2), bufferHeight/10);
            var buttonTexture = _content.Load<Texture2D>("Controls/PlayButton");
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            int width = (int)(this.bufferWidth / 1.35);
            int height = this.bufferHeight;

            

            var playButton = new Button(buttonTexture, buttonFont)
        {
            Position = new Vector2((int)(width / 3.3), height/2),
        Text = "PLAY NOW"
      };

      playButton.Click += NewGameButton_Click;

      var settingsButton = new Button(buttonTexture, buttonFont)
      {
        Position = new Vector2(width, (int)(height / 2)),
        Text = "Settings",
      };

      settingsButton.Click += SettingsButton_Click;

      var quitGameButton = new Button(buttonTexture, buttonFont)
      {
        Position = new Vector2((int)(width * 1.7), (int)(height / 2)),
        Text = "Quit Game",
      };

      quitGameButton.Click += QuitGameButton_Click;

      _components = new List<Component>()
      {
        playButton,
        settingsButton,
        quitGameButton,
      };
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

            //spriteBatch.Begin();
            spriteBatch.Draw(titleCard, titlePosition, Color.White);
            foreach (var component in _components)
        component.Draw(gameTime, spriteBatch);

      spriteBatch.End();
    }

    private void SettingsButton_Click(object sender, EventArgs e)
    {

    }

    private void NewGameButton_Click(object sender, EventArgs e)
    {
      _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
    }

    public override void PostUpdate(GameTime gameTime)
    {
      // remove sprites if they're not needed
    }

    public override void Update(GameTime gameTime)
    {
      foreach (var component in _components)
        component.Update(gameTime);
    }

    private void QuitGameButton_Click(object sender, EventArgs e)
    {
      _game.Exit();
    }
  }
}
