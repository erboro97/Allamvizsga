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
        private HeartScore model;
        // GET: Survey
        [HttpGet]
        public ActionResult HeartSurvey()
        {
            ViewBag.ApiBaseUrl = Url.Content("~/");
            return View("HeartScore");
        }

        [HttpPost]
        public ActionResult HeartSurvey(HeartScore model)
        {
            //foreach()
            this.model = model;
            double lambda = model.calculateScore();
            Session["lambda"] = lambda;

            return Redirect("/");

            // return RedirectToAction("getValues", "Values", new {  lambda});

        }
        [HttpGet]
        public ActionResult DoctorSurvey()
        {
            return View("DoctorSurvey");
        }

        [HttpPost]
        public ActionResult DoctorSurvey(DoctorSurveyModel model)
        {
            model.getLambdaValueFromSurvey();
            return RedirectToAction("RedirectUserType", "Chart");
        }

        [HttpPost]
        public ActionResult FromFrontEnd(List<DataFromJavascript> data)
        {

            return Redirect("/");
        }
    }
}