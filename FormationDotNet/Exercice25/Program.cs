Console.WriteLine("--- Gestion des notes ---");
Console.WriteLine("Veuillez saisir 5 notes :");
int somme = 0, min = 20, max = 0;
for (int i = 1; i <= 5; i++)
{
    Console.Write($"Merci de saisir la note {i} (sur /20) : ");
    int note = int.Parse(Console.ReadLine());
    somme += note;
    max = note > max ? note : max;
    min = note < min ? note : min;
}
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"La meilleure note est {max}/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"La moins bonne note est {min}/20");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"La moyenne des notes est {somme/5.0}/20");