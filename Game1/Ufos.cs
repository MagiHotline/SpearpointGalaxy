using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    /// <summary>
    /// Gestisce la lista di ufo
    /// </summary>
    class Ufos
    {
        private List<Ufo> aliens;
        private double spawnrate;
        private double delay = 30000;
        private Random random = new Random();
        
        /// <summary>
        /// Crea una lista di UFO
        /// </summary>
        public Ufos()
        {
            aliens = new List<Ufo>();
        }

        /// <summary>
        /// Lista di ufo
        /// </summary>
        /// <value> Ritorna la lista di ufo</value>
        public List<Ufo> Aliens
        {
            get { return aliens; }
        }

        /// <summary>
        /// Aggiunge alla lista di UFO
        /// </summary>
        /// <param name="u">Oggetto UFO</param>
        public void Add(Ufo u)
        {
            aliens.Add(u);
        }

        /// <summary>
        /// Spawmrate degli UFO
        /// </summary>
        /// <value>Ritorna o imposta lo spawnrate degli UFOI</value>
        public double Spawnrate
        {
            set { spawnrate = value; }
            get { return spawnrate; }
        }


        /// <summary>
        /// Aggiorna gli UFO
        /// </summary>
        public void Update()
        {
                if(delay > 0)
                {
                    delay -= Common.GameTime.ElapsedGameTime.TotalMilliseconds;
                }
                
                int randY = random.Next(0, Common.GameHeight);

                if (spawnrate > 0)
                {
                    spawnrate -= Common.GameTime.ElapsedGameTime.TotalMilliseconds;
                }

                if (spawnrate <= 0 && delay <= 0)
                {
                    aliens.Add(new Ufo("ufo", new Vector2(0, randY)));
                    spawnrate = 3000;
                }

                foreach (Ufo u in aliens)
                {
                    u.Update();
                }            
        }


        /// <summary>
        /// Disegna gli UFO
        /// </summary>
        public void Draw()
        {
            foreach (Ufo u in aliens)
            {
                if (u.isVisible)
                {
                    u.Draw();
                }

            }
        }
    }
}
