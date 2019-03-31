using Modeler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modeler.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Modeler.Models.User userModel)
        {
            using (ModelerEntities db = new ModelerEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password && x.UserType==userModel.UserType).FirstOrDefault();
                if (userDetails==null)
                {
                    userModel.LoginErrorMessage = "Wrong user name, password or client type.";
                    return View("Index", userModel);
                }
                else
                {
                    // itt beletehetem, ami meg kell
                    DifferentialEquestion dif = new DifferentialEquestion();
                    Session["userID"] = userDetails.UserID;
                    Session["userType"] = userDetails.UserType;
                    return RedirectToAction("RedirectUserType", "Chart");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}