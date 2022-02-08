Console.WriteLine("--- Dans quelle catégorie est-il...? ---");
Console.WriteLine();
Console.Write("Entrer l'âge de votre enfant : ");
int age = int.Parse(Console.ReadLine());
string categorie;

switch (age)
{
    case >=3 when age<=6:
        categorie = "Baby";
        break;
    case >= 7 when age <= 8:
        categorie = "Poussin";
        break;
    case >= 9 when age <= 10:
        categorie = "Pupille";
        break;
    case >= 11 when age <= 12:
        categorie = "Minime";
        break;
    case >= 13 when age <= 17:
        categorie = "Cadet";
        break;
    case >= 18:
        categorie = "Trop Vieux";
        break;
    default:
        categorie = "Trop Jeune";
        break;
}
Console.WriteLine($"Votre enfant est dans la catégorie {categorie} !");