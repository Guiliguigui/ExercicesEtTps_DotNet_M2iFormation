int annee = 2015;
double habitants = 96809;
for (annee = 2015; habitants <= 120000; annee++)
{
    habitants += habitants * (0.89 / 100);
    habitants = habitants + ( habitants * (0.89 / 100));
    habitants = habitants * (1 + (0.89 / 100));
}

Console.WriteLine($"Il faudra {annee - 2015} ans, nous seront en {annee}");
Console.WriteLine($"Il y aura {(int)habitants} habitants en {annee}");