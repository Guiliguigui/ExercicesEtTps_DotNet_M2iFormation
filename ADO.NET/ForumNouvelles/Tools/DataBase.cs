using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumNouvelles.Tools
{
    public class DataBase
    {
        static string connectionString = @"Data Source=(LocalDB)\M2iValenciennes;Integrated Security=True";

        public static SqlConnection Connection { get => new SqlConnection(connectionString); }
    }
}
