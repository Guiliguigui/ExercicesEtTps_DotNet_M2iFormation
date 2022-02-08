Console.WriteLine("--- Calcul du périmètre de l'aire d'un carré ---");
Console.Write("Entrer la longueur d'un coté du carré (en cm) : ");
float cote = float.Parse(Console.ReadLine());
Console.WriteLine("Le périmètre du carré est : " + (cote*4) + " cm");
Console.WriteLine("L'aire du carré est : " + Math.Pow(cote,2) + " cm2");
Console.WriteLine();


Console.WriteLine("--- Calcul du périmètre de l'aire d'un rectangle ---");
Console.Write("Entrer la longueur du premier coté (en cm) : ");
float cote1 = float.Parse(Console.ReadLine());
Console.Write("Entrer la longueur du deuxième coté (en cm) : ");
float cote2 = float.Parse(Console.ReadLine());
Console.WriteLine("Le périmètre du rectangle est : " + (cote1 + cote2) * 2 + " cm");
Console.WriteLine("L'aire du rectangle est : " + (cote1 * cote2) + " cm2");
Console.WriteLine();