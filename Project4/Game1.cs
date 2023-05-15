using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project3;
using System;
using System.Collections.Generic;

namespace Project4
{
    enum Stat
    {
        SplashScreen,
        Game,
        Final,
        Pause
    }

    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;
        private List<Component> _gameComponents;
        private Color _backgroundColour = Color.CornflowerBlue;
        Stat Stat = Stat.SplashScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() 
        {
            Globals.WindowSize = new(800, 600);
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            IsMouseVisible = true;
            _graphics.ApplyChanges();
            

            Globals.Content = Content;
            _gameManager = new();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;

            SplashScreen.Background = Content.Load<Texture2D>("background");
            SplashScreen.Font = Content.Load<SpriteFont>("Fonts/Font");

            var startButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(30, 200),
                Text = "Start",
            };

            var resumeButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(30, 300),
                Text = "Resume",
            };

            var quitButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(30, 400),
                Text = "Quit",
            };

            startButton.Click += StartButton_Click;
            quitButton.Click += QuitButton_Click;

            _gameComponents = new List<Component>()
            {
                startButton,
                resumeButton,
                quitButton,
            };
        }

        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            Stat = Stat.Game;
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                Stat = Stat.SplashScreen;

            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update();
                    foreach (var component in _gameComponents)
                        component.Update(gameTime);
                    break;
                case Stat.Game:
                    break;
            }

            Globals.Update(gameTime);
            _gameManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _gameManager.Draw();

            _spriteBatch.Begin();

            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Draw(_spriteBatch);
                    foreach (var component in _gameComponents)
                        component.Draw(gameTime, _spriteBatch);
                    break;
                case Stat.Game:     
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}