using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SqlRepository
    {
        protected string connection;
        public SqlRepository()
        {
            connection = System.Configuration.ConfigurationManager.ConnectionStrings["ModelerEntities"].ConnectionString;
        }
    }
}