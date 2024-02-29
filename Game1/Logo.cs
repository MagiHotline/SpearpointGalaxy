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
    /// Classe per la gestione di un logo
    /// </summary>
    class Logo
    {
        private Texture2D texture;
        private Vector2 position;

        /// <summary>
        /// Crea un nuovo oggetto Logo
        /// </summary>
        /// <param name="textureName">Nome della texture</param>
        public Logo(string textureName, int x, int y)
        {
            texture = Common.Content.Load<Texture2D>(textureName);
            position.X = x;
            position.Y = y;
        }

        /// <summary>
        /// Disegna il logo
        /// </summary>
        public void Draw()
        {
            Common.SpriteBatch.Draw(texture, position, Color.White);
        }
    }
}
