using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.SqlRepository
{
    public class Query
    {
        private Repository db;

        public Query()
        {
            db = new Repository();
        }

        public List<Client_Survey> listSurveyData()
        {
            var surveyData = db.Surveys.ToList();
            return surveyData;
        }

        public bool insertClientSurveyTable(Client_Survey newRow)
        {
            try
            {
                db.Surveys.Add(newRow);
                db.SaveChanges();
                var surveyData = listSurveyData();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public List<Client_Survey> listUserData (string userId)
        {
            var surveyData = db.Surveys.Where(d => d.user_id==userId).ToList();
            return surveyData;
        }
    }
}