using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.DataModels
{
    public class HeartSurveyModel
    {
        public string ekg { get; set; }
        public string age { get; set; }
        public string riskFactor { get; set; }
        public string initialTroponin { get; set; }
        public string cad { get; set; }
        public string painExercice { get; set; }
        public string painPalpation { get; set; }
        public string painCardiac { get; set; }
    }
}