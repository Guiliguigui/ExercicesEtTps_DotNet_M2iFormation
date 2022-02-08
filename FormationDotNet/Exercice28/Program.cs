bool trouve = false;
Random random = new Random();
int essais = 0, mystere = random.Next(1, 501);
while (!trouve)
{
    essais++;
    Console.Write($"Veuillez saisir un nombre : ");
    int number = int.Parse(Console.ReadLine());
    trouve = mystere == number;
    if(!trouve)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\tLe nombre mystère est plus {(mystere < number ? "petit" : "grand" )}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Bravo !!!! Vous avez trouvé le nombre mystère !");
Console.WriteLine($"Vos avez trouvé en {essais} coups.");
Console.ForegroundColor = ConsoleColor.White;