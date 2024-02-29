using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class PowerUps
    {
        private List<PowerUp> potenziamenti;
        private double spawnrate = 1000;
        private Random random = new Random();

        /// <summary>
        /// Crea una lista di UFO
        /// </summary>
        public PowerUps()
        {
            potenziamenti = new List<PowerUp>();
        }

        /// <summary>
        /// Lista di ufo
        /// </summary>
        /// <value> Ritorna la lista di ufo</value>
        public List<PowerUp> Potenziamenti
        {
            get { return potenziamenti; }
        }

        /// <summary>
        /// Aggiunge alla lista di UFO
        /// </summary>
        /// <param name="u">Oggetto UFO</param>
        public void Add(PowerUp p)
        {
            potenziamenti.Add(p);
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

        public void Update()
        {
         
            int randX = random.Next(0, Common.GameWidth);

            if (spawnrate > 0)
            {
                spawnrate -= Common.GameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (spawnrate <= 0)
            {
                potenziamenti.Add(new PowerUp("boltsprite", new Vector2(randX, 0)));
                spawnrate = 7000;
            }

            foreach (PowerUp p in potenziamenti)
            {
                p.Update();
            }
        }

        public void Draw()
        {
            foreach (PowerUp p in potenziamenti)
            {
                if (p.isVisible)
                {
                    p.Draw();
                }

            }
        }


    }
}
