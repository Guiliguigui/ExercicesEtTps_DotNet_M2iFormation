using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace TPForumAspNetCore.DAO
{
    public abstract class BaseDAO<T>
    {
        protected static string request;
        protected static SqlConnection connection;
        protected static SqlCommand command;
        protected static SqlDataReader reader;
        public abstract T Get(int id);
        public abstract List<T> GetAll();
        public abstract bool Add(T item);
        public abstract bool Delete(int id);
        public abstract bool Update(T item);
    }
}
