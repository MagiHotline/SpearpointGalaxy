using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class LeaderboardScreen : Scene
    {
        private Background background;
        private GameMenu menu;

        /// <summary>Crea un nuovo oggetto HelpScene.</summary>
        public LeaderboardScreen(PlayScene playscene)
        {
            
            background = new Background("space-pixel-arts");
            menu = new GameMenu("gameFont");
            menu.Position = new Vector2(200, 400);
            menu.Items.Add("CLASSIFICA");
            menu.Items.Add("[1] " + playscene.Spaceship.Classifica.Score[0] + " points");
            menu.Items.Add("[2] " + playscene.Spaceship.Classifica.Score[1] +  " points");
            menu.Items.Add("[3] " + playscene.Spaceship.Classifica.Score[2] + " points");
        }

        /// <summary>
        /// Aggiorna le menu
        /// </summary>
        public void Update()
        {
            if (Active == ActiveScene.Leaderboard)
            {
                menu.Update();
            }
        }

        /// <summary>Disegna la scena.</summary>
        public void Draw()
        {
            if (Active == ActiveScene.Leaderboard)
            {
                background.Draw();
                menu.Draw();
            }
        }
    }
}
