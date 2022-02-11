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
    internal class ClientDAO : BaseDAO<Client>
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Client Get(int id)
        {
            Client client = null;
            request = "SELECT nom, prenom, telephone from client where id = @id";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                client = new Client(reader.GetString(0), reader.GetString(1), reader.GetString(2))
                {
                    Id = id
                };
            }
            return client;
        }

        public override List<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Client> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Client element)
        {
            request = "INSERT INTO client (nom, prenom, telephone) OUTPUT INSERTED.ID values (@nom, @prenom,@telephone)";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", element.Telephone));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public override bool Update(Client element)
        {
            throw new NotImplementedException();
        }
    }
}
