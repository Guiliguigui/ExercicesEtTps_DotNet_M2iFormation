using System;
using System.Collections.Generic;
using System.Linq;

namespace TirageTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person("a", "a", "a"),
                new Person("b", "b", "b"),
                new Person("c", "c", "c"),
                new Person("d", "d", "d"),
                new Person("e", "e", "e")
            };

            JsonListDAO<Person> jsonListDAO = new JsonListDAO<Person>(@".\Saves");
            Console.WriteLine(jsonListDAO.SaveList("listeIncroyable", people) ? "Sauvegardée" : "Erreur");
            List<Person> people1 = jsonListDAO.LoadList("listeIncroyable");
            people1.ForEach(p => Console.WriteLine(p));

            jsonListDAO.GetJsonListFiles().ForEach(p => Console.WriteLine(p));
        }
    }
}
