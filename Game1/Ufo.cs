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
    /// Classe che gestisce un singolo UFO
    /// </summary>
    class Ufo
    {
        private Texture2D texture;
        private Vector2 position;
        public int speed;
        public bool isVisible;
        private Random random = new Random();

        /// <summary>
        /// Crea un oggetto UFO
        /// </summary>
        /// <param name="textureName">Nome del texture</param>
        /// <param name="position">Posizione dell'ufo</param>
        public Ufo(string textureName, Vector2 position)
        {
            isVisible = true;
            texture = Common.Content.Load<Texture2D>(textureName);
            this.position = position;
            speed = 10;
        }

        /// <summary>
        /// Texture dell'ufo
        /// </summary>
        /// <value> Ritorna o imposta la texture</value>
        public Texture2D Texture
        {
            set { texture = value; }
            get { return texture; }
        }

        /// <summary>
        /// Posizione dell'ufo
        /// </summary>
        /// <value> Ritorna o imposta la posizione</value>
        public Vector2 Position
        {
            set { position = value; }
            get { return position; }
        }

        /// <summary>
        /// Velocità dell'ufo
        /// </summary>
        /// <value> Ritorna o imposta la velocità</value>
        public int Speed
        {
            set { speed = value; }
            get { return speed; }
        }

        /// <summary>
        /// Visibilità dell'ufo
        /// </summary>
        /// <value> Ritorna o imposta la visibilità</value>
        public bool IsVisible
        {
            set { isVisible = value; }
            get { return isVisible; }
        }

       
        /// <summary>Hitbox del proiettili.</summary>
        /// <value> Ritorna la hitbox </value>
        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        /// <summary>
        /// Aggiorna l'ufo
        /// </summary>
        public void Update()
        {
            position.X += speed;
        }

        /// <summary>
        /// Disegna l'ufo
        /// </summary>
        public void Draw()
        {
            Common.SpriteBatch.Draw(texture, position, Color.White);
        }
    }
}
