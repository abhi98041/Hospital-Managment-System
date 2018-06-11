using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team3CAS.Controllers
{
    public class DrugController : Controller
    {
        // GET: Drug
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewDrug()
        {
            ViewModels.DrugViewModel vm = new ViewModels.DrugViewModel();
            return View(vm);
        }
        [HttpPost]
        public ActionResult NewDrug(ViewModels.DrugViewModel dvm)
        {

            if (ModelState.IsValid)
            {
                ClinicalELDAL.Repository.DrugRepository drug = new ClinicalELDAL.Repository.DrugRepository();
                ClinicalELDAL.EntityLayer.Drug drg = new ClinicalELDAL.EntityLayer.Drug();
                drg.DrugID = dvm.DrugID;
                drg.Name = dvm.Name;
                drg.Composition = dvm.Composition;
                drg.Quantity = dvm.Quantity;
                drg.Description = dvm.Description;
                drg.Price = Convert.ToDecimal(dvm.Price);
                drug.AddDrug(drg);
                return RedirectToAction("Index");

            }

            ViewModels.DrugViewModel vm = new ViewModels.DrugViewModel();
            return View(vm);
        }
    }
}