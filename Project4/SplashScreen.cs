using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace Project4
{
    internal class SplashScreen
    {
        public static Texture2D Background { get; set; }
        static int timeCounter = 0;
        static Color color = Color.White;
        public static SpriteFont Font { get; set; }
        static int[] massiv = Enumerable.Range(1, 255).ToArray();
        static int[] combinet = massiv.Concat(Enumerable.Reverse(massiv)).ToArray(); //массив - костыль


        static public void Draw(SpriteBatch spriteBatch)
        {
            var wight = 800;
            var height = 600;

            spriteBatch.Draw(Background, new Rectangle(0, 0, wight, height), Color.White);
            spriteBatch.DrawString(Font, "Бегущий в лабиринте", new Vector2(30, 50), color);
        }

        static public void Update()
        {
            color = Color.FromNonPremultiplied(0, 0, 0, combinet[timeCounter % 510]);
            timeCounter += 5;

        }
    }
}