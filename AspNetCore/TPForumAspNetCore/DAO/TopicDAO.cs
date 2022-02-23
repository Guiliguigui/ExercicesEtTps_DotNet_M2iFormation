using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using TPForumAspNetCore.Models;
using TPForumAspNetCore.Tools;

namespace TPForumAspNetCore.DAO
{
    public class TopicDAO : BaseDAO<Topic>
    {
        public override bool Add(Topic topic)
        {
            connection = Connection.New;
            SqlCommand command = new SqlCommand("INSERT INTO topic (dateCreation, authorId, subject, text) OUTPUT INSERTED.Id VALUES (@DateCreation, @AuthorId, @Subject, @Text)", connection);
            command.Parameters.Add(new SqlParameter("@DateCreation", topic.DateCreation));
            command.Parameters.Add(new SqlParameter("@AuthorId", topic.Author.Id));
            command.Parameters.Add(new SqlParameter("@Subject", topic.Subject));
            command.Parameters.Add(new SqlParameter("@Text", topic.Text));

            connection.Open();
            topic.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();

            return topic.Id > 0;
        }

        public override bool Delete(int id)
        {
            connection = Connection.New;
            SqlCommand command = new SqlCommand("DELETE FROM topic WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", id));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return nbLigne == 1;
        }

        public override Topic Get(int id)
        {
            Topic topic = null;
            connection = Connection.New;
            SqlCommand command = new SqlCommand("SELECT id, dateCreation, authorId, subject, text FROM topic WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                topic = new Topic { Id = id, DateCreation = reader.GetDateTime(1), Author = new UserDAO().Get(reader.GetInt32(2)), Subject = reader.GetString(3), Text = reader.GetString(4)};
                topic.Messages = new MessageDAO().GetByTopic(id);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return topic;
        }

        public override List<Topic> GetAll()
        {
            List<Topic> liste = new List<Topic>();
            connection = Connection.New;
            SqlCommand command = new SqlCommand("SELECT id, dateCreation, authorId, subject, text FROM topic", connection);
            connection.Close();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Topic topic = new Topic { Id = reader.GetInt32(0), DateCreation = reader.GetDateTime(1), Author = new UserDAO().Get(reader.GetInt32(2)), Subject = reader.GetString(3), Text = reader.GetString(4) };
                topic.Messages = new MessageDAO().GetByTopic(topic.Id);
                liste.Add(topic);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }

        public override bool Update(Topic topic)
        {
            connection = Connection.New;
            SqlCommand command = new SqlCommand("UPDATE topic SET dateCreation = @DateCreation, authorId = @AuthorId, subject = @Subject, text = @Text WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", topic.Id));
            command.Parameters.Add(new SqlParameter("@DateCreation", topic.DateCreation));
            command.Parameters.Add(new SqlParameter("@AuthorId", topic.Author.Id));
            command.Parameters.Add(new SqlParameter("@Subject", topic.Subject));
            command.Parameters.Add(new SqlParameter("@Text", topic.Text));

            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbLigne == 1;
        }

        public int CountPostByUser(int userId)
        {
            connection = Connection.New;
            SqlCommand command = new SqlCommand("SELECT COUNT(id) FROM topic WHERE authorId = @UserId", connection);
            command.Parameters.Add(new SqlParameter("@UserId", userId));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return 0;
        }
    }
}
