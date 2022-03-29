using PenduAvecInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenduAvecInterfaces.Classes
{
    public class GenerateurDeMot : IGenerateurDeMot
    {
        private String[] mots = { "google", "microsoft", "facebook", "sopra", "capg" };
        
        private Random random = new Random();
        public string Generer()
        {
            int randomIndex = random.Next(0, mots.Length);
            return mots[randomIndex];
        }
    }
}
