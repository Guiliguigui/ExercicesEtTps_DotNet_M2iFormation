using System;

namespace Tp2ClasseChaise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chaise chaise = new Chaise();
            Chaise chaise1 = new Chaise(4, "Blanche", "métal");
            Chaise chaise2 = new Chaise(1, "Transparente", "Pléxiglass");
            AfficherObjets(chaise);
            AfficherObjets(chaise1);
            AfficherObjets(chaise2);
        }

        static void AfficherObjets(object obj)
        {
            Console.WriteLine("-----Affichage d'un nouvel objet-----\n");
            Console.WriteLine(obj);
            Console.WriteLine("\n-------------------------------------\n");
        }
    }
}
