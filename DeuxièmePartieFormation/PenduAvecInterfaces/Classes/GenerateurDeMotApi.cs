using PenduAvecInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PenduAvecInterfaces.Classes
{
    internal class GenerateurDeMotApi : IGenerateurDeMot
    {
        static WebClient client = new WebClient();
        public string Generer()
        {
            string response = Encoding.ASCII.GetString(client.DownloadData($"https://random-word-api.herokuapp.com/word?number=1"));
            //string response = Encoding.ASCII.GetString(client.DownloadData($"https://fr.wiktionary.org/w/api.php?action=query&list=random&format=json&rnnamespace=0"));

            return JsonSerializer.Deserialize<string[]>(response)[0];
        }
    }
}
