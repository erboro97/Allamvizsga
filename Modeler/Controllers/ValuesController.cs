using Modeler.Models;
using Modeler.Models.DataModels;
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
    
        [HttpGet]
        public object getValues()
        {
            Query query = new Query();
            var userAnswers = query.listUserData("1");
            double lambda;
            try
            {
                lambda = double.Parse(HttpContext.Current.Session["lambda"].ToString());
            }
            catch (Exception e)
            {
                lambda = 0.6;
            }
           
            RungeKutta rungeKutta = new RungeKutta("female", lambda, 83.2, 10);
            rungeKutta.solve();
            dynamic obj = new ExpandoObject();
            obj.x = rungeKutta.getTResults();
            obj.y = rungeKutta.getYResults();
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
