using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2ClasseChaise
{
    internal class Chaise
    {
        public int NbPieds { get; }
        public string Couleur { get; }
        public string Materiaux { get; }

        public Chaise()
        {
            NbPieds = 4;
            Couleur = "Bleu";
            Materiaux = "Bois";
        }
        public Chaise(int nbPieds, string couleur, string materiaux) : this()
        {
            NbPieds = nbPieds;
            Couleur = couleur;
            Materiaux = materiaux;
        }
        public override string ToString()
        {
            return $"Je suis une Chaise, avec {NbPieds} pieds en {Materiaux} et de couleur {Couleur}";
        }
    }
}
