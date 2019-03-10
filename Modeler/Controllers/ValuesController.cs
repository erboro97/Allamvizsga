using Modeler.Models;
using Modeler.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            RungeKutta rungeKutta = new RungeKutta();
            //rungeKutta.Initialize();
            //rungeKutta.RungeKuttaMethod();
            rungeKutta.solve();
            dynamic obj = new ExpandoObject();
            obj.x = rungeKutta.getXResults();
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
