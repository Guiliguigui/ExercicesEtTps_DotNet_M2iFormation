using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using TPForumAspNetCore.Models;
using TPForumAspNetCore.Tools;

namespace TPForumAspNetCore.DAO
{
    public class MessageDAO : BaseDAO<Message>
    {
        public bool Add(Message message, int topicId)
        {
            connection = Connection.New;
            SqlCommand command = new SqlCommand("INSERT INTO message (dateCreation, authorId, subject, text, topic) OUTPUT INSERTED.Id VALUES (@DateCreation, @AuthorId, @Subject, @Text, @Topic)", connection);
            command.Parameters.Add(new SqlParameter("@DateCreation", message.DateCreation));
            command.Parameters.Add(new SqlParameter("@AuthorId", message.Author.Id));
            command.Parameters.Add(new SqlParameter("@Subject", message.Subject));
            command.Parameters.Add(new SqlParameter("@Text", message.Text));
            command.Parameters.Add(new SqlParameter("@Topic", topicId));

            connection.Open();
            message.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();

            return message.Id > 0;
        }

        public override bool Delete(int id)
        {
            connection = Connection.New;
            SqlCommand command = new SqlCommand("DELETE FROM message WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", id));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return nbLigne == 1;
        }

        public override Message Get(int id)
        {
            Message message = null;
            connection = Connection.New;
            SqlCommand command = new SqlCommand("SELECT id, dateCreation, authorId, subject, text, topic FROM message WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                message = new Message { Id = id, DateCreation = reader.GetDateTime(1), Author = new UserDAO().Get(reader.GetInt32(2)), Subject = reader.GetString(3), Text = reader.GetString(4)};
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return message;
        }

        public override List<Message> GetAll()
        {
            List<Message> liste = new List<Message>();
            connection = Connection.New;
            SqlCommand command = new SqlCommand("SELECT id, dateCreation, authorId, subject, text FROM message", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Message message = new Message { Id = reader.GetInt32(0), DateCreation = reader.GetDateTime(1), Author = new UserDAO().Get(reader.GetInt32(2)), Subject = reader.GetString(3), Text = reader.GetString(4)};
                liste.Add(message);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }

        public override bool Update(Message message)
        {
            connection = Connection.New;
            SqlCommand command = new SqlCommand("UPDATE message SET dateCreation = @DateCreation, authorId = @AuthorId, subject = @Subject, text = @Text, topic = @Topic WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", message.Id));
            command.Parameters.Add(new SqlParameter("@DateCreation", message.DateCreation));
            command.Parameters.Add(new SqlParameter("@AuthorId", message.Author.Id));
            command.Parameters.Add(new SqlParameter("@Subject", message.Subject));
            command.Parameters.Add(new SqlParameter("@Text", message.Text));

            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbLigne == 1;
        }

        public List<Message> GetByTopic(int topicId)
        {
            List<Message> liste = new List<Message>();
            connection = Connection.New;
            SqlCommand command = new SqlCommand("SELECT id, dateCreation, authorId, subject, text FROM message WHERE topic = @Topic", connection);
            command.Parameters.Add(new SqlParameter("@Topic", topicId));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Message message = new Message { Id = reader.GetInt32(0), DateCreation = reader.GetDateTime(1), Author = new UserDAO().Get(reader.GetInt32(2)), Subject = reader.GetString(3), Text = reader.GetString(4)};
                liste.Add(message);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }

        public override bool Add(Message item)
        {
            throw new System.NotImplementedException();
        }
    }
}
