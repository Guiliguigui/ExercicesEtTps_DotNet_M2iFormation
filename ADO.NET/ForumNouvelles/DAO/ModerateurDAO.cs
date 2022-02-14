using ForumNouvelles.Tools;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles.DAO
{
    internal class ModerateurDAO : BaseDAO<Moderateur>
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Moderateur Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Moderateur> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Moderateur> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Moderateur element)
        {
            AbonneDAO abonneDAO = new AbonneDAO();
            if(abonneDAO.Save(element))
            {
                request = "INSERT INTO moderateur (abonne_id) OUTPUT INSERTED.ID values (@abonne_id)";
                connection = DataBase.Connection;
                command = new SqlCommand(request, connection);
                command.Parameters.Add(new SqlParameter("@abonne_id", element.Id));
                connection.Open();
                element.IdModerateur = (int)command.ExecuteScalar();
                command.Dispose();
                connection.Close();
                return element.Id > 0;
            }
            return false;
        }

        public override bool Update(Moderateur element)
        {
            throw new NotImplementedException();
        }
    }
}
