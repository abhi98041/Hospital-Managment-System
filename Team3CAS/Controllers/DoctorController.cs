using ClinicalELDAL.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team3CAS.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        ClinicalELDAL.Repository.DrugRepository DrugRepo;
        ClinicalELDAL.Repository.UserRepository UserRepo;
        public DoctorController()
        {

            DrugRepo = new ClinicalELDAL.Repository.DrugRepository();
            UserRepo = new ClinicalELDAL.Repository.UserRepository();

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDrug()
        {
            List<ClinicalELDAL.EntityLayer.Drug> drugs = new List<ClinicalELDAL.EntityLayer.Drug>();
            drugs = DrugRepo.GetAllDrugs();
            return View(drugs);
        }

        public ActionResult AddToCart()
        {
            List<ClinicalELDAL.EntityLayer.OrderItem> orderitem = Session["OrderItem"] as List<OrderItem>;
            ClinicalELDAL.EntityLayer.OrderItem obj = new ClinicalELDAL.EntityLayer.OrderItem();
            obj.DrugID = Convert.ToInt32(Request.Form["DrugID"]);
            obj.Quantity = Convert.ToInt32(Request.Form["quantity"]);
            orderitem.Add(obj);
            Session["OrderItem"] = orderitem;
           

            return RedirectToAction("ViewDrug");
                }

        public ActionResult ViewCart()
        {
        List<ClinicalELDAL.EntityLayer.OrderItem>     orderitem = Session["OrderItem"] as List<OrderItem>;
            // Request.Form["quantity"] = obj.Quantity.ToString();



            List<ViewModels.CartViewModel> list = new List<ViewModels.CartViewModel>();
            foreach (var item in orderitem)
            {
                ViewModels.CartViewModel cvm = new ViewModels.CartViewModel();
                var drg = DrugRepo.GetSpecificDrug(item.DrugID);
                cvm.DrugID = drg.DrugID;
                cvm.Name = drg.Name;
                cvm.Description = drg.Description;
                cvm.Quantity = item.Quantity.Value;
                cvm.Price = drg.Price.Value;
                cvm.TotalCost = drg.Price.Value * item.Quantity.Value;
                list.Add(cvm);
            }

            Session["ViewCart"] = list;
            return View(list);
        }
        public ActionResult PlaceOrder()
        {
            DrugRepo.AddOrder(Session["OrderItem"] as List<OrderItem>,Convert.ToInt32( Session["UserID"]));

            return View();
        }

        public ActionResult ViewPatient()
        {
            List<ClinicalELDAL.EntityLayer.Appointment> users = new List<ClinicalELDAL.EntityLayer.Appointment>();
            users = UserRepo.GetSpecificPatient(20);
            return View(users);
        }
    }
}