using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class HelpScene : Scene
    {
        private Background background;
        private GameMenu menu;

        /// <summary>Crea un nuovo oggetto HelpScene.</summary>
        public HelpScene()
        {
            background = new Background("space-pixel-arts");
            menu = new GameMenu("gameFont");
            menu.Position = new Vector2(200, 450);
            menu.Items.Add("Sparare - > E");
            menu.Items.Add("Muoversi -> Freccette");
            menu.Items.Add("Uscire -> Esc");
        }

        /// <summary>
        /// Aggiorna le menu
        /// </summary>
        public void Update()
        {
            if (Active == ActiveScene.Help)
            {                
                menu.Update();
            }
        }

        /// <summary>Disegna la scena.</summary>
        public void Draw()
        {
            if (Active == ActiveScene.Help)
            {
                background.Draw();
                menu.Draw();
            }
        }

    }
}
