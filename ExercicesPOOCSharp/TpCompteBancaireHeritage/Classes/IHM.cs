using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompteBancaireHeritage.Classes
{
    internal static class IHM
    {
        public static List<Compte> Comptes { get; set; } = new List<Compte>();
        public static void Start()
        {
            bool confirm = false;
            do
            {
                MainMenu();
                string choix = Choice();
                switch (choix)
                {
                    case "1":
                        Console.Clear();
                        CreerCompte();
                        break;
                    case "2":
                        Console.Clear();
                        EffectuerDepot();
                        break;
                    case "3":
                        Console.Clear();
                        EffectuerRetrait();
                        break;
                    case "4":
                        Console.Clear();
                        AfficherOperationsSolde();
                        break;
                    case "5":
                        Console.Clear();
                        AfficherCalculInteret();
                        break;
                    case "0":
                        confirm = true;
                        break;
                    default:
                        break;
                }
                if (!confirm)
                {
                    Console.WriteLine("\n\nAppuyez sur une touche pour revenir au menu principal...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!confirm);
        }

        private static void MainMenu()
        {
            Console.WriteLine("--------------- Banque ---------------\n");
            Console.WriteLine("\t1-- Créer un compte bancaire");
            Console.WriteLine("\t2-- Effectuer un dépot");
            Console.WriteLine("\t3-- Effectuer un retrait");
            Console.WriteLine("\t4-- Opérations et solde");
            Console.WriteLine("\t5-- Calcul Interet");
            Console.WriteLine("\n\t0-- Quitter\n");
        }

        private static string Choice()
        {
            Console.Write("Faites votre choix : ");
            return Console.ReadLine();
        }

        public static void WriteLineColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void CreerCompte()
        {
            Console.WriteLine("***** Création d'un nouveau compte *****\n");

            Console.WriteLine("Quel type de compte ?");
            Console.WriteLine("\t1-- Normal");
            Console.WriteLine("\t2-- Epargne");
            Console.WriteLine("\t3-- Premium");
            Console.WriteLine("\n\t0-- Quitter\n");
            string choix = Choice();
            if (choix != "1" && choix != "2" && choix != "3")
                return;

            Console.Write("Le nom du client : ");
            string nom = Console.ReadLine();
            Console.Write("Le prénom du client : ");
            string prenom = Console.ReadLine();
            Console.Write("Le téléphone du client : ");
            string tel = Console.ReadLine();
            Console.Write("Solde à l'ouverture : ");
            double solde = double.Parse(Console.ReadLine());

            Client client = new Client(nom, prenom, tel);
            Compte compte;
            switch (choix)
            {
                case "1":
                    compte = new Compte(solde, client);
                    break;
                case "2":
                    Console.Write("Taux de remuneration : ");
                    double tauxRemuneration = double.Parse(Console.ReadLine());
                    compte = new CompteEpargne(solde, client, tauxRemuneration);
                    break;
                case "3":
                    Console.Write("Cout d'operation : ");
                    double coutOperation = double.Parse(Console.ReadLine());
                    compte = new ComptePayant(solde, client, coutOperation);
                    break;
                default:
                    return;
            }
            Comptes.Add(compte);
            WriteLineColor($"Compte bien créé, voici le numéro de compte : {compte.Id}", ConsoleColor.Green);
        }

        private static Compte SaisirNumeroCompte()
        {
            Console.Write("Merci de saisir le numero du compte : ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                WriteLineColor($"Numero invalide", ConsoleColor.Red);
                return null;
            }
            else
            {
                Compte compte = Comptes.FirstOrDefault(c => c.Id == numero);
                if (compte == null)
                    WriteLineColor($"Compte inexistant", ConsoleColor.Red);
                return compte;
            }
        }

        private static void EffectuerDepot()
        {
            Console.WriteLine("***** Deposer de l'argent *****\n");
            Compte compte = SaisirNumeroCompte();
            if (compte != null)
            {
                Console.Write("Merci de saisir le montant du dépot : ");
                double montant = double.Parse(Console.ReadLine());

                compte.EffectuerDepot(montant);

                WriteLineColor($"Dépot réussis", ConsoleColor.Green);
            }
        }

        private static void EffectuerRetrait()
        {
            Console.WriteLine("***** Retirer de l'argent *****\n");
            Compte compte = SaisirNumeroCompte();
            if (compte != null)
            {
                Console.Write("Merci de saisir le montant du retrait : ");
                double montant = double.Parse(Console.ReadLine());

                compte.EffectuerDepot(montant);

                WriteLineColor($"Retrait réussis", ConsoleColor.Green);
            }
        }

        private static void AfficherOperationsSolde()
        {
            Console.WriteLine("***** Afficher un compte *****\n");
            Compte compte = SaisirNumeroCompte();
            if (compte != null)
            {
                WriteLineColor(compte.ToString(), ConsoleColor.Blue);
            }
        }

        private static void AfficherCalculInteret()
        {
            Console.WriteLine("***** Calculer les intérets *****\n");
            Compte compte = SaisirNumeroCompte();
            //compte is CompteEpargne
            //compte as CompteEpargne != nul
            if (compte != null & typeof(CompteEpargne) == compte.GetType())
            {
                CompteEpargne compteEpargne = (CompteEpargne)compte;
                WriteLineColor($"Les intérets gagnés par le compte sont de : {compteEpargne.CalculerInterets()}", ConsoleColor.Blue);
            }
            else
                WriteLineColor($"Le compte n'est pas un compte epargne", ConsoleColor.Red);
        }
    }
}
