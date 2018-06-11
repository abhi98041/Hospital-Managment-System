using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team3CAS.Controllers
{
    public class UserController : Controller
    {
        ClinicalELDAL.Repository.UserRepository userRepo;
        public UserController()
        {
            userRepo = new ClinicalELDAL.Repository.UserRepository();
        }
        public ActionResult Index()
        {
            List<ClinicalELDAL.EntityLayer.User> users;
            string txtSearch = Request.Form["txtSearch"];
            if (txtSearch == null)
                users = userRepo.GetAllUsers();
            //call getallusers if txtsearch is null
            //else
            //call searchusers(txtvalue)
            else
                users = userRepo.SearchUsers(txtSearch);
            return View(users);
        }

        public ActionResult NewUser()
        {
            ViewModels.UserViewModel vm = new ViewModels.UserViewModel();
            return View(vm);
        }
        [HttpPost]
        public ActionResult NewUser(ViewModels.UserViewModel uvm)
        {
            uvm.UserStatus = 1;
            if (ModelState.IsValid)
            {
                ClinicalELDAL.Repository.UserRepository user = new ClinicalELDAL.Repository.UserRepository();
                ClinicalELDAL.EntityLayer.User usr = new ClinicalELDAL.EntityLayer.User();
                usr.Name = uvm.Name;

                usr.UserID = uvm.UserID;
                usr.MedicareID = uvm.MedicareId;
                usr.Password = uvm.Password;
                usr.Name = uvm.Name;
                usr.RoleID = uvm.RoleID;
                usr.Sex = uvm.Sex;
                usr.Status = uvm.Status;
                user.AddUser(usr);
                return RedirectToAction("Index");

            }

            ViewModels.UserViewModel vm = new ViewModels.UserViewModel();
            return View(vm);
        }
        public ActionResult EditUser(string id)
        {
            ClinicalELDAL.Repository.UserRepository user = new ClinicalELDAL.Repository.UserRepository();
            ClinicalELDAL.EntityLayer.User usr = new ClinicalELDAL.EntityLayer.User();
            ViewModels.UserViewModel uvm = new ViewModels.UserViewModel();
            usr = user.GetUserByID((id));
            uvm.UserID = Convert.ToInt32(id);
            uvm.MedicareId = usr.MedicareID;
            uvm.UserID = usr.UserID;
            uvm.Password = usr.Password;
            uvm.Name = usr.Name;
            uvm.RoleID = usr.RoleID;
            uvm.Sex = usr.Sex;
            uvm.Status = usr.Status;

            return View(uvm);

        }
        [HttpPost]
        public ActionResult EditUser(ViewModels.UserViewModel uvm)
        {
            ClinicalELDAL.Repository.UserRepository user = new ClinicalELDAL.Repository.UserRepository();
            ClinicalELDAL.EntityLayer.User usr = new ClinicalELDAL.EntityLayer.User();
            usr.UserID = uvm.UserID;
            uvm.MedicareId = usr.MedicareID;
            usr.Password = uvm.Password;
            usr.Name = uvm.Name;
            uvm.RoleID = usr.RoleID;
            uvm.Sex = usr.Sex;
            uvm.Status = usr.Status;


            usr.Status = uvm.Status;
            if (user.EditUser(usr))
                return RedirectToAction("Index");
            return View(usr);
        }
    }
}