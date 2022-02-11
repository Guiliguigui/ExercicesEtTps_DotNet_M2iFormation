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
    public class CompteDAO : BaseDAO<Compte>
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Compte Get(int id)
        {
            Compte compte = null;
            ClientDAO clientDAO = new ClientDAO();
            OperationDAO operationDAO = new OperationDAO();
            int clientId = 0;
            request = "SELECT solde, client_id from compte where id = @id";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                compte = new Compte()
                {
                    Solde = reader.GetDecimal(0),
                    Id = id
                };
                clientId = reader.GetInt32(1);
            }
            reader.Close();
            command.Dispose();
            if (compte != null)
            {
                compte.Client = clientDAO.Get(clientId);
                compte.Operations = operationDAO.GetAll(compte.Id);
            }
            return compte;
        }

        public override List<Compte> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Compte> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Compte compte)
        {
            request = "INSERT INTO compte (solde, client_id) OUTPUT INSERTED.ID values (@solde, @client_id)";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@solde", compte.Solde));
            command.Parameters.Add(new SqlParameter("@client_id", compte.Client.Id));
            connection.Open();
            compte.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return compte.Id > 0;
        }

        public override bool Update(Compte compte)
        {
            request = "UPDATE compte set solde=@solde where id=@id";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@solde", compte.Solde));
            command.Parameters.Add(new SqlParameter("@id", compte.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
