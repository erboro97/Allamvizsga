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
        public ActionResult RedirectUserType()
        {
            string userType = Session["userType"].ToString().Trim();

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