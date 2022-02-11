using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompteBancaireHeritage.Classes;
using TpCompteBancaireHeritage.Tools;

namespace TpCompteBancaireHeritage.DAO
{
    internal class OperationDAO : BaseDAO<Operation>
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Operation Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Operation> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Operation> GetAll(int compteId)
        {
            List<Operation> operations = new List<Operation>();
            request = "SELECT montant, date_operation, id from operation where compte_id= @compte_id";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@compte_id", compteId));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Operation operation = new Operation()
                {
                    Montant = reader.GetDecimal(0),
                    Date = reader.GetDateTime(1),
                    Id = reader.GetInt32(2)
                };
                operations.Add(operation);
            }
            reader.Close();
            command.Dispose();
            return operations;
        }

        public override bool Save(Operation element)
        {
            throw new NotImplementedException();
        }

        public bool Save(Operation element, int compteId)
        {
            request = "INSERT INTO operation (montant, date_operation, compte_id) OUTPUT INSERTED.ID values (@montant, @date_operation, @compte_id)";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@montant", element.Montant));
            command.Parameters.Add(new SqlParameter("@date_operation", element.Date));
            command.Parameters.Add(new SqlParameter("@compte_id", compteId));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public override bool Update(Operation element)
        {
            throw new NotImplementedException();
        }
    }
}
