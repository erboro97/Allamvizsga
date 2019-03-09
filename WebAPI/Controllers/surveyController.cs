using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class surveyController : ApiController
    {

       
        [HttpGet]
        public DataTable heartSurvey()
        {
            DataTable result = SqlRepository.runSql(Queries.getSymptomScores);
            return result;
        }

        [HttpGet]
        public int heartSurvey1(int i)
        {
            return 1;
        }

    }
}
