using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SqlRepository
    {
        public static void runSqlNonQuery (string query)
        {
            string connection = ConfigurationManager.ConnectionStrings["ModelerEntities"].ConnectionString;
            using (SqlConnection con= new SqlConnection(connection))
            {
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }

                con.Close();
            }
        }
        public static DataTable runSql(string sql)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string connectionString ="Data Source=DESKTOP-I76SIU9\\MSSQLSERVERBORO;Initial Catalog=Modeler;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
                using (var connection = new SqlConnection(connectionString))
                {
                    if (connection != null && connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        SqlDataAdapter com = new SqlDataAdapter(sql, connection);
                        com.SelectCommand.CommandTimeout = 600000;
                        

                        com.Fill(dataTable);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return dataTable;
        }

        
    }
}