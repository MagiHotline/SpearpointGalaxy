using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game1
{
    /// <summary>
    /// Classe per la gestione della classifica
    /// </summary>
    class HighScores
    {
        public int[] score;
        const int max_scorable = 3;

        /// <summary>
        /// Crea un array di 3 posti
        /// </summary>
        public HighScores()
        {
            score = new int[max_scorable];
            LeggiFileDati(Common.Filedati);
        }

        /// <summary>
        /// Array di Punteggio
        /// </summary>
        /// <value>Ritorna o imposta l'array di punteggi</value>
        public int[] Score
        {        
            set { score = value; }
            get { return score; }
        }

        /// <summary>
        /// massimo di punteggio
        /// </summary>
        public int Max_scorable
        {
            get { return max_scorable; }
        }
        

        /// <summary>
        /// Scrive il file dati
        /// </summary>
        /// <param name="nomeFile">nome del file</param>
        public void ScriviFileDati(string nomeFile)
        {
            FileStream file = new FileStream(nomeFile, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, score);
            file.Close();
        }


        /// <summary>
        /// Legge il file dati
        /// </summary>
        /// <param name="nomeFile">Nome del file</param>
        /// <returns>True se è andata a buon fine, se no false</returns>
        public bool LeggiFileDati(string nomeFile)
        {
            bool leggi = false;
            if (File.Exists(nomeFile))
            {
                FileStream file = new FileStream(nomeFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                score = (int[])bf.Deserialize(file);
                file.Close();
                leggi = true;
            }
            return leggi;
        }
    }
}
