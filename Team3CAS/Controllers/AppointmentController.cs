using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team3CAS.Controllers
{
    public class AppointmentController : Controller
    {
        ClinicalELDAL.Repository.AppointmentRepository appRepo;
        public void AppointementController()
        {

        }
        public ActionResult Index()
        {
            List<ClinicalELDAL.EntityLayer.Appointment> appointements;
            int txtSearch = Convert.ToInt32(Request.Form["txtSearch"]);

            if (txtSearch < 0)
            {
                appointements = appRepo.GetActiveAppointments();
                return View(appointements);
            }
            else
            {
                appointements = appRepo.SearchAppointments(txtSearch);
                return View(appointements);
            }
        }
        public ActionResult SearchAppointments()
        {
            List<ClinicalELDAL.EntityLayer.Appointment> appointments = new List<ClinicalELDAL.EntityLayer.Appointment>();
            string txtSearch = Request.Form["txtSearch"];
            appointments = appRepo.SearchAppointments(Convert.ToInt32(txtSearch));
            return View(appointments);
        }

        public ActionResult ViewAppointments()
        {
            appRepo = new ClinicalELDAL.Repository.AppointmentRepository();
            List<ClinicalELDAL.EntityLayer.Appointment> appointments = new List<ClinicalELDAL.EntityLayer.Appointment>();
            appointments = appRepo.GetActiveAppointments();
            return View(appointments);
        }

        public ActionResult ViewSelectedAppointment()
        {
            appRepo = new ClinicalELDAL.Repository.AppointmentRepository();
            int AppointmentID = Convert.ToInt32(Request.QueryString["appid"]);
            List<ClinicalELDAL.EntityLayer.Appointment> appointments = new List<ClinicalELDAL.EntityLayer.Appointment>();
            appointments = appRepo.GetSpecificAppointments(AppointmentID);
            return View(appointments);
        }
        public ActionResult ViewApprovedAppointment()
        {
            appRepo = new ClinicalELDAL.Repository.AppointmentRepository();
            int AppointmentID = Convert.ToInt32(Request.QueryString["appid"]);
            bool result = appRepo.GetApprovedAppointments(AppointmentID);
            return RedirectToAction("ViewAppointments");
        }
        public ActionResult ViewDeniedAppointment()
        {
            appRepo = new ClinicalELDAL.Repository.AppointmentRepository();
            int AppointmentID = Convert.ToInt32(Request.QueryString["appid"]);
            bool result = appRepo.GetDeniedAppointments(AppointmentID);
            return View("ViewAppointments");
        }
    }
}