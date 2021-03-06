using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;

namespace FightingGame.GameComponents
{
    public class Player : GameComponent
    {
        private int _attackCooldown = 0;

        public int playerIndex;

        private Vector2 _direction = new Vector2(0, 0);
        private Vector2 _gravity = new Vector2(0, 2000);

        private int _health = 100;

        private AnimatedSprite _sprite;

        private Vector2 _velocity = new Vector2(0, 0);
        private Vector2 _velocityAcceleration = new Vector2(4000, 0);
        private Vector2 _velocityFriction = new Vector2(4000, 0);
        private Vector2 _velocityMaximum = new Vector2(400, 2000);

        public Player(GameState gameState, Vector2 position, int playerIndex) : base(gameState, position)
        {
            BoundingBox = new Rectangle(0, 0, 40, 40);

            this.playerIndex = playerIndex;

            _sprite = new AnimatedSprite(GameState.Game.SpriteSheets["Player"]);
        }

        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                _health = value;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        public Vector2 VelocityAcceleration
        {
            get
            {
                return _velocityAcceleration;
            }
        }

        public Vector2 VelocityFriction
        {
            get
            {
                return _velocityFriction;
            }
        }

        public Vector2 VelocityMaximum
        {
            get
            {
                return _velocityMaximum;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            float delta = (float) gameTime.ElapsedGameTime.TotalSeconds;

            spriteBatch.Draw(_sprite, new Vector2()
            {
                X = MathF.Floor(Position.X) + (BoundingBox.Width / 2),
                Y = MathF.Floor(Position.Y) + (BoundingBox.Height / 2)
            });

            DrawHealthbar(spriteBatch);
        }

        public void Idle(GameTime gameTime)
        {
            float delta = (float) gameTime.ElapsedGameTime.TotalSeconds;

            _velocity.X = Math.Min(0, Math.Abs(_velocity.X) - (_velocityFriction.X * delta) * Math.Sign(_velocity.X));
        }

        public bool isJumping()
        {
            if (_velocity.Y > 0)
            {
                return true;
            }

            return false;
        }

        public bool isFalling()
        {
            if (_velocity.Y < 0)
            {
                return true;
            }

            return false;
        }

        public void Jump()
        {
            List<GameComponent> blocks = GameState.GameComponents.FindAll(gameComponent => gameComponent is Block);            

            Position = new Vector2(Position.X, Position.Y + 1);

            bool collision = false;

            foreach (GameComponent block in blocks)
            {
                if (block.BoundingBox.Intersects(BoundingBox))
                {
                    collision = true;
                }
            }

            if (collision)
            {
                _velocity.Y -= 1000;
            }

            Position = new Vector2(Position.X, Position.Y - 1);
        }

        public void Punch()
        {
            List<GameComponent> players = GameState.GameComponents.FindAll(gameComponent => gameComponent is Player);

            foreach (GameComponent player in players)
            {
                if (player == this)
                {
                    continue;
                }

                if (player.BoundingBox.Intersects(this.BoundingBox))
                {
                    ((Player) player).Health -= 1;
                }
            }

            _attackCooldown = 30;
        }

        public void RunLeft(GameTime gameTime)
        {
            float delta = (float) gameTime.ElapsedGameTime.TotalSeconds;

            _velocity.X = Math.Max(-_velocityMaximum.X, _velocity.X - (_velocityAcceleration.X * delta));
            _direction.X = -1;
        }

        public void RunRight(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _velocity.X = Math.Min(_velocityMaximum.X, _velocity.X + (_velocityAcceleration.X * delta));
            _direction.X = 1;
        }

        public override void Update(GameTime gameTime)
        {
            float delta = (float) gameTime.ElapsedGameTime.TotalSeconds;

            List<GameComponent> blocks = GameState.GameComponents.FindAll(gameComponent => gameComponent is Block);
            List<GameComponent> spikes = GameState.GameComponents.FindAll(gameComponent => gameComponent is Spike);
           

            _velocity.X += (Math.Min(Math.Abs(_gravity.X) * delta, _velocityMaximum.X)) * Math.Sign(_gravity.X);
			_velocity.Y += (Math.Min(Math.Abs(_gravity.Y) * delta, _velocityMaximum.Y)) * Math.Sign(_gravity.Y);

            if (_velocity.X != 0)
            {
                float distance = Math.Abs(_velocity.X * delta);

                while (distance > 0)
                {
                    float pixels = distance > 1 ? 1 : distance;

                    distance -= pixels;

                    Position = new Vector2(Position.X + pixels * Math.Sign(_velocity.X), Position.Y);

                    bool collision = false;

                    foreach (GameComponent block in blocks)
                    {
                        if (block.BoundingBox.Intersects(BoundingBox))
                        {
                            collision = true;
                        }
                    }
           /*         foreach (GameComponent spike in spikes)
                    {
                        if (spike.BoundingBox.Intersects(BoundingBox))
                        {
                            collision = true;
                            ((Player) player).Health -= 1;
                        }
*/

                        if (collision)
                    {
                        Position = new Vector2(Position.X - pixels * Math.Sign(_velocity.X), Position.Y);

                        _velocity = new Vector2(0, _velocity.Y);
                    }
                }
            }

            if (_velocity.Y != 0)
            {
				float distance = Math.Abs(_velocity.Y * delta);

				while (distance > 0)
                {
					float pixels = distance > 1 ? 1 : distance;

					distance -= pixels;

					Position = new Vector2(Position.X, Position.Y + pixels * Math.Sign(_velocity.Y));

					bool collision = false;

					foreach (GameComponent block in blocks)
                    {
						if (block.BoundingBox.Intersects(BoundingBox))
                        {
							collision = true;
                        }
                    }

					if (collision)
                    {
						Position = new Vector2(Position.X, Position.Y - pixels * Math.Sign(_velocity.Y));

                        _velocity = new Vector2(_velocity.X, 0);
					}
                }
            }

            if (_health <= 0)
            {
                

                Position = new Vector2(0, 0);
            }

            UpdateAnimation(gameTime);
        }

        private void DrawHealthbar(SpriteBatch spriteBatch)
        {
            int width = 100;
            int height = 25;

            spriteBatch.Draw(GameState.Game.Textures["PlayerCount" + playerIndex], new Vector2(BoundingBox.X, BoundingBox.Y), new Color(255, 255, 255));

            int x = 150 + (500 * (playerIndex - 1));
            int y = 100;

            Rectangle background = new Rectangle
            {
                X = x,
                Y = y,
                Width = width,
                Height = height
            };

            Rectangle foreground = new Rectangle
            {
                X = x,
                Y = y,
                Width = _health,
                Height = height
            };

            spriteBatch.FillRectangle(background, new Color(255, 255, 255));
            spriteBatch.FillRectangle(foreground, new Color(0, 128, 0));

            spriteBatch.Draw(GameState.Game.Textures["PlayerHeart" + playerIndex], new Vector2(x - 32, y - 16), new Color(255, 255, 255));
        }

        private void UpdateAnimation(GameTime gameTime)
        {
            float delta = (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (_velocity.Y < 0)
            {
                if (_direction.X < 0)
                {
                    _sprite.Play("IdleLeft");
                }
                else
                {
                    _sprite.Play("IdleRight");
                }
            }

            if (_velocity.Y > 0)
            {
                if (_direction.X < 0)
                {
                    _sprite.Play("FallLeft");
                }
                else
                {
                    _sprite.Play("FallRight");
                }
            }

            if (_velocity.Y == 0)
            {
                if (_velocity.X == 0)
                {
                    if (_attackCooldown > 0)
                    {
                        if (_direction.X < 0)
                        {
                            _sprite.Play("PunchLeft");
                        }
                        else
                        {
                            _sprite.Play("PunchRight");
                        }

                        _attackCooldown -= 1;
                    }
                    else
                    {
                        if (_direction.X < 0)
                        {
                            _sprite.Play("IdleLeft");
                        }
                        else
                        {
                            _sprite.Play("IdleRight");
                        }
                    }
                }
                else
                {
                    if (_direction.X < 0)
                    {
                        _sprite.Play("RunLeft");
                    }
                    else
                    {
                        _sprite.Play("RunRight");
                    }
                }
            }

            _sprite.Update(delta);
        }
    }
}
