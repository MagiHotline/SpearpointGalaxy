using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    /// <summary>
    /// Classe per la gestione dei proiettili
    /// </summary>
    class Bullets
    {
        private List<Bullet> projectiles;
        private Spaceship spaceship;
        Sound effect;

        /// <summary>
        /// Crea una nuova lista di proiettili
        /// </summary>
        public Bullets(Spaceship spaceship, Sound effect)
        {
            this.spaceship = spaceship;
            projectiles = new List<Bullet>();
            this.effect = effect;
        }

        /// <summary>
        /// Insieme di proiettili
        /// </summary>
        /// <value>Ritorna i proiettili</value>
        public List<Bullet> Projectiles {
            get { return projectiles; }
        }

        /// <summary>
        /// Aggiunge un proiettili alla lista di proiettili
        /// </summary>
        /// <param name="b">Proiettili</param>
        public void Add(Bullet b)
        {
            projectiles.Add(b);
        }
    
        /// <summary>
        /// Aggiorna i proiettili
        /// </summary>
        public void Update()
        {
            if(spaceship.Is_attacking)
            {
               effect.Play();
               projectiles.Add(new Bullet("laserr", new Vector2(spaceship.Position.X + spaceship.HitBox.Width/2 - 5, spaceship.Position.Y)));
            }

            foreach(Bullet b in projectiles)
            {
                b.Update();
            }
        }

        /// <summary>
        /// Disegna i proiettili
        /// </summary>
        public void Draw()
        {
            foreach(Bullet b in projectiles)
            {   
                if(b.Alive)
                {
                    b.Draw();
                }
              
            }
        }

    }
}
