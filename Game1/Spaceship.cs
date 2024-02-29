using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game1
{
    /// <summary>
    /// Classe per la gestione dell'astronave
    /// </summary>
    class Spaceship
    {

        #region Variables

        private Texture2D texture;
        private Vector2 position;
        private HighScores classifica;
        private int speed;
        private Keys keyUp;
        private Keys keyDown;
        private Keys keyRight;
        private Keys keyLeft;
        private Keys shoot;
        private bool is_attacking;
        private bool is_alive;
        private bool powerup_activated;
        private double cooldown;
        private double powerupCooldown;
        private int timeAlive;
         
        #endregion

        /// <summary>
        /// Crea un nuovo oggetto di astronave
        /// </summary>
        /// <param name="textureName"></param>
        public Spaceship(string textureName)
        {
            texture = Common.Content.Load<Texture2D>(textureName);
            speed = 10;
            position = Vector2.Zero;
            keyDown = Keys.Down;
            keyUp = Keys.Up;
            keyRight = Keys.Right;
            keyLeft = Keys.Left;
            shoot = Keys.E;
            is_attacking = false;
            cooldown = 0;
            is_alive = true;
            timeAlive = 0;
            powerup_activated = false;
            classifica = new HighScores();           
        }

        #region Proprieties
        /// <summary>
        /// Posizione dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta la posizione dell'astronave</value>
        public Vector2 Position
        {
            set { position = value; }
            get { return position; }

        }

        /// <summary>
        /// Velocità dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta la velocità dell'astronave</value>
        public int Speed
        {
            set { speed = value; }
            get { return speed; }
        }

        /// <summary>
        /// tasto UP dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta il tasto UP dell'astronave</value>
        public Keys KeyUp
        {
            set { keyUp = value; }
            get { return keyUp; }
        }

        /// <summary>
        /// tasto DOWN dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta il tasto DOWN dell'astronave</value>
        public Keys KeyDown
        {
            set { keyDown = value; }
            get { return keyDown; }
        }

        /// <summary>
        /// tasto RIGHT dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta il tasto RIGHT dell'astronave</value>
        public Keys KeyRight
        {
            set { keyRight = value; }
            get { return keyRight; }
        }
        /// <summary>
        /// tasto LEFT dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta il tasto LEFT dell'astronave</value>
        public Keys KeyLeft 
        {
            set { keyLeft = value; }
            get { return keyLeft; }
        }

        /// <summary>
        /// tasto SPARA dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta il tasto SPARA dell'astronave</value>
        public Keys Shoot
        {
            set { shoot = value; }
            get { return shoot; }
        }

        /// <summary>
        /// flag di attacco dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta la flag di attacco dell'astronave</value>
        public bool Is_attacking
        {
            set { is_attacking = value; }
            get { return is_attacking; }
        }

        public bool Is_alive
        {
            set { is_alive = value; }
            get { return is_alive; }
        }

        public bool Powerup_activated
        {
            set { powerup_activated = value; }
            get { return powerup_activated; }
        }

        /// <summary>
        /// Cooldown dello sparo
        /// </summary>
        /// <value>Ritorna o imposta il cooldown dell'astronave</value>
        public double Cooldown
        {
            set { cooldown = value; }
            get { return cooldown; }
        }

        /// <summary>
        /// Cooldown del powerup
        /// </summary>
        /// <value>Ritorna o imposta il cooldown del powerup</value>
        public double PowerupCooldown
        {
            set { powerupCooldown = value; }
            get { return powerupCooldown; }
        }

        /// <summary>
        /// Tempo in vita dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta il tempo in vita dell'astronave</value>
        public int Timealive
        {
            set { timeAlive = value; }
            get { return timeAlive; }
        }

        /// <summary>
        /// Hitbox dell'astronave
        /// </summary>
        /// <value>Ritorna o imposta la Hitbox dell'astronave</value>
        public Rectangle HitBox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }

        public HighScores Classifica
        {
            get { return classifica; }
        }

        #endregion

        /// <summary>
        /// Aggiorna l'astronave
        /// </summary>
        public void Update()
        {
            is_attacking = false;
            
            if (cooldown > 0)
            {
                cooldown -= Common.GameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if(is_alive)
            {
                timeAlive++;

                if (KeyboardInput.KeyDown(KeyUp))
                {
                    position.Y -= speed;
                }
                else if (KeyboardInput.KeyDown(keyDown))
                {
                    position.Y += speed;
                }
                else if (KeyboardInput.KeyDown(keyRight))
                {
                    position.X += speed;
                }
                else if (KeyboardInput.KeyDown(keyLeft))
                {
                    position.X -= speed;
                }

                if (KeyboardInput.KeyPressed(shoot) && cooldown <= 0)
                {
                    is_attacking = true;
                    if(!powerup_activated)
                    {
                        cooldown = 300;
                    } else
                    {
                        cooldown = 100;
                    }
                }

                if(powerup_activated && powerupCooldown > 0)
                {
                    powerupCooldown -= Common.GameTime.ElapsedGameTime.TotalMilliseconds;
                }
                    
                if(powerupCooldown < 0)
                {
                    powerup_activated = false;
                }

            }

            if(!is_alive)
            {               
                Scene.Active = ActiveScene.GameOver;

                //tempo che tiene il secondo posto
                int temp = -1;
                //tempo che tiene il terzo posto
                int SubTime = -1;

                for (int i = 0; i < classifica.Max_scorable; i++)
                {
                    if(timeAlive > classifica.Score[i] && temp < 0)
                    {
                        temp = classifica.Score[i];
                        classifica.Score[i] = timeAlive;
                    }          
                    else if(temp >= 0 && SubTime < 0)
                    {
                        SubTime = Classifica.Score[i];
                        classifica.Score[i] = temp;
                        
                    } else if(temp >= 0)
                    {
                        Classifica.Score[i] = SubTime;
                    }
                }

                classifica.ScriviFileDati(Common.Filedati);
            }            
                        
            position.Y = MathHelper.Clamp(position.Y, 0, Common.GameHeight - texture.Height);
            position.X = MathHelper.Clamp(position.X, 0, Common.GameWidth - texture.Width);
        }

   
        /// <summary>
        /// Disegna l'astronave
        /// </summary>
        public void Draw()
        {
            if (is_alive)
            {
                Common.SpriteBatch.Draw(texture, position, Color.White);
            }  
        }
    }
}
