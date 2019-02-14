using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modeler.Models.DataModels;

namespace Modeler.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        [HttpGet]
        public ActionResult HeartSurvey()
        {
            return View("HeartSurvey");
        }

        [HttpPost]
        public ActionResult HeartSurvey(HeartSurveyModel model)
        {

            return Redirect("/");
        }
    }
}