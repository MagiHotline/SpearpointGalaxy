using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class BackgroundAnimated
    {
        private Texture2D texture;
        private double elapsed = 0;

        /// <summary>
        /// Crea un nuovo oggetto Background
        /// </summary>
        public BackgroundAnimated() {}

        public void Update()
        {
            elapsed += Common.GameTime.ElapsedGameTime.TotalMilliseconds;
            if(elapsed > 0)
            {
                texture = Common.Content.Load<Texture2D>("frame1");
            }
            if(elapsed > 0 && elapsed < 100)
            {
                texture = Common.Content.Load<Texture2D>("frame2");
            }
            if(elapsed > 100 && elapsed < 200)
            {
                texture = Common.Content.Load<Texture2D>("frame3");
            }
            if (elapsed > 200 && elapsed < 300)
            {
                texture = Common.Content.Load<Texture2D>("frame4");
            }
            if (elapsed > 300 && elapsed < 400)
            {
                texture = Common.Content.Load<Texture2D>("frame5");
            }
            if (elapsed > 400 && elapsed < 500)
            {
                texture = Common.Content.Load<Texture2D>("frame6");
            }
            if (elapsed > 500 && elapsed < 600)
            {
                texture = Common.Content.Load<Texture2D>("frame7");
            }
            if (elapsed > 600 && elapsed < 700)
            {
                texture = Common.Content.Load<Texture2D>("frame8");
            }
            if (elapsed > 700 && elapsed < 800)
            {
                texture = Common.Content.Load<Texture2D>("frame9");
            }
            if (elapsed > 800 && elapsed < 900)
            {
                texture = Common.Content.Load<Texture2D>("frame10");
            }
            if (elapsed > 1000 && elapsed < 1100)
            {
                texture = Common.Content.Load<Texture2D>("frame11");
            }
            if (elapsed > 1100 && elapsed < 1200)
            {
                texture = Common.Content.Load<Texture2D>("frame12");
            }
            if (elapsed > 1200 && elapsed < 1300)
            {
                texture = Common.Content.Load<Texture2D>("frame13");
            }
            if (elapsed > 1300 && elapsed < 1400)
            {
                texture = Common.Content.Load<Texture2D>("frame14");
            }
            if (elapsed > 1400 && elapsed < 1500)
            {
                texture = Common.Content.Load<Texture2D>("frame15");
            }
            if (elapsed > 1500 && elapsed < 1600)
            {
                texture = Common.Content.Load<Texture2D>("frame16");
            }
            if (elapsed > 1600 && elapsed < 1700)
            {
                texture = Common.Content.Load<Texture2D>("frame17");
            }
            if (elapsed > 1700 && elapsed < 1800)
            {
                texture = Common.Content.Load<Texture2D>("frame18");
            }
            if (elapsed > 1800 && elapsed < 1900)
            {
                texture = Common.Content.Load<Texture2D>("frame19");
            }
            if (elapsed > 1900 && elapsed < 2000)
            {
                texture = Common.Content.Load<Texture2D>("frame19");
            }
            if (elapsed > 2000 && elapsed < 2100)
            {
                texture = Common.Content.Load<Texture2D>("frame20");
            }
            if (elapsed > 2100 && elapsed < 2200)
            {
                texture = Common.Content.Load<Texture2D>("frame21");
            }
            if (elapsed > 2200 && elapsed < 2300)
            {
                texture = Common.Content.Load<Texture2D>("frame22");
            }
            if (elapsed > 2300 && elapsed < 2400)
            {
                texture = Common.Content.Load<Texture2D>("frame23");
            }
            if (elapsed > 2400 && elapsed < 2500)
            {
                texture = Common.Content.Load<Texture2D>("frame24");
            }
            if (elapsed > 2500 && elapsed < 2600)
            {
                texture = Common.Content.Load<Texture2D>("frame25");
            }
            if (elapsed > 2600 && elapsed < 2700)
            {
                texture = Common.Content.Load<Texture2D>("frame26");
            }
            if (elapsed > 2700 && elapsed < 2800)
            {
                texture = Common.Content.Load<Texture2D>("frame27");
            }
            if (elapsed > 2800 && elapsed < 2900)
            {
                texture = Common.Content.Load<Texture2D>("frame28");
            }
            if (elapsed > 2900 && elapsed < 3000)
            {
                texture = Common.Content.Load<Texture2D>("frame29");
            }
            if (elapsed > 3000 && elapsed < 3100)
            {
                texture = Common.Content.Load<Texture2D>("frame30");
            }
            if (elapsed > 3100 && elapsed < 3200)
            {
                texture = Common.Content.Load<Texture2D>("frame31");
            }
            if (elapsed > 3200 && elapsed < 3300)
            {
                texture = Common.Content.Load<Texture2D>("frame32");
            }
            if (elapsed > 3300 && elapsed < 3400)
            {
                texture = Common.Content.Load<Texture2D>("frame33");
            }
            if (elapsed > 3400 && elapsed < 3500)
            {
                texture = Common.Content.Load<Texture2D>("frame34");
            }
            if (elapsed > 3500 && elapsed < 3600)
            {
                texture = Common.Content.Load<Texture2D>("frame35");
            }
            if (elapsed > 3600 && elapsed < 3700)
            {
                texture = Common.Content.Load<Texture2D>("frame36");
            }
            if(elapsed > 3700)
            {
                elapsed = 0;
            }
            
        }

        /// <summary>
        /// Disegna lo sfondo
        /// </summary>
        public void Draw()
        {
            Common.SpriteBatch.Draw(texture, Vector2.Zero, Color.White);
        }
    }
}
