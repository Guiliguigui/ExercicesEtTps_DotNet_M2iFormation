using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles
{
    internal class Nouvelle
    {
        private int id;
        public string Sujet { get; set; }
        public string TexteDescriptif { get; set; }
        public Forum Forum { get; set; }
        public Abonne Abonne { get; set; }
        public List<Nouvelle> Reponses { get; set; } = new List<Nouvelle>();
        public int Id { get => id; set => id = value; }

        public Nouvelle(string sujet, string texteDescriptif, Forum forum, Abonne abonne)
        {
            Sujet = sujet;
            TexteDescriptif = texteDescriptif;
            Forum = forum;
            Abonne = abonne;
        }

        public Nouvelle()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Sujet)}={Sujet}, {nameof(TexteDescriptif)}={TexteDescriptif}, {nameof(Abonne)}={Abonne}, {nameof(Reponses)}=\n\t{string.Join("\n\t", Reponses)}}}";
        }
    }
}
