using Microsoft.Xna.Framework;
using Project3;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project4
{
    public class GameManager
    {
        private readonly Map _map;
        private readonly Hero _hero;
        private Matrix _translation;
        private Coin _coin;
        public GameManager()
        {
            _map = new();
            _hero = new(Globals.Content.Load<Texture2D>("hero2"), new(Globals.WindowSize.X / 2, Globals.WindowSize.Y / 2));
            _hero.SetBounds(_map.MapSize, _map.TileSize);
            _coin = new(new Vector2(500, 600));
        }

        private void CalculateTranslation()
        {
            var dx = (Globals.WindowSize.X / 2) - _hero.Position.X;
            dx = MathHelper.Clamp(dx, -_map.MapSize.X + Globals.WindowSize.X + (_map.TileSize.X / 2), _map.TileSize.X / 2);
            var dy = (Globals.WindowSize.Y / 2) - _hero.Position.Y;
            dy = MathHelper.Clamp(dy, -_map.MapSize.Y + Globals.WindowSize.Y + (_map.TileSize.Y / 2), _map.TileSize.Y / 2);
            _translation = Matrix.CreateTranslation(dx, dy, 0f);
        }

        public void Update()
        {
            InputManager.Update();
            _hero.Update();
            _coin.Update();
            CalculateTranslation();
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin(transformMatrix: _translation);
            _map.Draw();
            _hero.Draw();
            _coin.Draw();
            Globals.SpriteBatch.End();
        }
    }
}
