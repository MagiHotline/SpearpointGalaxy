using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{

    /// <summary>
    /// Classe che gestisce la lista di nemici
    /// </summary>
    class Enemies
    {
        private List<Enemy> nemici;
        private double spawnrate;
        private double upgrade = 15000;
        private double upgrade2 = 50000;
        private Random random = new Random();

        /// <summary>
        /// Crea una lista di nemici
        /// </summary>
        public Enemies()
        {
            nemici = new List<Enemy>();
        }

        /// <summary>
        /// Lista di nemici
        /// </summary>
        /// <value>Ritorna la lista di nemici</value>
        public List<Enemy> Nemici
        {
            get { return nemici; }
        }

        /// <summary>
        /// Aggiunge un nemico alla lista
        /// </summary>
        public void Add(Enemy e)
        {
            nemici.Add(e);
        }

        /// <summary>
        /// Cooldown dello spawn
        /// </summary>
        /// <value>Ritorna o imposta lo spawnrate dei nemici</value>
        public double Spawnrate
        {
            set { spawnrate = value; }
            get { return spawnrate; }
        }

        /// <summary>
        /// Aggiorna i nemici
        /// </summary>
        public void Update()
        {
            int randX = random.Next(0 + 40, Common.GameWidth - 40);

            if(upgrade > 0 && upgrade2 > 0)
            {
                upgrade -= Common.GameTime.ElapsedGameTime.TotalMilliseconds;
                upgrade2 -= Common.GameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if(upgrade <= 0)
            {
                foreach (Enemy e in nemici)
                {
                    e.speed = 15;
                }
            }

            if (upgrade2 <= 0)
            {
                foreach (Enemy e in nemici)
                {
                    e.speed = 20;
                }
            }

            if (spawnrate > 0)
            {
                spawnrate -= Common.GameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if(spawnrate <= 0)
            {
                nemici.Add(new Enemy("asteroid1", new Vector2(randX, 0)));
                spawnrate = 500;
            }

            foreach (Enemy e in nemici)
            {
                e.Update();
            }               
        }

        /// <summary>
        /// Disegna i nemici
        /// </summary>
        public void Draw()
        {
            foreach (Enemy e in nemici)
            {
                if(e.isVisible)
                {
                    e.Draw();
                }
            }
        }
    }
}
