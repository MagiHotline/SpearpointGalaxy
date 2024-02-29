using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    enum SoundType { Effect, Song }

    /// <summary>
    /// Classe per la gestione dei suoni
    /// </summary>
    class Sound
    {
        private SoundEffect effect;
        private Song song;
        private SoundType type;

        /// <summary>Crea un nuovo oggetto Sound.</summary>
        /// <param name="soundName">Nome del suono.</param>
        /// <param name="type">Tipo di suono.</param>
        public Sound(string soundName, SoundType type)
        {
            this.type = type;
            if (type == SoundType.Effect)
            {
                song = null;
                effect = Common.Content.Load<SoundEffect>(soundName);
            }
            else if (type == SoundType.Song)
            {
                song = Common.Content.Load<Song>(soundName);
                effect = null;
            }
        }

        /// <summary>Tipo di suono.</summary>
        public SoundType Type
        {
            get { return type; }
        }

        /// <summary>Esegue il suono.</summary>
        public void Play()
        {
            if (type == SoundType.Effect)
            {
                effect.Play();
            }
            else if (type == SoundType.Song)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(song);
            }
        }

        /// <summary>Interrompe il suono.</summary>
        public void Stop()
        {
            if (type == SoundType.Song)
            {
                MediaPlayer.Stop();
            }
        }
    }
}
