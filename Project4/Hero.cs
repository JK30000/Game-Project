using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project3;

namespace Project4
{
    public class Hero : Sprite
    {
        private const float SPEED = 250;
        private Vector2 _minPos, _maxPos;
        private Vector2 _possition = new Vector2(100, 100);
        private readonly AnimationManager _anims = new AnimationManager();

        public Hero(Texture2D texture, Vector2 position) : base(texture, position)
        {
            var heroTexture = Globals.Content.Load<Texture2D>("hero2");
            _anims.AddAnimation(new Vector2(0, 1), new(heroTexture, 8, 8, 0.1f, 1));
            _anims.AddAnimation(new Vector2(-1, 0), new(heroTexture, 8, 8, 0.1f, 2));
            _anims.AddAnimation(new Vector2(1, 0), new(heroTexture, 8, 8, 0.1f, 3));
            _anims.AddAnimation(new Vector2(0, -1), new(heroTexture, 8, 8, 0.1f, 4));
        }

        public void SetBounds(Point mapSize, Point tileSize)
        {
            _minPos = new((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
            _maxPos = new(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
        }

        public void Update()
        {
            if (InputManager.Moving)
            {
                _possition += Vector2.Normalize(InputManager.Direction) * SPEED * Globals.Time;
            }
            _anims.Update(InputManager.Direction);

            Position += InputManager.Direction * Globals.Time * SPEED;
            Position = Vector2.Clamp(Position, _minPos, _maxPos);
        }

        public void Draw()
        {
            _anims.Draw(_possition);
        }
    }
}
