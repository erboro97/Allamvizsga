using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.RungeKutta
{
    public class Parameters
    {
        public double v { get; set; }
        public double HR { get; set; }

        public Parameters(double v, double HR)
        {
            this.HR = HR;
            this.v = v;
        }

        public Parameters() { }
    }
}