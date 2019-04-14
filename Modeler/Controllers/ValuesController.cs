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
        [HttpGet]
        public object getValues(int id)
        {
            Query query = new Query();
            var userAnswers = query.listUserData(id.ToString());
          

            var obj = new ExpandoObject() as IDictionary<string, Object>;
            int i = 0;
            string index;

           
            obj.Add("size", userAnswers.Count);
            foreach (var userAnswer in userAnswers)
            {
                RungeKutta rungeKutta = new RungeKutta(userAnswer.gender, userAnswer.lambda, userAnswer.HR, userAnswer.v);
                rungeKutta.solve();
                index = i.ToString();
                i++;
                ODEResultModel results = new ODEResultModel(rungeKutta.getHRResults(), rungeKutta.getvResults(), rungeKutta.getTResults());
                
                obj.Add("r" + index, results);



            }



            return obj;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            dif.getResults().RemoveAt(id);
        }


    }
}
