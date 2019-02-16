using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class surveyController : ApiController
    {

       
        [HttpGet]
        public int heartSurvey()
        {
            return 1;
        }

        [HttpGet]
        public int heartSurvey1(int i)
        {
            return 1;
        }

    }
}
