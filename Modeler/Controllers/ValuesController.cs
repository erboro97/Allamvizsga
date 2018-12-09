using Modeler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        private DifferentialEquestion dif = new DifferentialEquestion();
        // GET api/values
        [HttpGet]
        public IEnumerable<OdeModel> getValues()
        {
            return dif.getResults();
        }

        //// GET api/values/5
        //[HttpGet]
        //public OdeModel Get(int id)
        //{
        //    return dif.getResults()[id];
        //}

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
