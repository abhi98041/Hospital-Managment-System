using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team3CAS.Controllers
{
    public class AnonymousController : Controller
    {
        ClinicalELDAL.Repository.DrugRepository DrugRepo = new ClinicalELDAL.Repository.DrugRepository();
        public AnonymousController()
        {
            DrugRepo = new ClinicalELDAL.Repository.DrugRepository();
        }

        // GET: Anonymous
        public ActionResult Index()
        { 
            List<ClinicalELDAL.EntityLayer.Drug> drugs = new List<ClinicalELDAL.EntityLayer.Drug>();
            drugs = DrugRepo.GetAllDrugs();
            return View(drugs);
        }

        public ActionResult SearchDrug()
        {
            string drugname = Request.Form["txtsearch"];
            List<ClinicalELDAL.EntityLayer.Drug> drugs = new List<ClinicalELDAL.EntityLayer.Drug>();
            drugs = DrugRepo.GetSearchDrug(drugname);
            return View(drugs);
        }
    }
}