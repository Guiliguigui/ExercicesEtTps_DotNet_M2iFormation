using ForumNouvelles.Tools;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles.DAO
{
    internal class AbonneDAO : BaseDAO<Abonne>
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Abonne Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Abonne> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Abonne> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Abonne element)
        {
            request = "INSERT INTO abonne (prenom, nom, age, forum_id) OUTPUT INSERTED.ID values (@prenom, @nom, @age, @forum_id)";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@age", element.Age));
            command.Parameters.Add(new SqlParameter("@forum_id", element.Forum.Id));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public override bool Update(Abonne element)
        {
            throw new NotImplementedException();
        }
    }
}
