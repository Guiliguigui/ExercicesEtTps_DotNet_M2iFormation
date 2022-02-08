using System;

namespace TP3Pendu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Veuillez saisir le nombre d'essais : ");
            int maxTry = int.Parse(Console.ReadLine());
            Console.Clear();
            LePendu Jean = new LePendu();
            do
            {
                Console.WriteLine("----- Le Jeu du Pendu -----");
                Console.WriteLine($"Le mot à trouver : {Jean.Masque}");
                Console.WriteLine($"Il vous reste {maxTry - Jean.NbEssai} essais");
                Console.Write("Veuillez saisir une lettre : ");
                char lettre = char.Parse(Console.ReadLine());
                if (Jean.TestChar(lettre))
                {
                    Console.WriteLine("Bravo vous avez trouvé une lettre");
                    Console.ReadKey();
                }
                Console.Clear();
            } while(!Jean.TestWin() && Jean.NbEssai < 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bravo! Vous avez gagné !");
            Console.WriteLine($"Le mot à trouver était : {Jean.MotATrouve}");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
