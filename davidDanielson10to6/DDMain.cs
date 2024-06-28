using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace davidDanielson10to6
{
    public class DDMain : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Level level;

        private WaterTile water;

        private Player david;

        public DDMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1297;
            _graphics.PreferredBackBufferHeight = 864;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D groundTexture = Content.Load<Texture2D>("groundSprites");
            Texture2D brushTexture = Content.Load<Texture2D>("brushSprites");
            level = new Level("testLevel", groundTexture, brushTexture);

            Texture2D waterTexture = Content.Load<Texture2D>("water_sprites");
            water = new WaterTile(waterTexture, 24);

            Texture2D playerTexture = Content.Load<Texture2D>("worker_sprites");
            david = new Player(playerTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            water.Update();

            david.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            water.Draw(_spriteBatch);

            level.Draw(_spriteBatch);

            david.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
