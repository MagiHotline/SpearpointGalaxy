using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    /// <summary>
    /// Classe per la gestione dello sfondo
    /// </summary>
    class Background
    {
        private Texture2D texture;
        
        /// <summary>
        /// Crea un nuovo oggetto Background
        /// </summary>
        /// <param name="textureName">Nome della texture</param>
        public Background(string textureName)
        {
            texture = Common.Content.Load<Texture2D>(textureName);
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