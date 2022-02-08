Console.WriteLine("--- Le nombre est-il divisible par...? ---");
Console.WriteLine();
Console.Write("Entrer un chiffre/nombre entier : ");
int entier = int.Parse(Console.ReadLine());
Console.Write("Entrer un chiffre/nombre diviseur : ");
int diviseur = int.Parse(Console.ReadLine());

bool divisible = entier % diviseur == 0;

Console.WriteLine($"Le {(entier < 10 ? "chiffre" : "nombre")} {(divisible ? "" : "n'")}est{(divisible? "" : " pas")} divisible par {diviseur}");

Console.WriteLine();
Console.WriteLine("Appuyer sur une touche pour fermer le programme...");