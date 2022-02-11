using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompteBancaireHeritage.Classes;

namespace TpCompteBancaireHeritage.Data
{
    internal class ClientCompteInjection
    {
        public static void Injecter(Bank bank)
        {
            // Création des clients
            Client c1 = new Client("Di Persio", "Anthony", "+33 6 12 34 56 78");
            Client c2 = new Client("Abadi", "Ihab", "+33 6 74 85 96 32");
            Client c3 = new Client("Abadi", "Marine", "+33 6 14 52 63 96");



            // Création des Comptes
            Compte compte1 = new (150, c1);
            Compte compte2 = new CompteEpargne(150, c2,4);
            Compte compte3 = new ComptePayant(150, c3,2);


            // Ajout d'opérations
            Operation operation1 = new(20);
            Operation operation2 = new(-40);
            Operation operation3 = new(20);
            Operation operation4 = new(-40);
            Operation operation5 = new(20);
            Operation operation6 = new(-40);

            // Ajout des opération au comptes
            compte1.Operations.Add(operation1);
            compte1.Operations.Add(operation2);
            compte2.Operations.Add(operation3);
            compte2.Operations.Add(operation4);
            compte3.Operations.Add(operation5);
            compte3.Operations.Add(operation6);
            // Ajout du compte à la collection comptes de la Bank
            bank.Comptes.Add(compte1);
            bank.Comptes.Add(compte2);
            bank.Comptes.Add(compte3);

        }
    }
}
