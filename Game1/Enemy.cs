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
    /// Classe che gestisce un nemico singolo
    /// </summary>
    class Enemy
    {
        public Texture2D texture;
        public Vector2 position;
        public int speed;
        public bool isVisible;
        private Random random = new Random();

        /// <summary>
        /// Crea un oggetto nemico
        /// </summary>
        public Enemy(string textureName, Vector2 position)
        {
            isVisible = true;
            texture = Common.Content.Load<Texture2D>(textureName);
            this.position = position;
            speed = 10;
        }

        /// <summary>
        /// Texture del nemico
        /// </summary>
        /// <value>Ritorna o imposta la texture del nemico</value>
        public Texture2D Texture
        {
            set { texture = value; }
            get { return texture; }
        }

        /// <summary>
        /// Posizione del nemico
        /// </summary>
        /// <value>Ritorna o imposta la posizione del nemico</value>
        public Vector2 Position
        {
            set { position = value; }
            get { return position; }
        }

        /// <summary>
        /// Velocità del nemico
        /// </summary>
        /// <value>Ritorna o imposta la velocità del nemico</value>
        public int Speed 
        {
            set { speed = value; }
            get { return speed; }
        }

        /// <summary>
        /// Flag di Visibilità
        /// </summary>
        /// <value>Ritorna o imposta la flag di visibilità</value>
        public bool IsVisible
        {
            set { isVisible = value; }
            get { return isVisible; }
        }

        /// <summary>Hitbox del proiettili.</summary>
        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        /// <summary>
        /// Aggiorna il nemico
        /// </summary>
        public void Update()
        {
            position.Y += speed;
        }

        /// <summary>
        /// Disegna il nemico
        /// </summary>
        public void Draw()
        {
            Common.SpriteBatch.Draw(texture, position, Color.White);        
        }

        
    }
}
