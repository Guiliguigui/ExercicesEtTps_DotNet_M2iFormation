using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles
{
    internal class Nouvelle
    {
        public string Sujet { get; set; }
        public string TexteDescriptif { get; set; }
        public Forum Forum { get; set; }
        public Abonne Abonne { get; set; }
        public List<KeyValuePair<Abonne, string>> Commentaires { get; set; } = new List<KeyValuePair<Abonne,string>>();

        public Nouvelle(string sujet, string texteDescriptif, Forum forum, Abonne abonne)
        {
            Sujet = sujet;
            TexteDescriptif = texteDescriptif;
            Forum = forum;
            Abonne = abonne;
        }

        public override string ToString()
        {
            return $"{{{nameof(Sujet)}={Sujet}, {nameof(TexteDescriptif)}={TexteDescriptif}, {nameof(Abonne)}={Abonne}, {nameof(Commentaires)}=\n{string.Join("\n", Commentaires)}}}";
        }
    }
}
