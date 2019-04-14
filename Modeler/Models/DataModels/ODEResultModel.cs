using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.DataModels
{
    public class ODEResultModel
    {
        public List<double> hr { get; set; }
        public List<double> v { get; set; }
        public List<double> t { get; set; }

        public ODEResultModel(List<double> hr, List<double> v, List<double> t)
        {
            this.hr = new List<double>();
            this.v = new List<double>();
            this.t = new List<double>();
            this.hr = hr;
            this.v = v;
            this.t = t;
        }
    }
}