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
    /// Classe per la gestione delle collisioni
    /// </summary>
    class Collision
    {
        private Spaceship spaceship;
        private Enemies enemies;
        private Bullets bullets;
        private Ufos ufos;
        private PowerUps powerups;
        Sound Bolt;

        /// <summary>
        /// Crea un oggetto collisione
        /// </summary>
        /// <param name="spaceship">Astronave principale</param>
        /// <param name="enemies">Lista di nemici</param>
        /// <param name="bullets">Lista di proiettili</param>
        /// <param name="ufos">Lista di ufo</param>
        /// <param name="powerups">Lista di powerups</param>
        public Collision(Spaceship spaceship, Enemies enemies, Bullets bullets, Ufos ufos, PowerUps powerups)
        {
            this.spaceship = spaceship;
            this.enemies = enemies;
            this.bullets = bullets;
            this.ufos = ufos;
            this.powerups = powerups;
            Bolt = new Sound("PowerUp", SoundType.Effect);
        }

        /// <summary>
        /// Aggiorna le collisioni
        /// </summary>
        public void Update()
        {

            foreach(Ufo u in ufos.Aliens)
            {
                if(u.isVisible)
                {
                    if(spaceship.HitBox.Intersects(u.Hitbox))
                    {
                        spaceship.Is_alive = false;
                    }
                }

                foreach (Bullet b in bullets.Projectiles)
                {
                    if (b.Alive)
                    {
                        if (b.Hitbox.Intersects(u.Hitbox))
                        {
                            u.isVisible = false;
                            b.Alive = false;
                        }
                    }
                }


            }

            foreach (Enemy e in enemies.Nemici)
            {

                if (e.isVisible)
                {
                    if (spaceship.HitBox.Intersects(e.Hitbox))
                    {
                        spaceship.Is_alive = false;
                    }
                }

                foreach (Bullet b in bullets.Projectiles)
                {
                    if (b.Alive)
                    {
                        if (b.Hitbox.Intersects(e.Hitbox))
                        {
                            e.position = new Vector2(Common.GameWidth + e.texture.Width, 0);
                            e.isVisible = false;
                            b.Alive = false;
                        }
                    }
                }
            }

            foreach(PowerUp p in powerups.Potenziamenti)
            {
                if(spaceship.HitBox.Intersects(p.Hitbox))
                {
                    p.isVisible = false;
                    spaceship.Powerup_activated = true;
                    spaceship.PowerupCooldown = 4500;
                    Bolt.Play();
                }
            }
        }


    }
}
