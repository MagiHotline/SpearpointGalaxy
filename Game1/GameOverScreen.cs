using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    /// <summary>
    /// Classe per la gestione della scena di GameOver
    /// </summary>
    class GameOverScreen : Scene
    {
        public static int SEL_CONTINUE = 0;
        public static int RETURN_TO_MENU = 1;
        public static int SEL_EXIT = 2;

        private Background background;
        private GameMenu menu;

        /// <summary>
        /// Crea una schermata di gameover
        /// </summary>
        public GameOverScreen()
        {
            background = new Background("space-pixel-arts");
            menu = new GameMenu("gameFont");
            menu.Position = new Vector2(100, 450);
            menu.Items.Add("Vuoi giocare ancora?");
            menu.Items.Add("Ritorna al menu principale");
            menu.Items.Add("Esci");
        }

        public void Initialize()
        {
            menu.SelectedIndex = 0;
        }

        /// <summary>Menu della scena.</summary>
        public GameMenu Menu
        {
            get { return menu; }
            set { menu = value; }
        }

        /// <summary>Aggiorna la scena.</summary>
        public void Update()
        {
            if (Active == ActiveScene.GameOver)
            {
                menu.Update();
            }
        }

        /// <summary>Disegna la scena.</summary>
        public void Draw()
        {
            if (Active == ActiveScene.GameOver)
            {
                background.Draw();
                menu.Draw();
            }
        }


    }
}
