using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FightingGame
{
    public abstract class GameState
    {
        public GameState(FightingGame game)
        {
            Game = game;

            GameComponents = new List<GameComponent>();
        }

        public FightingGame Game
        {
            get;
        }

        public List<GameComponent> GameComponents
        {
            get;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (GameComponent gameComponent in GameComponents)
            {
                gameComponent.Draw(gameTime, spriteBatch);
            }
        }

        public virtual void LoadContent() { }

        public virtual void OnEnter() { }

        public virtual void OnExit() { }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameComponent gameComponent in GameComponents)
            {
                gameComponent.Update(gameTime);
            }
        }
    }
}
