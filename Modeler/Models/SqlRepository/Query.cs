using Modeler.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.SqlRepository
{
    public class Query: QueryStrings
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
                
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

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

        public double lastLambdaValue (string userId)
        {
            var lastLambda = db.Surveys.Where(s => s.inserted_dtm == db.Surveys.Max(m => m.inserted_dtm)).Select(d => d.lambda).First();
            return lastLambda;
        }

        public List<PatientDataModel> getPatients()
        {
            var patients = db.Users.Where(s => s.UserType == "patient").Select(d => new PatientDataModel {patientId=d.UserID, patientName=d.UserName }).ToList();
            return patients;
        }

        public int hrNormalVaues(string userId)
        {
            var hrs = db.Surveys.OrderBy(e => e.inserted_dtm).Where(s => s.user_id == userId).Count(d => d.HR > 60 && d.HR < 100);
            return hrs;
        }
        public int hrLowVaues(string userId)
        {
            var hrs = db.Surveys.OrderBy(e => e.inserted_dtm).Where(s => s.user_id == userId).Count(d => d.HR < 60);
            return hrs;
        }
        public int hrHighVaues(string userId)
        {
            var hrs = db.Surveys.OrderBy(e => e.inserted_dtm).Where(s => s.user_id == userId).Count(d => d.HR < 60);
            return hrs;
        }

        public Client_Survey lastValuesPerUser (string userId)
        {
            var surveyData = db.Surveys.Where(d => d.user_id == userId && d.v >= 0
            && d.inserted_dtm == db.Surveys.Where(l => l.user_id==userId && l.v>=0).Max(m => m.inserted_dtm )).First();
            return surveyData;
        }

        public void changeV (string userId, int v)
        {
            changeVQuery = changeVQuery.Replace("_DATE_", DateTime.Now.ToString());
            changeVQuery = changeVQuery.Replace("_USERID_", userId);
            changeVQuery = changeVQuery.Replace("_SPEED_", v.ToString());
            try
            {
                db.runSqlNonQuery(changeVQuery);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}