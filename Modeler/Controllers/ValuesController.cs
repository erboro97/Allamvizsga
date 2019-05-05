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


        // Doctor survey's method
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


        [HttpGet]
        public object getLambdaValues(int id)
        {
            Query query = new Query();
            var userLambdaValues = query.lambdaUserValues(id.ToString());
            var obj = new ExpandoObject() as IDictionary<string, Object>;
            obj.Add("lambda", userLambdaValues);
            return obj;

        }

        [HttpGet]
        public object getHRValues(int id)
        {
            Query query = new Query();
            List<int> HRCountValues = new List<int>();
            HRCountValues.Add(query.hrNormalVaues(id.ToString()));
            HRCountValues.Add(query.hrHighVaues(id.ToString()));
            HRCountValues.Add(query.hrLowVaues(id.ToString()));

            var obj = new ExpandoObject() as IDictionary<string, Object>;
            obj.Add("hrs", HRCountValues);
            return obj;
        }
      


    }
}
