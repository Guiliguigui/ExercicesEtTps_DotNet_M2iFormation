Console.WriteLine("--- Question à choix multiple ---");
Console.WriteLine("Quelle est l'instruction qui permet de sortir d'une boucle en C# ?");
Console.WriteLine("\ta) quit");
Console.WriteLine("\tb) continue");
Console.WriteLine("\tc) break");
Console.WriteLine("\td) exit");
bool reesayer = false;
bool reponseVraie = false;
do
{
    reesayer = false;
    Console.WriteLine("Entrez votre réponse : ");
    string rep = Console.ReadLine().ToUpper();
    if (rep != "C")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Incorecte!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Un nouvel essai ? Oui / Non");
        reesayer = Console.ReadLine().ToUpper() == "OUI" ? true : false ;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Bravo!!! C'est la bonne réponse");
        Console.ForegroundColor = ConsoleColor.White;
        reponseVraie = true;
    }
} while (reesayer || !reponseVraie);