using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class KeyboardInput
    {
        private static KeyboardState oldKey;
        private static KeyboardState newkey;

        /// <summary>Aggiorna lo stato della tastiera.</summary>
        public static void Update()
        {
            oldKey = newkey;
            newkey = Keyboard.GetState();
        }

        /// <summary>Rileva se il tasto è stato premuto e rilasciato.</summary>
        /// <param name="key">Tasto.</param>
        /// <returns>Ritorna true se il tasto è stato premuto e rilasciato, altrimenti false.</returns>
        public static bool KeyPressed(Keys key)
        {
            return (oldKey.IsKeyDown(key) && newkey.IsKeyUp(key));
        }

        /// <summary>Rileva se il tasto è stato rilasciato.</summary>
        /// <param name="key">Tasto.</param>
        /// <returns>Ritorna true se il tasto è stato rilasciato, altrimenti false.</returns>
        public static bool KeyDown(Keys key)
        {
            return (newkey.IsKeyDown(key));
        }
    }
}
