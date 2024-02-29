using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Animation
    {
        private Texture2D texture;
        private Vector2 position;
        private int frames;
        private int frame;
        private int delay; //attesa in millisecondi
        private double elapsed; //tempo passato dall'ultimo frame
        private int width;
        private Rectangle rectangle;

        public Animation(string textureName, int frames)
        {
            texture = Common.Content.Load<Texture2D>(textureName);
            this.frames = frames;
            frame = 0;
            position = Vector2.Zero;
            elapsed = 0;
            delay = 1000;
            width = texture.Width / frames;
            rectangle = new Rectangle(frame * width, 0, width, texture.Height); 


        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value;  }
        }

        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        public void Update()
        {
            elapsed += Common.GameTime.ElapsedGameTime.TotalMilliseconds;
            if( elapsed >= delay )
            {
                frame++;
                if (frame == frames)
                {
                    frame = 0;
                }
                elapsed = 0;
                rectangle = new Rectangle(frame * width, 0, width, texture.Height);
            }
        }

        public void Draw()
        {
            Common.SpriteBatch.Draw(texture, position, rectangle, Color.White);
        }





    }
}
