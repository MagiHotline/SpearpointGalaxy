using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    /// <summary>
    /// Classe per la gestione di un animazione
    /// </summary>
    class Animation
    {
        private Texture2D texture;
        private Vector2 position;
        private int frames;
        private int frame;
        private double elapsed;
        private int delay;
        private int width;
        private int height;
        private Rectangle rectangle;

        /// <summary>Crea un nuovo oggetto Animation.</summary>
        /// <param name="textureName">Nome della texture contenente i frame.</param>
        /// <param name="frames">Numero di frame.</param>
        public Animation(string textureName, int frames)
        {
            texture = Common.Content.Load<Texture2D>(textureName);
            position = Vector2.Zero;
            this.frames = frames;
            frame = 0;
            elapsed = 0;
            delay = 100;
            width = texture.Width / frames;
            height = texture.Height;
            rectangle = new Rectangle(frame * width, 0, width, height);
        }

        /// <summary>Posizione dell'animazione.</summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>Numero di frame dell'animazione.</summary>
        public int Frames
        {
            get { return frames; }
        }

        /// <summary>Larghezza dell'animazione.</summary>
        public int Width
        {
            get { return width; }
        }

        /// <summary>Altezza dell'animazione.</summary>
        public int Height
        {
            get { return height; }
        }

        /// <summary>Tempo di attesa dell'animazione.</summary>
        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        /// <summary>Aggiorna l'animazione.</summary>
        public void Update()
        {
            elapsed += Common.GameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                frame++;
                if (frame == frames) frame = 0;
                elapsed = 0;
                rectangle = new Rectangle(frame * width, 0, width, height);
            }
        }

        /// <summary>Disegna l'animazione.</summary>
        public void Draw()
        {
            Common.SpriteBatch.Draw(texture, position, rectangle, Color.White);
        }

    }
}
