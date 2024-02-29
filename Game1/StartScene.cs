using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    /// <summary>
    /// Classe che gestisce la scena di inizio
    /// </summary>
    class StartScene : Scene
    {
        public static int SEL_NEW_GAME = 0;
        public static int SEL_HELP = 1;
        public static int SEL_LEADERBOARD = 2;
        public static int SEL_EXIT = 3;

        private BackgroundAnimated background;
        private GameMenu menu;
        private Logo logo;
        //Sound SongStartScene;

        /// <summary>Crea un nuovo oggetto StartScene.</summary>
        public StartScene()
        {
            background = new BackgroundAnimated();
            logo = new Logo("SpearPoint_Icons", 155, 200);
            menu = new GameMenu("gameFont");
            menu.Position = new Vector2(200, 450);
            //SongStartScene = new Sound("otherworldyfoe", SoundType.Effect);
            menu.Items.Add("Nuova partita");
            menu.Items.Add("Comandi");
            menu.Items.Add("Classifica");
            menu.Items.Add("Esci");
            //SongStartScene.Play();
        }

        /// <summary>Inizializza la scena.</summary>
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
            if (Active == ActiveScene.Start)
            {
                background.Update();
                menu.Update();
            }
        }

        /// <summary>Disegna la scena.</summary>
        public void Draw()
        {
            if (Active == ActiveScene.Start)
            {
                background.Draw();
                logo.Draw();
                menu.Draw();
            }
        }
    }
}
