using System;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project4
{
    public static class InputManager
    {
        private static Vector2 _direction;
        public static Vector2 Direction => _direction;

        public static bool Moving => _direction != Vector2.Zero;

        public static void Update()
        {
            var keyboardState = Keyboard.GetState();

            _direction = Vector2.Zero;

            if (keyboardState.GetPressedKeyCount() > 0)
            {
                if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
                if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
                if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
                if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;
            }

            if (_direction != Vector2.Zero)
            {
                _direction.Normalize();
            }
        }
    }
}
