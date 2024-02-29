using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    /// <summary>
    /// Classe per la gestione di un menu
    /// </summary>
    class GameMenu
    {
        private SpriteFont font;
        private Vector2 position;
        private Color standardColor;
        private Color selectedColor;
        private Sound menueffect;
        private int selectedIndex;
        private List<string> items;
        private int increment;

        /// <summary>Crea un nuovo oggetto GameMenu.</summary>
        /// <param name="fontName">Nome del font.</param>
        public GameMenu(string fontName)
        {
            font = Common.Content.Load<SpriteFont>(fontName);
            items = new List<string>();
            position = Vector2.Zero;
            standardColor = Color.White;
            selectedColor = Color.Cyan;
            selectedIndex = 0;
            increment = 50;
            menueffect = new Sound("menu_effect", SoundType.Effect);
        }

        /// <summary>Posizione del menu.</summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>Colore standard delle voci di menu.</summary>
        public Color StandardColor
        {
            get { return standardColor; }
            set { standardColor = value; }
        }

        /// <summary>Colore della voce di menu selezionata.</summary>
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        /// <summary>Indice della voce di menu selezionata.</summary>
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }

        /// <summary>Distanza verticale delle voci di menu.</summary>
        public int Increment
        {
            get { return increment; }
            set { increment = value; }
        }

        /// <summary>Voci di menu.</summary>
        public List<string> Items
        {
            get { return items; }
            set { items = value; }
        }

        /// <summary>Aggiorna il menu.</summary>
        public void Update()
        {
            if (KeyboardInput.KeyPressed(Keys.Down))
            {
                menueffect.Play();
                selectedIndex++;
                if (selectedIndex == items.Count) selectedIndex = 0;
            }

            else if (KeyboardInput.KeyPressed(Keys.Up))
            {
                menueffect.Play();
                selectedIndex--;
                if (selectedIndex == -1) selectedIndex = items.Count - 1;
            }
        }

        /// <summary>Disegna il menu.</summary>
        public void Draw()
        {
            Color color;
            float y = position.Y;
            for (int i = 0; i < items.Count; i++)
            {
                color = standardColor;
                if (i == selectedIndex) color = selectedColor;
                Common.SpriteBatch.DrawString(font, items[i], new Vector2(position.X, y), color);
                y += increment;
            }
        }
    }
}
