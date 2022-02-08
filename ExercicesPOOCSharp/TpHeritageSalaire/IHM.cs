using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tp5HeritageSalaire
{
    public static class IHM
    {
        private static List<Salarie> salaries = new List<Salarie>();
        public static void Start()
        {
            char choix;
            do
            {
                AfficherMenu();
                choix = SaisirChoix();
                switch (choix)
                {
                    case '1':
                        AjouterEmploye();
                        break;
                    case '2':
                        AfficherSalaires();
                        Console.WriteLine($"Salaire total : {Salarie.TotalSalaires}");
                        break;
                    case '3':
                        Console.Write("Merci de saisir le nom : ");
                        Salarie salarie = RechercherSalarie(Console.ReadLine());
                        if(salarie == null)
                            Console.Write("Salarie introuvable");
                        else
                            salarie.AfficherSalaire();
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }while (choix != '0');
        }
        public static void AfficherMenu()
        {
            Console.WriteLine("===== Gestion des employés =====\n");
            Console.WriteLine("1-- Ajouter un employé");
            Console.WriteLine("2-- Afficher le salaire des employés");
            Console.WriteLine("3-- Rechercher un employé");
            Console.WriteLine("0-- Quitter\n");
        }
        public static char SaisirChoix()
        {
            Console.Write("Entrez votre choix : ");
            return char.Parse(Console.ReadLine());
        }
        public static void AjouterEmploye()
        {
            Console.WriteLine("===== Ajouter un employé =====\n");
            Console.WriteLine("1-- Salarié");
            Console.WriteLine("2-- Commerciale");
            Console.WriteLine("0-- Retour\n");
            char choix = SaisirChoix();
            switch (choix)
            {
                case '1':
                    Salarie salarie = new Salarie();
                    IHM.SaisirEmploye(salarie);
                    salaries.Add(salarie);
                    break;
                case '2':
                    Comerciale comercial = new Comerciale();
                    IHM.SaisirEmploye(comercial);
                    salaries.Add(comercial);
                    break;
                default:
                    return;
            }
        }
        public static T SaisirEmploye<T>(T salarie)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite && property.Name != "Compteur")
                {
                    Console.Write($"Merci de saisir le/la {property.Name} : ");
                    property.SetValue(salarie, Convert.ChangeType(Console.ReadLine(), property.PropertyType));
                }
            }
            return salarie;
        }
        public static void AfficherSalaires()
        {
            Console.WriteLine("===== Salaire des employés =====");
            foreach (Salarie salarie in salaries)
            {
                salarie.AfficherSalaire();
                Console.WriteLine("------------------");
            }
        }

        public static Salarie RechercherSalarie(string nom)
        {
            return salaries.FirstOrDefault(s => s.Nom.Contains(nom));
        }
    }
}
