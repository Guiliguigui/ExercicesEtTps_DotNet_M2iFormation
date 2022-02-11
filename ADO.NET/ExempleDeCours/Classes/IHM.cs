using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleDeCours.Classes
{
    internal static class IHM
    {
        private static string connectionString = @"Data Source=(LocalDB)\M2iValenciennes;Integrated Security=True";
        private static SqlConnection connection = new SqlConnection(connectionString);

        public static void Start()
        {
            string choix;
            do
            {
                Console.Clear();
                choix = Menu();
                switch (choix)
                {
                    case "1":
                        ActionAjouterUtilisateur();
                        break;
                    case "2":
                        ActionSupprimerUtilisateurId();
                        break;
                    case "3":
                        ActionRechercherUtilisateurTelephone();
                        break;
                    case "4":
                        ActionModifierUtilisateur();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }
                WaitUser();
            } while (choix != "0");
        }

        private static void ActionAjouterUtilisateur()
        {
            Console.Write("Merci de saisir le nom : ");
            string nom = Console.ReadLine();
            Console.Write("Merci de saisir le prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Merci de saisir l'email : ");
            string email = Console.ReadLine();
            Console.Write("Merci de saisir le téléphone : ");
            string telephone = Console.ReadLine();

            string request = $"INSERT INTO UTILISATEUR (nom, prenom, email, telephone) OUTPUT INSERTED.Id VALUES (@nom, @prenom, @email, @telephone)";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@prenom", prenom));
            command.Parameters.Add(new SqlParameter("@email", email));
            command.Parameters.Add(new SqlParameter("@telephone", telephone));

            connection.Open();

            int id = (int)command.ExecuteScalar();
            Console.WriteLine("Id d'insertion dans la table : " + id);

            command.Dispose();
            connection.Close();
        }

        private static void ActionSupprimerUtilisateurId()
        {
            Console.Write("Merci de saisir l'identifiant : ");
            string id = Console.ReadLine();

            string request = $"DELETE FROM UTILISATEUR WHERE id = @id";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();

            int nbLigne = command.ExecuteNonQuery();
            Console.WriteLine("Nombre de lignes affectées : " + nbLigne);

            command.Dispose();
            connection.Close();
        }

        private static void ActionRechercherUtilisateurTelephone()
        {
            Console.Write("Merci de saisir le téléphone : ");
            string telephone = Console.ReadLine();

            string request = "SELECT id, nom, prenom,email,telephone FROM UTILISATEUR WHERE telephone=@telephone";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@telephone", telephone));

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Id : {reader.GetInt32(0)}, Nom : {reader.GetString(1)}, Prénom : {reader.GetString(2)}, Email : {reader.GetString(3)},  Téléphone : {reader.GetString(4)}");
            }

            command.Dispose();
            connection.Close();
        }

        private static void ActionModifierUtilisateur()
        {
            Console.Write("Merci de saisir l'identifiant : ");
            string id = Console.ReadLine();

            Console.Write("Merci de saisir le nouveau nom : ");
            string nom = Console.ReadLine();
            Console.Write("Merci de saisir le nouveau prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Merci de saisir le nouveau email : ");
            string email = Console.ReadLine();
            Console.Write("Merci de saisir le nouveau téléphone : ");
            string telephone = Console.ReadLine();

            string request = $"UPDATE UTILISATEUR " +
                $"SET nom = @nom, prenom = @prenom, email = @email, telephone = @telephone " +
                $"WHERE id = @id";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@prenom", prenom));
            command.Parameters.Add(new SqlParameter("@email", email));
            command.Parameters.Add(new SqlParameter("@telephone", telephone));
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();

            int nbLigne = command.ExecuteNonQuery();
            Console.WriteLine("Nombre de lignes affectées : " + nbLigne);

            command.Dispose();
            connection.Close();
        }

        private static string Menu()
        {
            Console.WriteLine("\n--------------- BDD Utilisateurs -------------\n");
            Console.WriteLine("1- Ajouter un utilisateur");
            Console.WriteLine("2- Supprimer un utilisateur par son id");
            Console.WriteLine("3- Rechercher un utilisateur par son téléphone");
            Console.WriteLine("4- Modifier un utilisateur avec son id");
            Console.WriteLine("\n0---Quitter\n");

            Console.Write("Faites votre choix : ");

            return Console.ReadLine();
        }

        private static void WaitUser()
        {
            Console.WriteLine("Veuillez presser Enter pour retourner au menu principal");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
