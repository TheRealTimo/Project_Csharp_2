using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FightingGame
{
    public abstract class GameState
    {
        private readonly FightingGame _game;
        private readonly List<GameComponent> _gameComponents = new List<GameComponent>();

        public GameState(FightingGame game)
        {
            _game = game;
        }

        public FightingGame Game
        {
            get
            {
                return _game;
            }
        }

        public List<GameComponent> GameComponents
        {
            get
            {
                return _gameComponents;
            }
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
