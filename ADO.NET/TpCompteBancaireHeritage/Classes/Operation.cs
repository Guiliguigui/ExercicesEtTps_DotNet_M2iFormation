using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompteBancaireHeritage.Tools;

namespace TpCompteBancaireHeritage.Classes
{
    public class Operation : BaseModel
    {
        private int id;
        private DateTime date;
        private decimal montant;
        private static int counter = 0;

        public Operation()
        {
            //Id = ++counter;
            Date = DateTime.Now;
        }

        public Operation(decimal montant) : this()
        {            
            this.Montant = montant;
        }

        public int Id { get => id; set => id = value; }
        
        public static int Counter { get => counter; }
        public decimal Montant { get => montant; set => montant = value; }
        public DateTime Date { get => date; set => date = value; }

        public override string ToString()
        {
            return $"Id: {Id} - Date : {Date}, montant : {Montant}";
        }

        //public bool Save(int compteId)
        //{
        //    request = "INSERT INTO operation (montant, date_operation, compte_id) OUTPUT INSERTED.ID values (@montant, @date_operation, @compte_id)";
        //    connection = DataBase.Connection;
        //    command = new SqlCommand(request, connection);
        //    command.Parameters.Add(new SqlParameter("@montant", Montant));
        //    command.Parameters.Add(new SqlParameter("@date_operation", Date));
        //    command.Parameters.Add(new SqlParameter("@compte_id", compteId));
        //    connection.Open();
        //    Id = (int)command.ExecuteScalar();
        //    command.Dispose();
        //    connection.Close();
        //    return Id > 0; 
        //}

        //public static List<Operation> GetOperations(int compteId)
        //{
        //    List<Operation> operations = new List<Operation>();
        //    request = "SELECT montant, date_operation, id from operation where compte_id= @compte_id";
        //    connection = DataBase.Connection;
        //    command = new SqlCommand(request, connection);
        //    command.Parameters.Add(new SqlParameter("@compte_id", compteId));
        //    connection.Open();
        //    reader = command.ExecuteReader();
        //    while(reader.Read())
        //    {
        //        Operation operation = new Operation()
        //        {
        //            Montant = reader.GetDecimal(0),
        //            Date = reader.GetDateTime(1),
        //            Id = reader.GetInt32(2)
        //        };
        //        operations.Add(operation);
        //    }
        //    reader.Close();
        //    command.Dispose();
        //    return operations;
        //}


    }
}
