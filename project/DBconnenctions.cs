using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class DBconnenctions
    {
        public string GetConnStr()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<DBconnenctions>()
                .Build();
            string Conn = config["connectionstring"];
            return Conn;
        }
        public DataTable Getdata()
        {
            string query = "select * from Users";
            DataTable dataTable = new DataTable();
            using(SqlConnection connection = new SqlConnection(GetConnStr()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }
}
