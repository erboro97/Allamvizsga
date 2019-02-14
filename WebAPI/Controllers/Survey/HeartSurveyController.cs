using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAcces;
namespace WebAPI.Controllers.Survey
{
    public class HeartSurveyController : ApiController
    {
        public void Get()
        {
            using (ModelerEntities entities = new ModelerEntities())
            {
                //https://www.youtube.com/watch?v=nMGlaiNBbNU
            }

        }
    }
}
