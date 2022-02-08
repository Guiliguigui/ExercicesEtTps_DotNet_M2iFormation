Console.WriteLine("--- Est pair...? Est impair...? ---");
Console.WriteLine("Combien de nombre contiendra le tableau ? : ");
int nbValeurs = int.Parse(Console.ReadLine());
int[] valeurs = new int[nbValeurs];
Console.WriteLine("Affectation automatique des valeurs...\n");
Random rnd = new Random();
for (int i = 0; i < nbValeurs; i++)
    valeurs[i] = rnd.Next(1, 51);
Console.WriteLine("Verification des valeurs du tableau :");
for (int i = 0; i < nbValeurs; i++)
    Console.WriteLine($"\tLe nombre {valeurs[i]} est {(valeurs[i]%2==0?"":"im")}pair.");
