using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TpCompteBancaireASPNET.Models;

namespace TpCompteBancaireASPNET.Controllers
{
    public class BanqueController : Controller
    {
        public IActionResult Index(int? id)
        {
            if (id == null)
                return View();
            else
            {
                Compte compte = Compte.RechercherCompte((int)id);
                return View(compte);
            }
        }

        public IActionResult DetailsCompte(int id)
        {
            return View(Compte.RechercherCompte(id));
        }

        public IActionResult Depot(int id, decimal? montant)
        {
            Compte compte = Compte.RechercherCompte(id);
            if (montant == null)
                return View(compte);
            else
            {
                Operation operation = new Operation(Math.Abs((decimal)montant));
                compte.Depot(operation);
                return View("DetailsCompte", Compte.RechercherCompte(id));
            }
        }

        public IActionResult Retrait(int id, decimal? montant)
        {
            Compte compte = Compte.RechercherCompte(id);
            if (montant == null)
                return View(compte);
            else
            {
                Operation operation = new Operation(Math.Abs((decimal)montant) * -1);
                compte.Retrait(operation);
                return View("DetailsCompte", Compte.RechercherCompte(id));
            }
        }

        public IActionResult CalculerInterrets(int id)
        {
            CompteEpargne compteEpargne = Compte.RechercherCompte(id) as CompteEpargne;
            compteEpargne.CalculeInteret();
            return View("DetailsCompte", Compte.RechercherCompte(id));
        }

        public IActionResult FormCompte()
        {
            return View();
        }

        public IActionResult SubmitCompte(string nom, string prenom, string telephone, string typeCompte, decimal solde)
        {
            Client client = new Client(nom, prenom, telephone);
            client.Id = client.Add();
            Compte compte;
            switch (typeCompte)
            {
                case "epargne":
                    compte = new CompteEpargne(solde, client, 0.5M);
                    break;
                case "payant":
                    compte = new ComptePayant(solde, client, 2);
                    break;
                default:
                    compte = new Compte(solde, client);
                    break;
            }
            compte.AjouterCompte();
            return View("DetailsCompte", compte);
        }
    }
}
