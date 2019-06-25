using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modeler.Models.DataModels
{
    public class HeartScore
    {
        [Required(ErrorMessage = "This field is required.")]
        public int history { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int ekg { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int age { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int riskFactors { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int initialTroponin { get; set; }
        public int exercise { get; set; }

        public double calculateScore()
        {
            double sum = (history + ekg + age + riskFactors + initialTroponin + exercise);
            double lambda;
            if (sum == 12)
            {
                lambda = 0.1;
            }
            else
            { 
                lambda = (double)1-sum / 12;
            }
            return lambda;
        }
        
    }

}