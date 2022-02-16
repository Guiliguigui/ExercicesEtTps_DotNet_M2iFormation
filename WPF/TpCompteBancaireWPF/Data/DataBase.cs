using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;

namespace TpCompteBancaireWPF.Data
{
    class DataBase
    {
        private static string chaine = @"Data Source=(LocalDB)\M2iValenciennes;Integrated Security=True";

        public static SqlConnection Connection { get => new SqlConnection(chaine); }
    }
}
