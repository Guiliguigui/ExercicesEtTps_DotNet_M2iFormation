using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompteBancaireHeritage.Tools;

namespace TpCompteBancaireHeritage.Classes
{
    public class Client : BaseModel
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private static int counter = 0;

        public Client()
        {
            //Id=++counter;
        }
        //public Client(string name) : this()
        //{
        //    Nom = name;
        //}

        //public Client(int id) : this()
        //{
        //    Id = id;
        //}

        public Client(string nom, string prenom, string telephone) :this()
        {
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public static int Counter { get => counter; }

        public override string ToString()
        {
            return $"Id: {Id} - Nom : {Nom}, Prénom :{Prenom}, Téléphone : {Telephone}";
        }

        //public bool Save()
        //{
        //    request = "INSERT INTO client (nom, prenom, telephone) OUTPUT INSERTED.ID values (@nom, @prenom,@telephone)";
        //    connection = DataBase.Connection;
        //    command = new SqlCommand(request, connection);
        //    command.Parameters.Add(new SqlParameter("@nom", Nom));
        //    command.Parameters.Add(new SqlParameter("@prenom", Prenom));
        //    command.Parameters.Add(new SqlParameter("@telephone", Telephone));
        //    connection.Open();
        //    Id = (int)command.ExecuteScalar();
        //    command.Dispose();
        //    connection.Close();
        //    return Id > 0;
        //}
        //public static Client GetClientById(int id)
        //{
        //    Client client = null;
        //    request = "SELECT nom, prenom, telephone from client where id = @id";
        //    connection = DataBase.Connection;
        //    command = new SqlCommand(request, connection);
        //    command.Parameters.Add(new SqlParameter("@id", id));
        //    connection.Open();
        //    reader = command.ExecuteReader();
        //    if(reader.Read())
        //    {
        //        client = new Client(reader.GetString(0), reader.GetString(1), reader.GetString(2)) { 
        //            Id = id
        //        };
        //    }
        //    return client;
        //} 
    }
}
