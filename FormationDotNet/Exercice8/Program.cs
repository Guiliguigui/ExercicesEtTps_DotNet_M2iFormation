Console.Write("Entrer le prix HT de l'objet (en Euros) : ");
float prixHT = float.Parse(Console.ReadLine());
Console.Write("Entrer le taux de TVA (en %) : ");
float tauxTVA = float.Parse(Console.ReadLine()) / 100;
Console.WriteLine("Le montant de la T.V.A est de " + (prixHT * tauxTVA) + " Euros");
Console.WriteLine("Le prix TTC de l'objet est de " + (prixHT * (1-tauxTVA)) + " Euros");
Console.WriteLine();
Console.WriteLine("Appuyer sur une touche pour fermer le programme...");