using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles
{
    internal class Forum
    {
        public string Nom { get; set; }
        public DateTime DateCreation { get; set; }=DateTime.Now;
        public List<Abonne> Abonnes { get; set; } = new List<Abonne>();
        public List<Nouvelle> Nouvelles { get; set; } = new List<Nouvelle>();

        public Forum(string nomForum, string nomModerateurDefaut, string prenomModerateurDefaut, int ageModerateurDefaut)
        {
            Nom = nomForum;
            Abonnes.Add(new Moderateur(nomModerateurDefaut, prenomModerateurDefaut, ageModerateurDefaut, this));
        }

        public override string ToString()
        {
            return $"{{{nameof(Nom)}={Nom}, {nameof(DateCreation)}={DateCreation.ToString()}}}";
        }
    }
}
