using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Animation eroe;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Common.Content = Content;
            Window.Title = Common.GameTitle;
            graphics.PreferredBackBufferWidth = Common.GameWidth;
            graphics.PreferredBackBufferHeight = Common.GameHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
         
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Common.SpriteBatch = spriteBatch;
            eroe = new Animation("player", 3);
            eroe.Delay = 200;
        }

       
        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            Common.GameTime = gameTime;
            eroe.Update();

            base.Update(gameTime);
        }

   
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Common.SpriteBatch.Begin();
            eroe.Draw();
            Common.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
