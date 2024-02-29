using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    /// <summary>
    /// Classe che gestisce la scena di gioco
    /// </summary>
    class PlayScene : Scene
    {
      
        Background sfondo;
        Spaceship spaceship;
        HUD hud;
        Bullets bullets;
        Ufos ufos;
        Enemies enemies;
        Collision collision;
        Sound shoot;
        PowerUps powerups;

        /// <summary>
        /// Crea la scena di gioco
        /// </summary>
        public PlayScene()
        {
            sfondo = new Background("backroundr");         
            spaceship = new Spaceship("spaceshipr");
            spaceship.Position = new Vector2(320, 1100);
            spaceship.Speed = 10;
            hud = new HUD("gameFont", spaceship);
            hud.Position = new Vector2(10, 10);
            shoot = new Sound("lasergunnn", SoundType.Effect);
            bullets = new Bullets(spaceship, shoot);
            enemies = new Enemies();
            ufos = new Ufos();
            powerups = new PowerUps();
            collision = new Collision(spaceship, enemies, bullets, ufos, powerups);
        }

        /// <summary>
        /// Astronave principale
        /// </summary>
        public Spaceship Spaceship
        {
            get { return spaceship; }
        }

        /// <summary>
        /// Aggiorna la scena di gioco
        /// </summary>
        public void Update()
        {
           if(Active == ActiveScene.Play)
            {
                spaceship.Update();
                bullets.Update();
                enemies.Update();
                ufos.Update();
                powerups.Update();
                collision.Update();
            }  
        }

        /// <summary>
        /// Disegna la scena di gioco
        /// </summary>
        public void Draw()
        {
            if(Active == ActiveScene.Play)
            {
                sfondo.Draw();
                spaceship.Draw();
                hud.Draw();
                bullets.Draw();
                enemies.Draw();
                ufos.Draw();
                powerups.Draw();
            }
                          
        }
    }
}
