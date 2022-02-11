using CorrectionAnnuaireAdoNet.Tools;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionAnnuaireAdoNet.Classes
{
    public class Contact
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private static string request;
        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader reader;
        public Contact()
        {
        }

        public Contact(int id, string firstName, string lastName, string email, string phone)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }

        public bool Save()
        {
            request = "INSERT INTO utilisateur (nom, prenom, email, telephone) OUTPUT INSERTED.ID values (@nom, @prenom, @email, @telephone)";
            connection = DataBaseTools.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", LastName));
            command.Parameters.Add(new SqlParameter("@prenom", FirstName));
            command.Parameters.Add(new SqlParameter("@email", Email));
            command.Parameters.Add(new SqlParameter("@telephone", Phone));
            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        public bool Update()
        {
            return false;
        }

        public bool Delete()
        {
            return false;
        }

        public static Contact SearchByPhone(string phone)
        {
            return null;
        }
        public static List<Contact> GetContacts()
        {
            return null;
        }
    }
}
