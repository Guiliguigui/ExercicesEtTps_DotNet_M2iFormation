using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Pendu
{
    internal static class GenerateurDeMot
    {
        private static string[] mots = {"exercice", "exemple", "pendu", "salut" };
        public static string Generer()
        {
            Random random = new Random();
            return mots[random.Next(mots.Length)];
        }
    }
}
