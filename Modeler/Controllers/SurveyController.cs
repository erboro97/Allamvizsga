using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Modeler.Models;
using Modeler.Models.DataModels;
using Modeler.Models.SqlRepository;

namespace Modeler.Controllers
{

    public class SurveyController : Controller
    {
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
            if (ModelState.IsValid)
            {
                Client_Survey clientSurvey = new Client_Survey();
                clientSurvey = model.formatToDatabaseStructure(Session["userID"].ToString().Trim());
                Query query = new Query();
                query.insertClientSurveyTable(clientSurvey);
                return RedirectToAction("RedirectUserType", new RouteValueDictionary( new { controller = "Chart", action = "Main", userId = model.clientId}));
            }
            return View("DoctorSurvey", model);
        }

        [HttpPost]
        public ActionResult FromFrontEnd(List<DataFromJavascript> data)
        {

            return Redirect("/");
        }

        [HttpGet]
        public ActionResult getPatients()
        {
            Query query = new Query();
            var patients = query.getPatients();
            return Json(patients, JsonRequestBehavior.AllowGet);
        }
    }
}