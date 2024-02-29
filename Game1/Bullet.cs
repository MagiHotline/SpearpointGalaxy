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
    /// Classe che gestisce di un proiettile
    /// </summary>
    class Bullet
    {
        private Texture2D texture;
        private Vector2 position;
        private int speed;
        private bool alive;

        /// <summary>
        /// Crea un oggetto proiettile
        /// </summary>
        /// <param name="textureName">Nome della texture</param>
        /// <param name="position">Posizione del proiettile</param>
        public Bullet(string textureName, Vector2 position)
        {
            texture = Common.Content.Load<Texture2D>(textureName);
            speed = 20;
            this.position = position;
            alive = true;
        }

        /// <summary>
        /// Texture del proiettile
        /// </summary>
        /// <value>Ritorna o imposta la texture del proiettile</value>
        public Texture2D Texture
        {
            set { texture = value; }
            get { return texture; }
        }

        /// <summary>
        /// Posizione del proiettile
        /// </summary>
        /// <value>Ritorna o imposta la posizione del proiettile</value>
        public Vector2 Position
        {
            set { position = value; }
            get { return position; }
        }

        /// <summary>
        /// Velocità del proiettile
        /// </summary>
        /// <value>Ritorna o imposta il cooldown dell'astronave</value>
        public int Speed {
            set { speed = value; }
            get { return speed; }
        }

        /// <summary>
        /// Flag di vita del proiettile
        /// </summary>
        /// <value>Ritorna o imposta la flag di vita del proiettile</value>
        public bool Alive
        {
            set { alive = value; }
            get { return alive; }
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
        /// Aggiorna il proiettile
        /// </summary>
        public void Update()
        {
            position.Y -= speed;
        }

        /// <summary>
        /// Disegna il proiettile
        /// </summary>
        public void Draw()
        {
            Common.SpriteBatch.Draw(texture, position, Color.White);
            
        }


      


    }
}
