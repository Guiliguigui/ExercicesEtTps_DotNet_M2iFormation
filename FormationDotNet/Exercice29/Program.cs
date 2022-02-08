Console.WriteLine("--- Gestion des notes ---");
Console.WriteLine("Veuillez saisir les notes :");
Console.WriteLine("(999 pour calculer)");
int somme = 0, min = 20, max = 0, numeroNote = 1, note;
bool valide;
do
{
    do
    {
        valide = false;
        Console.Write($"\t - Merci de saisir la note {numeroNote} (sur /20) : ");
        if (!(int.TryParse(Console.ReadLine(), out note) && ( (note >= 0 && note <= 20) || note == 999)))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t\tErreur de saisie, la note est sur 20 !");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
            valide = true;

    }while(!valide);
    if (note != 999)
    {
        somme += note;
        max = note > max ? note : max;
        min = note < min ? note : min;
    }
    numeroNote++;
}while(note != 999);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"La meilleure note est {max}/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"La moins bonne note est {min}/20");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"La moyenne des {numeroNote} notes est {somme / numeroNote}/20");