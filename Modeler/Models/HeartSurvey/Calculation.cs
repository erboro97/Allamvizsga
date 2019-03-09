using Modeler.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.HeartSurvey
{
    public class Calculation
    {
        List<DataFromJavascript> scoresPerSymptoms=new List<DataFromJavascript>();
        HeartSurveyModel answersRespondent;
        public Calculation (List<DataFromJavascript> dataFromJavascripts, HeartSurveyModel heartSurveyModel)
        {
            scoresPerSymptoms = dataFromJavascripts;
            answersRespondent = heartSurveyModel;

        }

      
    }
}