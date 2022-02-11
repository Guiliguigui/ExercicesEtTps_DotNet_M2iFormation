using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompteBancaireHeritage.DAO;

namespace TpCompteBancaireHeritage.Classes
{
    public class Bank
    {
        private List<Compte> comptes;
        private CompteDAO compteDAO;
        private ClientDAO clientDAO;
        internal List<Compte> Comptes { get => comptes; set => comptes = value; }

        public Bank()
        {
            Comptes = new List<Compte>();
        }

        public bool AjouterCompte(Compte compte)
        {
            //int avant = Comptes.Count;
            //Comptes.Add(compte);
            //int apres = Comptes.Count;
            //return apres - avant == 1? true : false;
            compteDAO = new CompteDAO();
            clientDAO = new ClientDAO();
            return clientDAO.Save(compte.Client) && compteDAO.Save(compte);

        }

        public Compte RechercherCompte(int id)
        {
            //Compte c = null;
            //c = Comptes.Find(c => c.Id == id);
            //return c;

            // Ecriture simplifiée
            // return Comptes.Find(c => c.Id == id);
            compteDAO = new CompteDAO();
            return compteDAO.Get(id);
        }
    }
}
