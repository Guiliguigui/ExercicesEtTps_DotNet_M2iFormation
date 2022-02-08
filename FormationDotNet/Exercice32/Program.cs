Console.WriteLine("Insertion des valeurs du tableau : ");
int[] valeurs = new int[10];
Random rnd = new Random();
for (int i = 0; i < 10; i++)
{
    Console.Write($"Saisir la valeur {i + 1} : ");
    valeurs[i] = rnd.Next(0,100);
    Console.WriteLine(valeurs[i]);
}
Console.WriteLine("Affichage des valeurs du tableau : ");
for (int i = 0; i < 10; i++)
    Console.WriteLine($"{string.Concat(Enumerable.Repeat("\t", i))}{valeurs[i]}");
