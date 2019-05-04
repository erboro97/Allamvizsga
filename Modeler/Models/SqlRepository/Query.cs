using Modeler.Models.DataModels;
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
            var surveyData = db.Surveys.OrderBy(e => e.inserted_dtm).Where(d => d.user_id==userId && d.v>=0).ToList();
            return surveyData;
        }

        public List<double> lambdaUserValues (string userId)
        {
            var lambdas = db.Surveys.OrderBy(e => e.inserted_dtm).Where(s => s.user_id == userId).Select(d => d.lambda).ToList();
          
            return lambdas;
        }

        public List<PatientDataModel> getPatients()
        {
            var patients = db.Users.Where(s => s.UserType == "patient").Select(d => new PatientDataModel {patientId=d.UserID, patientName=d.UserName }).ToList();
            return patients;
        }
    }
}