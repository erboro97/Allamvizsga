using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Modeler.Models.SqlRepository
{
    public class Repository : DbContext
    {
        public DbSet<Client_Survey> Surveys { get; set; }
        public DbSet<User> Users { get; set; }
        public void runSqlNonQuery(string query)
        {
            string connection = "Data Source=DESKTOP-I76SIU9\\MSSQLSERVERBORO;Initial Catalog=Modeler;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            using (SqlConnection con = new SqlConnection(connection))
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
        public DataTable runSql(string sql)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string connectionString = "Data Source=DESKTOP-I76SIU9\\MSSQLSERVERBORO;Initial Catalog=Modeler;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
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