using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Project3;

namespace Project4
{
    public class Coin
    {
        private static Texture2D _texture;
        private Vector2 _position;
        private readonly Animation _animation;

        public Coin(Vector2 position)
        {
            _texture ??= Globals.Content.Load<Texture2D>("coin");
            _animation = new(_texture, 12, 1, 0.1f);
            _position = position;
        }

        public void Update()
        {
            _animation.Update();
        }

        public void Draw()
        {
            _animation.Draw(_position);
        }
    }
}
