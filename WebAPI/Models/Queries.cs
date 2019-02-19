using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Queries
    {
        public static string getAllDiseases {
            get {
                return "SELECT TOP (1000) [disease_id], [disease_name] FROM[Modeler].[dbo].[Disease]";
            }
        }
    }
}