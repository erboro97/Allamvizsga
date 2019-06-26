﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.DataModels
{
    public class DoctorSurveyModel
    {
        public string clientId { get; set; }
        public string gender { get; set; }
        public double hr { get; set; }
        public double pacemaker { get; set; }
        public HeartScore lambdaSurvey { get; set; }
        public double? lambdaValue { get; set; }
        public double v { get; set; }

        public void getLambdaValueFromSurvey()
        {
            if (lambdaValue == null)
            {
                lambdaValue = lambdaSurvey.calculateScore();
            }
            else
            {
                lambdaValue = 1 - lambdaValue;
            }
        }

        public Client_Survey formatToDatabaseStructure (string userId)
        {
            bool canChangeLambda = true;
            if (this.clientId is null)
            {
                canChangeLambda = false;
            }
            getLambdaValueFromSurvey();
            Client_Survey surveyData = new Client_Survey()
            {
                gender=this.gender,
                HR=this.hr,
                lambda=(pacemaker==1 && canChangeLambda)? 0.01 : lambdaValue ?? default(double),
                user_id= (this.clientId is null)? userId : this.clientId,
                v=this.v,
                inserted_dtm= DateTime.Now
        };
            return surveyData;
        }

    }
}