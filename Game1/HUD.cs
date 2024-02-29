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
    /// Classe per la gestione della HUD
    /// </summary>
    class HUD
    {
        private SpriteFont font;
        private Vector2 position;
        private Color color;
        private Spaceship spaceship;
        private double elapsed;
        public string text;

        /// <summary>
        /// Crea un oggetto HUD
        /// </summary>
        /// <param name="fontName">Nome del font</param>
        public HUD(string fontName, Spaceship spaceship)
        {
            font = Common.Content.Load<SpriteFont>(fontName);
            position = Vector2.Zero;
            color = Color.White;
            this.spaceship = spaceship;
        }

        /// <summary>
        /// Posizione della HUD
        /// </summary>
        /// <value>Ritorna o imposta la posizione della HUD</value>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Colore della HUD
        /// </summary>
        /// <value>Ritorna o imposta il colore della HUD</value>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// Testo della HUD
        /// </summary>
        /// <value>Ritorna o imposta il testo</value>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// Disegna la HUD
        /// </summary>
        public void Draw()
        {
            elapsed += Common.GameTime.ElapsedGameTime.TotalSeconds;
            text = "Time: " + (int)Math.Truncate(elapsed) + " | Score: " + spaceship.Timealive;
            Common.SpriteBatch.DrawString(font, text, position, color);
        }
    }
}
