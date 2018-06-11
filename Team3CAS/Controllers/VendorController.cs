using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team3CAS.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        ClinicalELDAL.Repository.OrderRepository OrderRepo;
        public VendorController()
        {            
            OrderRepo = new ClinicalELDAL.Repository.OrderRepository();

        }

        public ActionResult Index()
        {
            List<ClinicalELDAL.EntityLayer.Order> orders = new List<ClinicalELDAL.EntityLayer.Order>();
            orders = OrderRepo.GetActiveOrder();
            return View(orders);
        }
        public ActionResult ViewOrder()
        {
            int orderid =Convert.ToInt32( Request.QueryString["oid"]);
            List<ClinicalELDAL.EntityLayer.OrderItem> orders = new List<ClinicalELDAL.EntityLayer.OrderItem>();
            orders = OrderRepo.GetOrderItems(orderid);
            return View(orders);
        }

        public ActionResult ApproveOrder()
        {
            int orderid = Convert.ToInt32(Request.QueryString["oid"]);           
            bool status = OrderRepo.ApproveOrder(orderid);
            return RedirectToAction("ViewOrder");
        }
    }
}