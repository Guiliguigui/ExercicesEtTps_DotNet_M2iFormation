int annee = 2015;
double habitants = 96809;
while (habitants <= 120000)
{
    habitants += habitants * (0.89 / 100);
    annee++;
}

Console.WriteLine($"Il faudra {annee - 2015} ans, nous seront en {annee}");
Console.WriteLine($"Il y aura {(int)habitants} habitants en {annee}");