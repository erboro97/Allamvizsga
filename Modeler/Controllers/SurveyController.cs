using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modeler.Models;
using Modeler.Models.DataModels;
using Modeler.Models.SqlRepository;

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
        public ActionResult HeartSurvey(DoctorSurveyModel model)
        {
            Client_Survey clientSurvey = new Client_Survey();
            clientSurvey = model.formatToDatabaseStructure(Session["userID"].ToString().Trim());
            clientSurvey.v = -1;
            Query query = new Query();
            query.insertClientSurveyTable(clientSurvey);
            return RedirectToAction("RedirectUserType", "Chart");

        }
        [HttpGet]
        public ActionResult DoctorSurvey()
        {
            return View("DoctorSurvey");
        }

        [HttpPost]
        public ActionResult DoctorSurvey(DoctorSurveyModel model)
        {

            Client_Survey clientSurvey = new Client_Survey();
            clientSurvey = model.formatToDatabaseStructure(Session["userID"].ToString().Trim());
            Query query = new Query();
            query.insertClientSurveyTable(clientSurvey);
            return RedirectToAction("RedirectUserType", "Chart");
        }

        [HttpPost]
        public ActionResult FromFrontEnd(List<DataFromJavascript> data)
        {

            return Redirect("/");
        }

   
    }
}