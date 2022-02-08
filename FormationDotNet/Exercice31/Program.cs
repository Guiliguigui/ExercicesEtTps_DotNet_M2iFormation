Console.WriteLine("--- Gestion des notes avec menu ---");
int somme = 0, min = 20, max = 0, i = 1, note;
bool valide, quitter = false;
do
{
    Console.WriteLine("\n1----Saisir les notes");
    Console.WriteLine("2----La plus grande note");
    Console.WriteLine("3----La plus petite note");
    Console.WriteLine("4----La moyenne des notes");
    Console.WriteLine("0----Quitter\n");
    Console.Write("Faites votre choix : ");
    string choix = Console.ReadLine();
    Console.Clear();

    switch (choix)
    {
        case "1":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----- Saisir les notes -----");
            Console.WriteLine("(999 pour stopper la saisie)");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                do
                {
                    valide = false;
                    Console.Write($"\t - Merci de saisir la note {i} (sur /20) : ");
                    if (!(int.TryParse(Console.ReadLine(), out note) && ((note >= 0 && note <= 20) || note == 999)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\t\tErreur de saisie, la note est sur 20 !");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        valide = true;

                } while (!valide);
                if (note != 999)
                {
                    somme += note;
                    max = note > max ? note : max;
                    min = note < min ? note : min;
                }
                i++;
            } while (note != 999);
            break;
        case "2":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"----- La plus grande note -----");
            Console.WriteLine($"La note la plus grande est {max}/20");
            Console.ForegroundColor = ConsoleColor.White;

            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"----- La plus petite note -----");
            Console.WriteLine($"La note la plus petite est {min}/20");
            Console.ForegroundColor = ConsoleColor.White;

            break;
        case "4":
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"----- La moyenne des notes -----");
            Console.WriteLine($"La moyenne est de {(double)somme / i}/20");
            Console.ForegroundColor = ConsoleColor.White;

            break;
        case "0":
            Console.WriteLine("A bientôt!");
            Environment.Exit(0);
            //quitter = true;
            break;
        default:
            Console.WriteLine("Mauvaise saisie de choix ! Ressaisir");
            break;
    }
} while (!quitter);
