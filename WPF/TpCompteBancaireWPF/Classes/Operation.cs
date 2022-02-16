using TpCompteBancaireWPF.Data;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;

namespace TpCompteBancaireWPF.Classes
{
    public class Operation
    {
        private int id;
        private int idCompte;
        private decimal montant;
        private DateTime dateOperation;

        public int Id { get => id; set => id = value; }
        public decimal Montant { get => montant; set => montant = value; }
        public DateTime DateOperation { get => dateOperation; set => dateOperation = value; }
        public int IdCompte { get => idCompte; set => idCompte = value; }
        public string Type => montant >= 0 ? "Dépot" : "Retrait";


        public Operation(decimal montant)
        {
            Montant = montant;
            DateOperation = DateTime.Now;
        }

        public Operation(int Id, int IdCompte, DateTime date, decimal montant)
        {
            this.Id = Id;
            this.IdCompte = IdCompte;
            Montant = montant;
            DateOperation = date;
        }

        public override string ToString()
        {
            return $"Id : {Id}, Date : {DateOperation}, Montant : {Montant}";
        }

        public int AjouterOperation(int idCompte)
        {
            SqlConnection connection = DataBase.Connection;
            SqlCommand command = new SqlCommand("INSERT INTO operation (idCompte,dateOperation, montant) VALUES (@IdCompte, @DateOperation, @Montant)", connection);
            command.Parameters.Add(new SqlParameter("@IdCompte", idCompte));
            command.Parameters.Add(new SqlParameter("@DateOperation", DateOperation));
            command.Parameters.Add(new SqlParameter("@Montant", Montant));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbLigne;
        }

        public static List<Operation> ChercherOperationParCompte(Compte c)
        {
            SqlConnection connection = DataBase.Connection;
            List<Operation> liste = new List<Operation>();
            SqlCommand command = new SqlCommand("SELECT * FROM operation WHERE idcompte = @IdCompte", connection);
            command.Parameters.Add(new SqlParameter("@IdCompte", c.Id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Operation o = new Operation(reader.GetInt32(0), c.Id, reader.GetDateTime(2), reader.GetDecimal(3));
                liste.Add(o);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }
    }
}
