using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team3CAS.Controllers
{
    public class LoginController : Controller
    {
        ClinicalELDAL.Repository.UserRepository userRepo;
        public LoginController()
        {
            userRepo = new ClinicalELDAL.Repository.UserRepository();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Team3CAS.Models.LoginUser uvm)
        {
            ClinicalELDAL.EntityLayer.User u = userRepo.CheckUser(uvm.UserID, uvm.Password);
            if (u == null)
            {
                Session["RoleID"] = -1;
                return View(uvm);
            }
            else
            {
                Session["UserID"] = u.UserID;
                Session["Name"] = u.Name;
                Session["RoleID"] = u.RoleID;

                if (Convert.ToInt32(Session["RoleID"]) == 1)
                {
                    return RedirectToAction("ViewPatient", "Doctor");
                }
                else if (Convert.ToInt32(Session["RoleID"]) == 2)
                {
                    return RedirectToAction("Index", "Book");
                }
                else if (Convert.ToInt32(Session["RoleID"]) == 3)
                {
                    return RedirectToAction("NewDrug", "Drug");
                }
                else if (Convert.ToInt32(Session["RoleID"]) == 4)
                {
                    return RedirectToAction("NewUser", "User");
                }
                return RedirectToAction("Index", "Anonymous");
            }

        }
        public ActionResult ViewUserType()
        {
            ViewBag.mo = TempData["RoleID"];
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Anonymous");
        }

    }
}