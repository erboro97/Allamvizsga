using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.DataModels
{
    public class DoctorSurveyModel
    {
        public string gender { get; set; }
        public double hr { get; set; }
        public HeartScore lambdaSurvey { get; set; }
        public double? lambdaValue { get; set; }
        public double v { get; set; }

        public void getLambdaValueFromSurvey()
        {
            if (lambdaValue == null)
            {
                lambdaValue = lambdaSurvey.calculateScore();
            }
        }

        public Client_Survey formatToDatabaseStructure (string userId)
        {
            getLambdaValueFromSurvey();
            Client_Survey surveyData = new Client_Survey()
            {
                gender=this.gender,
                HR=this.hr,
                lambda=lambdaValue ?? default(double),
                user_id=userId,
                v=this.v,
                inserted_dtm= DateTime.Now
        };
            return surveyData;
        }

    }
}