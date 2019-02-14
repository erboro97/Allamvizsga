using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modeler.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        public ActionResult HeartSurvey()
        {
            return View("HeartSurvey");
        }
    }
}