using Modeler.Models;
using Modeler.Models.DataModels;
using Modeler.Models.RungeKutta;
using Modeler.Models.SqlRepository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;


namespace Api.Controllers
{
    public class ValuesController : ApiController
    {
       
        private DifferentialEquestion dif = new DifferentialEquestion();
    
        [HttpGet()]
        public object getValues()
        {
            Query query = new Query();
            var userAnswers = query.listUserData("1");
            //List<double[]> results = new List<double[]>();
            //RungeKuttaV2 rungeKuttav = new RungeKuttaV2();
            //results=rungeKuttav.solve();
            //List<double> r = new List<double>();
            //List<double> t = new List<double>();
            
            //for (int j= 0; j < 100; j++)
            //{
            //    r.Add(results[j][0]);
            //    t.Add(j);
            //}
            
            dynamic obj = new ExpandoObject();
            int i = 0;
            string index;
            
            RungeKutta rungeKutta = new RungeKutta("female", 0.4, 90, 3);
            rungeKutta.solve();
            List<double> v = new List<double>();
            List<double> HR = new List<double>();
            v = rungeKutta.getvResults();
            HR = rungeKutta.getHRResults();
            obj.t = rungeKutta.getTResults();
            obj.x = rungeKutta.getHRResults() ;
            
           // obj.x = rungeKutta.getHRResults();
            //obj.y = rungeKutta.getHRResults();

            //foreach (var userAnswer in userAnswers)
            //{
            //    RungeKutta rungeKutta = new RungeKutta(userAnswer.gender, userAnswer.lambda, userAnswer.HR, userAnswer.v);
            //    rungeKutta.solve();
            //    index = i.ToString();
            //    i++;
            //    obj. = rungeKutta.getTResults();

            //    index = i.ToString();
            //    obj.index = rungeKutta.getYResults();

            //}
            
            
       
            return obj;
        }

        // POST api/values
        public void Post([FromBody]OdeModel value)
        {
            dif.getResults().Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]OdeModel value)
        {
            dif.getResults()[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            dif.getResults().RemoveAt(id);
        }
    }
}
