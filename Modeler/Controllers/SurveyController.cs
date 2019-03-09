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
        private HeartSurveyModel model;
        // GET: Survey
        [HttpGet]
        public ActionResult HeartSurvey()
        {
            ViewBag.ApiBaseUrl = Url.Content("~/");
            return View("HeartSurvey");
        }

        [HttpPost]
        public ActionResult HeartSurvey(HeartSurveyModel model)
        {
            this.model = model;
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult FromFrontEnd(List<DataFromJavascript> data)
        {

            return Redirect("/");
        }
    }
}