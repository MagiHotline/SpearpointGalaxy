using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
 
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        StartScene startScene;
        HelpScene helpScene;
        PlayScene playScene;
        LeaderboardScreen leaderboardScreen;
        GameOverScreen gameoverScreen;
        Sound menueffect;
        

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
            menueffect = new Sound("openmenu_effect", SoundType.Effect);
        }

 
        protected override void Initialize()
        {
            base.Initialize();
        }

      
        protected override void LoadContent()
        {           
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Common.SpriteBatch = spriteBatch;
            startScene = new StartScene();
            helpScene = new HelpScene();
            playScene = new PlayScene();
            gameoverScreen = new GameOverScreen();
            leaderboardScreen = new LeaderboardScreen(playScene);
        }


        protected override void UnloadContent()
        {
          
        }

        protected override void Update(GameTime gameTime)
        {
            Common.GameTime = gameTime;
            KeyboardInput.Update();          
            startScene.Update();
            HandleScenes();
            playScene.Update();
            gameoverScreen.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Common.SpriteBatch.Begin();
            startScene.Draw();
            helpScene.Draw();
            playScene.Draw();
            gameoverScreen.Draw();
            leaderboardScreen.Draw();
            Common.SpriteBatch.End();
            base.Draw(gameTime);
        }


        /// <summary>
        /// Gestisce le scene
        /// </summary>
        private void HandleScenes()
        {
            if (Scene.Active == ActiveScene.Start)
            {
                if (KeyboardInput.KeyPressed(Keys.Enter))
                {
                    if (startScene.Menu.SelectedIndex == StartScene.SEL_NEW_GAME)
                    {
                        menueffect.Play();
                        Scene.Active = ActiveScene.Play;
                        playScene = new PlayScene();
                    }
                    else if (startScene.Menu.SelectedIndex == StartScene.SEL_HELP)
                    {
                        menueffect.Play();
                        Scene.Active = ActiveScene.Help;
                    }
                    else if(startScene.Menu.SelectedIndex == StartScene.SEL_LEADERBOARD)
                    {
                        menueffect.Play();
                        leaderboardScreen = new LeaderboardScreen(playScene);
                        Scene.Active = ActiveScene.Leaderboard;

                    }
                    else if (startScene.Menu.SelectedIndex == StartScene.SEL_EXIT)
                    {
                        Exit();
                    }
                }
            }
            else if (Scene.Active == ActiveScene.Play || Scene.Active == ActiveScene.Help || Scene.Active == ActiveScene.Leaderboard) 
            {
                if (KeyboardInput.KeyPressed(Keys.Escape))
                {
                    menueffect.Play();
                    startScene.Initialize();
                    Scene.Active = ActiveScene.Start;
                }
            }
            else if(Scene.Active == ActiveScene.GameOver)
            {
                if(KeyboardInput.KeyPressed(Keys.Enter))
                {
                    if(gameoverScreen.Menu.SelectedIndex == GameOverScreen.SEL_CONTINUE)
                    {
                        menueffect.Play();
                        Scene.Active = ActiveScene.Play;
                        playScene = new PlayScene();
                    } 
                    else if(gameoverScreen.Menu.SelectedIndex == GameOverScreen.RETURN_TO_MENU)
                    {
                        menueffect.Play();
                        Scene.Active = ActiveScene.Start;

                    } 
                    else if(gameoverScreen.Menu.SelectedIndex == GameOverScreen.SEL_EXIT)
                    {
                        Exit();
                    }
                }
            }
        }
    }
}
