Console.WriteLine("--- La lettre est-elle une voyelle ? ---");
Console.WriteLine();
Console.Write("Entrer une lettre : ");
char lettre = char.ToUpper(char.Parse(Console.ReadLine()));
string voyelles = "AEIOUY";
if (voyelles.Contains(lettre))
    Console.WriteLine("Cette lettre est une voyelle !");
else if ('A' <= lettre && lettre <= 'Z')
    Console.WriteLine("Cette lettre est une consonne !");
else
    Console.WriteLine("Ceci n'est pas une lettre !");
Console.WriteLine();
Console.WriteLine("Appuyer sur une touche pour fermer le programme...");