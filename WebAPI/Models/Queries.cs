using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Queries
    {
        public static string getSymptomScores {
            get {
                return "SELECT symptom_id, scores FROM[Modeler].[dbo].[Disease_Symptom_rel] where disease_id=1;";
            }
        }
    }
}