using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercice39
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> restantes = new List<string>() { "Christopher", "Allan", "Dominique", "Eric", "Anthony", "Yves" };
            List<string> tirees = new List<string>();
            do
            {
                Console.WriteLine("--- Le grand tirage qu sort ---");
                Console.WriteLine("1---Effectuer un tirage");
                Console.WriteLine("2---Voir la liste des personnes déjà tirées");
                Console.WriteLine("3---Voir la liste des personnes restantes");
                Console.WriteLine("0---Quitter");
                string choix = Console.ReadLine();
                Console.Clear();
                switch (choix)
                {
                    case "1":
                        EffectuerTirage(restantes, tirees);
                        break;
                    case "2":
                        Console.WriteLine("***********************************");
                        Console.WriteLine("* Liste des personnes déjà tirées : *");
                        Console.WriteLine("***********************************");
                        Afficher(tirees);
                        break;
                    case "3":
                        Console.WriteLine("***********************************");
                        Console.WriteLine("* Liste des personnes restantes : *");
                        Console.WriteLine("***********************************");
                        Afficher(restantes);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
                if(restantes.Count == 0)
                {
                    restantes = new List<string>(tirees);
                    tirees.Clear();
                }

            } while (true);

        }

        static void EffectuerTirage(List<string> restantes, List<string> tirees)
        {
            Random random = new Random();
            string gagnant = restantes[random.Next(restantes.Count)];
            restantes.Remove(gagnant);
            tirees.Add(gagnant);
            Console.WriteLine("***********************************");
            Console.WriteLine($"* L'heureux gagnant est : {gagnant} *");
            Console.WriteLine("***********************************");
        }

        static void Afficher(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{string.Concat(Enumerable.Repeat("  ", i))}{list[i]}");
            }
        }
    }
}
