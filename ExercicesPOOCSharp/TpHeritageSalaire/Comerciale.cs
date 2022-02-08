using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp5HeritageSalaire
{
    public class Comerciale : Salarie
    {
        public int ChiffreDAffaire { get; set; }
        public int Commission { get; set; }

        public Comerciale() : base()
        {

        }
        public Comerciale(string matricule, string categorie, string service, string nom, int salaire, int chiffreDAffaire, int commission) : base(matricule, categorie, service, nom, salaire)
        {
            ChiffreDAffaire = chiffreDAffaire;
            Commission = commission;
        }
        public override int CalculerSalaire()
        {
            return Salaire + (ChiffreDAffaire * Commission / 100);
        }
        public override void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire fixe de {Nom} est de {Salaire} (avec commission : {CalculerSalaire()})");
        }
    }
}
