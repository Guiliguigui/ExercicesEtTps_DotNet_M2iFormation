Console.WriteLine("--- Calcul du périmètre de l'aire d'un carré ---");
Console.Write("Entrer la longueur du premier coté (en cm) : ");
float cote1 = float.Parse(Console.ReadLine());
Console.Write("Entrer la longueur du deuxième coté (en cm) : ");
float cote2 = float.Parse(Console.ReadLine());
Console.WriteLine("La longueur de l'hypothénuse est : " + Math.Sqrt(Math.Pow(cote1, 2) + Math.Pow(cote2, 2)));
Console.WriteLine();
Console.WriteLine("Appuyer sur une touche pour fermer le programme...");
