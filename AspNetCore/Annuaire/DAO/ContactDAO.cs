using Annuaire.Models;
using System.Collections.Generic;
using Annuaire.Tools;
using Microsoft.Data.SqlClient;

namespace Annuaire.DAO
{
    public class ContactDAO : BaseDAO<Contact>
    {
        public override bool Delete(int id)
        {
            request = "DELETE FROM contact WHERE id=@id";
            connection = DataBaseTools.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public override Contact Get(int id)
        {
            Contact contact = null;
            request = "SELECT firstname, lastname, phone from contact where id = @id";
            connection = DataBaseTools.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                contact = new Contact(reader.GetString(0), reader.GetString(1), reader.GetString(2))
                {
                    Id = id
                };
            }
            return contact;
        }

        public override List<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();
            request = "SELECT id, firstname, lastname, phone  from contact";
            connection = DataBaseTools.Connection;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Contact contact = new Contact()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.GetString(3)
                };
                contacts.Add(contact);
            }
            reader.Close();
            command.Dispose();
            return contacts;
        }

        public override List<Contact> GetAll(int id)
        {
            throw new System.NotImplementedException();
        }

        public override bool Save(Contact contact)
        {
            request = "INSERT INTO contact (firstname, lastname, phone) OUTPUT INSERTED.ID values (@firstname, @lastname, @phone)";
            connection = DataBaseTools.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@firstname", contact.FirstName));
            command.Parameters.Add(new SqlParameter("@lastname", contact.LastName));
            command.Parameters.Add(new SqlParameter("@phone", contact.Phone));
            connection.Open();
            contact.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return contact.Id > 0;
        }

        public override bool Update(Contact contact)
        {
            request = "UPDATE contact SET firstname=@firstname, lastname=@lastname, phone=@phone WHERE id=@id";
            connection = DataBaseTools.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", contact.Id));
            command.Parameters.Add(new SqlParameter("@firstname", contact.FirstName));
            command.Parameters.Add(new SqlParameter("@lastname", contact.LastName));
            command.Parameters.Add(new SqlParameter("@phone", contact.Phone));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
