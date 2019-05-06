using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modeler.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        [HttpGet]
        public ActionResult RedirectUserType(string userId)
        {
            string userType = Session["userType"].ToString().Trim();
            if (userId == null)
            {
                ViewBag.UserId = Session["userID"].ToString().Trim();
            }
            else
            {
                ViewBag.UserId = userId.ToString();
            }
            switch (userType)
            {
                case "doctor":
                    return View("DoctorChartView");
                case "patient":
                    return View("PatientChartView");
            }

            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }

    }
}