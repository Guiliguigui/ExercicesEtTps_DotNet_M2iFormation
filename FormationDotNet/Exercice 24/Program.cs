Console.Write("Merci de saisir un nombre : ");
int entier = int.Parse(Console.ReadLine());
Console.WriteLine("Les chaînes possibles sont : ");
List<KeyValuePair<int,int>> suites = new List<KeyValuePair<int,int>>();
for (int i = 1; i < entier; i++)
{
    int somme = 0;
    for (int j = i; somme < entier; j++)
    {
        somme+=j;
        if(somme==entier)
        {
            suites.Add(new KeyValuePair<int,int>(i,j));
        }
    }
}
foreach (var pair in suites)
{
    Console.Write($"{entier} = ");
    Console.Write($"{pair.Key}");
    for (int i = pair.Key+1; i <= pair.Value; i++)
    {
        Console.Write($"+{i}");
    }
    Console.WriteLine();
}