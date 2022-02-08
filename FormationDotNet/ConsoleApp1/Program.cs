Console.Write("Veillez saisir votre nom : ");
string nom = Console.ReadLine();
Console.Write("Veillez saisir votre prénom : ");
string prenom = Console.ReadLine();
Console.Write("Veillez saisir votre âge : ");
int age = int.Parse(Console.ReadLine());
Console.WriteLine("Bonjour " + prenom + " " + nom + ", vous avez " + age + " ans");
Console.WriteLine();
Console.WriteLine("Appuyer sur une touche pour fermer le programme...");