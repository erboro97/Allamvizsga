using DataAcces.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class DataAccesSettings
    {
        public static string ConnectionString
        {
            get
            {
                return Settings.Default.Conn;
            }
        }
    }
}
