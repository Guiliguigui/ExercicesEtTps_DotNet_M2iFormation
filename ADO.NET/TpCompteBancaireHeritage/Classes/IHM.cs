using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompteBancaireHeritage.Data;

namespace TpCompteBancaireHeritage.Classes
{
    internal class IHM
    {
        Bank bank;

        public IHM()
        {
            bank = new Bank();
            ClientCompteInjection.Injecter(bank);
        }

        public void Start()
        {
           
            string choix;
            
            do
            {
                Console.Clear();
                choix = Menu();
                switch (choix)
                {
                    case "1":
                        ActionCreationCompte();
                        break;
                    case "2":
                        ActionDepot();
                        break;
                    case "3":
                        ActionRetrait();
                        break;
                    case "4":
                        ActionAffichageCompte();
                        break;
                    case "5":
                        ActionCalculInterets();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }

            } while (choix != "0");
        }

        private string Menu()
        {
            Console.WriteLine("\n--------------- Banque Peu Populaire -------------\n");
            Console.WriteLine("1- Créer un compte bancaire");
            Console.WriteLine("2- Effectuer un dépôt");
            Console.WriteLine("3- Effectuer un retrait");
            Console.WriteLine("4- Opérations et solde");
            Console.WriteLine("5- Calcul Interêts\n");
            Console.WriteLine("0---Quitter\n");

            Console.Write("Faites votre choix : ");

            return Console.ReadLine();
        }
        private string MenuCreationCompte()
        {
            Console.WriteLine("\n----- Type de compte -----\n");
            Console.WriteLine("1- Compte Normal");
            Console.WriteLine("2- Compte Epargne");
            Console.WriteLine("3- Compte Payant");

            Console.Write("\nFaites votre choix : ");
            return Console.ReadLine();
        }

        public void CreationClient(Client c)
        {
            Console.WriteLine("----- Création d'un client ------\n");
            Console.Write("Veuillez saisir un nom : ");
            c.Nom = Console.ReadLine();
            Console.Write("Veuillez saisir un prénom : ");
            c.Prenom = Console.ReadLine();
            Console.Write("Veuillez saisir le téléphone : ");
            c.Telephone = Console.ReadLine();            
        }
        public decimal CreationCompte()
        {
            Console.WriteLine("----- Création du compte ------\n");
            Console.Write("Veuillez saisir le solde à l'ouverture du compte : ");
            return Convert.ToDecimal( Console.ReadLine() );           
        }
        public void ActionCreationCompte()
        {            
            // Création d'un client
            Client client = new Client();
            CreationClient(client);

            // Création du compte           
            decimal solde = CreationCompte();
            
            string choix = MenuCreationCompte();

            Compte compte = null;
            switch (choix)
            {
                case "1":
                    compte = new Compte(solde,client);
                    break;
                case "2":
                    Console.Write("Veuillez saisir le taux de rémunération : ");
                    decimal taux = Convert.ToDecimal(Console.ReadLine());
                    // Création d'un compte Epargne
                    compte = new CompteEpargne(solde, client, taux );
                    break;
                case "3":
                    Console.Write("Veuillez saisir le coût d'une opération : ");
                    decimal cout = Convert.ToDecimal(Console.ReadLine());
                    // Création d'un compte Payant
                    compte = new ComptePayant(solde, client, cout);
                    break;
                default:
                    Console.WriteLine("Erreur de choix");
                    break;
            }

            if (compte != null)
            {
                //compte.AjouterCompte(bank);
                bank.AjouterCompte(compte);
            }
            else
            {
                Console.WriteLine("Erreur lors de la création du compte");
            }            
            
        }

        public void ActionDepot()
        {
            Console.Write("---------- Déposer des fonds ----------\n");
            Compte c = ActionRechercherCompte();
            Console.Write("Veuillez saisir le montant du dépot : ");
            decimal montant = Convert.ToDecimal(Console.ReadLine());

            // Montant => créer l'opération
            Operation o = new Operation(montant);

            // Update le solde du compte
            c.Depot(o);
        }

        public void ActionRetrait()
        {
            Console.Write("---------- Retirer des fonds ----------\n");
            Compte c = ActionRechercherCompte();

            Console.Write("Veuillez saisir le montant du retrait : ");
            decimal montant = Convert.ToDecimal(Console.ReadLine())*-1;

            // Montant => créer l'opération
            Operation o = new Operation(montant);

            // Ajout du retrait au compte + update Operation et solde
            c.Retrait(o);
        }

        public void ActionAffichageCompte()
        {
            Console.Write("---------- Afficher un compte ----------\n");

            Compte c = null;
            c = ActionRechercherCompte();
           
            if(c != null)
            {
                Console.WriteLine(c);
            }
            else            
                Console.WriteLine("Erreur, veuillez choisir un compte valable...");
            WaitUser();
        }

        public void ActionCalculInterets()
        {
            Compte c = ActionRechercherCompte();
            if (c !=null && c is CompteEpargne compteEpargne)
            {
                if (compteEpargne.CalculerInteret())
                {
                    Console.WriteLine("Intérêts ajoutés !");
                    WaitUser();
                }
            }
            else
            {
                Console.WriteLine("Veuillez séléctionner un compte Epargne!");
                WaitUser();
            }
        }

        public Compte ActionRechercherCompte()
        {
            Console.Write("Veuillez saisir l'id du compte : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return bank.RechercherCompte(id);
        }

        private void WaitUser()
        {
            Console.WriteLine("Veuillez presser Enter pour retourner au menu principal");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
