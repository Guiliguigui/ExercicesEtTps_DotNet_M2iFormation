using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using TPForumAspNetCore.Models;
using TPForumAspNetCore.Tools;

namespace TPForumAspNetCore.DAO
{
    public class UserDAO : BaseDAO<User>
    {
        public override bool Add(User user)
        {
            connection = Connection.New;
            command = new SqlCommand("INSERT INTO users (isAdmin, nickName, firstName, lastName, email, phone, password) OUTPUT INSERTED.Id VALUES (@IsAdmin, @NickName, @FirstName, @LastName, @Email, @Phone, @Password)", connection);
            command.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
            command.Parameters.Add(new SqlParameter("@NickName", user.NickName));
            command.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
            command.Parameters.Add(new SqlParameter("@LastName", user.LastName));
            command.Parameters.Add(new SqlParameter("@Email", user.Email));
            command.Parameters.Add(new SqlParameter("@Phone", user.Phone));
            command.Parameters.Add(new SqlParameter("@Password", user.Password));

            connection.Open();
            user.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();

            return user.Id > 0;
        }

        public override bool Delete(int id)
        {
            connection = Connection.New;
            command = new SqlCommand("DELETE FROM users WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", id));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return nbLigne == 1;
        }

        public override User Get(int id)
        {
            User user = null;
            connection = Connection.New;
            SqlCommand command = new SqlCommand("SELECT id, isAdmin, nickName, firstName, lastName, email, phone, password FROM users WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetBoolean(1))
                    user = new Administrator();
                else
                    user = new User();
                user.Id = reader.GetInt32(0);
                user.IsAdmin = reader.GetBoolean(1);
                user.NickName = reader.GetString(2);
                user.FirstName = reader.GetString(3);
                user.LastName = reader.GetString(4);
                user.Email = reader.GetString(5);
                user.Phone = reader.GetString(6);
                user.Password = reader.GetString(7);
                user.NbPosts = new TopicDAO().CountPostByUser(user.Id);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            if (user.IsAdmin)
                return user as Administrator;
            else
                return user;
        }
        
        public override List<User> GetAll()
        {
            List<User> list = new List<User>();
            connection = Connection.New;
            SqlCommand command = new SqlCommand("SELECT id, isAdmin, nickName, firstName, lastName, email, phone, password FROM users", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user;
                if (reader.GetBoolean(1))
                    user = new Administrator();
                else
                    user = new User();
                user.Id = reader.GetInt32(0); 
                user.IsAdmin = reader.GetBoolean(1); 
                user.NickName = reader.GetString(2); 
                user.FirstName = reader.GetString(3); 
                user.LastName = reader.GetString(4); 
                user.Email = reader.GetString(5); 
                user.Phone = reader.GetString(6); 
                user.Password = reader.GetString(7);
                user.NbPosts = new TopicDAO().CountPostByUser(user.Id);
                list.Add(user);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return list;
        }

        public override bool Update(User user)
        {
            connection = Connection.New;
            SqlCommand command = new SqlCommand("UPDATE users SET isAdmin = @IsAdmin, nickName = @NickName, firstName = @FirstName, lastName = @LastName, email = @Email, phone = @Phone, password = @Password WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", user.Id));
            command.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
            command.Parameters.Add(new SqlParameter("@NickName", user.NickName));
            command.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
            command.Parameters.Add(new SqlParameter("@LastName", user.LastName));
            command.Parameters.Add(new SqlParameter("@Email", user.Email));
            command.Parameters.Add(new SqlParameter("@Phone", user.Phone));
            command.Parameters.Add(new SqlParameter("@Password", user.Password));

            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbLigne == 1;
        }
    }
}
