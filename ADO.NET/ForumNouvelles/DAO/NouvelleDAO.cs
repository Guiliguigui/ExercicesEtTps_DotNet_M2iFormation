using ForumNouvelles.Tools;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles.DAO
{
    internal class NouvelleDAO : BaseDAO<Nouvelle>
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Nouvelle Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Nouvelle> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Nouvelle> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public List<Nouvelle> GetAll(string sujet)
        {
            List<Nouvelle> nouvelles = new List<Nouvelle>();
            ForumDAO forumDAO = new ForumDAO();
            AbonneDAO abonneDAO = new AbonneDAO();
            request = "SELECT id, texte_descriptif, abonne_id, forum_id from nouvelle where sujet = @id";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@sujet", sujet));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Nouvelle nouvelle = new Nouvelle()
                {
                    Id = reader.GetInt32(0),
                    Sujet = sujet,
                    TexteDescriptif = reader.GetString(1)
                };
                if (nouvelle != null)
                {
                    nouvelle.Abonne = abonneDAO.Get(reader.GetInt32(2));
                    nouvelle.Forum = forumDAO.Get(reader.GetInt32(3));
                    nouvelles.Add(nouvelle);
                }
            }
            reader.Close();
            command.Dispose();
            return nouvelles;
        }

        public override bool Save(Nouvelle element)
        {
            request = "INSERT INTO nouvelle (sujet, texte_descriptif, abonne_id, forum_id) OUTPUT INSERTED.ID values (@sujet, @texte_descriptif, @abonne_id, @forum_id)";
            connection = DataBase.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@sujet", element.Sujet));
            command.Parameters.Add(new SqlParameter("@texte_descriptif", element.TexteDescriptif));
            command.Parameters.Add(new SqlParameter("@abonne_id", element.Abonne));
            command.Parameters.Add(new SqlParameter("@forum_id", element.Forum.Id));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public override bool Update(Nouvelle element)
        {
            throw new NotImplementedException();
        }
    }
}
