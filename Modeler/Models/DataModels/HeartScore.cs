﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.DataModels
{
    public class HeartScore
    {
        public int history { get; set; }
        public int ekg { get; set; }
        public int age { get; set; }
        public int riskFactors { get; set; }
        public int initialTroponin { get; set; }

        public double calculateScore()
        {
            return (double)(history + ekg + age + riskFactors + initialTroponin)/10.0;
        }
        
    }

}