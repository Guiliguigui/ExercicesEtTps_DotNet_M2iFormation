using ForumNouvelles.Tools;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles.DAO
{
    internal class ForumDAO : BaseDAO<Forum>
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Forum Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Forum> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Forum> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Forum element)
        {
            request = "INSERT INTO forum (nom, dateCreation) OUTPUT INSERTED.ID values (@nom, @dateCreation)";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@dateCreation", element.DateCreation));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public override bool Update(Forum element)
        {
            throw new NotImplementedException();
        }
    }
}
