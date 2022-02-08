using System.Globalization;
string[] mois = new string[12];
mois = new CultureInfo("fr-FR").DateTimeFormat.MonthNames;
Console.WriteLine("Enumération du tableau avec un foreach :");
for(int k = 0; k < mois.Length; k++)
    Console.WriteLine(string.Concat(Enumerable.Repeat("\t", k)) + mois[k]);
