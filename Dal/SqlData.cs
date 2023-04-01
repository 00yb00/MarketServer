using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace Dal
{
    public class SqlQuery
    {
        public delegate void SetDataReader_delegate(SqlDataReader reader);
        public delegate object SetResulrDataReader_delegate(SqlDataReader reader);
        public static void RunCommand(string sqlQuery, SetDataReader_delegate func)
        {
            //string connectionString = ConfigurationManager.AppSettings["xnesData"];
            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=marketData;Data Source=DESKTOP-IUUO58L\SQLEXPRESS";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string queryString = sqlQuery;

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        func(reader);
                    }
                }

            }

        }

        public static object RunCommandResult(string sqlQuery, SetResulrDataReader_delegate func)
        {
            object ret = null;
            string connectionString = ConfigurationManager.AppSettings["xnesData"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string queryString = sqlQuery;

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ret = func(reader);
                    }
                }

            }

            return ret;
        }


    }
}
