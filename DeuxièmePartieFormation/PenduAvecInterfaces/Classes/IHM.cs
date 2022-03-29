using PenduAvecInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenduAvecInterfaces.Classes
{
    public class IHM
    {
        private IPendu pendu;
        private IGenerateurDeMot generateurDeMot;

        public IHM()
        {
            generateurDeMot = new GenerateurDeMotApi();
        }
        public void Start()
        {
            pendu = new Pendu();
            pendu.GenererMasque(generateurDeMot);
            do
            {
                Affichage();
                Console.Write("Veuillez saisir une lettre : ");
                char c = Convert.ToChar(Console.ReadLine());
                if(pendu.TestChar(c))
                {
                    Console.WriteLine("Bravo vous avez trouvé un caractère dans le mot");
                }
                else
                {
                    Console.WriteLine($"Le caractère n'existe pas, il vous reste : {pendu.NbEssai}");
                }
            } while (pendu.NbEssai > 0 && !pendu.TestWin());

            if(pendu.NbEssai > 0)
            {
                Console.WriteLine("Bravo vous avez gagné !!!!!");
            }
            else
            {
                Console.WriteLine("Désolé, vous avez perdu :(");
            }
        }

        private void Affichage()
        {
            Console.WriteLine("---- Le jeu du Pendu ------");
            Console.WriteLine($"Le mot à trouver est : {pendu.Masque}");
        }
    }
}
