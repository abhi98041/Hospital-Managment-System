using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team3CAS.Controllers
{
    public class BookController : Controller
    {
        ClinicalELDAL.Repository.PatientRepository prt;
        ClinicalELDAL.Repository.ApprovedRepository apprp;
        ClinicalELDAL.Repository.MessageRepository msgrp;

        // GET: Book
        public ActionResult Index()
        {
            prt =new ClinicalELDAL.Repository.PatientRepository();
            List<ClinicalELDAL.EntityLayer.Appointment> apoints = prt.GetAppointments();
            return View(apoints);
        }


        public ActionResult Index2()
        {
            ViewModels.BookViewModel vp = new ViewModels.BookViewModel();
            return View(vp);
        }
     

       [HttpPost]
        public ActionResult Index2(ViewModels.BookViewModel apt)
        {
            ClinicalELDAL.EntityLayer.Appointment appointment = new ClinicalELDAL.EntityLayer.Appointment();
            prt = new ClinicalELDAL.Repository.PatientRepository();
            if (ModelState.IsValid)
            {
                appointment.PatientUserID = Convert.ToInt32(Session["UserID"]);
                appointment.DoctorUserID = apt.DoctorUserID;
                appointment.Date = apt.Date;
                appointment.Status = "inactive";
                appointment.Time = apt.Time;
                bool b = prt.AddApppointment(appointment);
                if(b==true)
                {
                    return RedirectToAction("Index");
                }
                else
                return RedirectToAction("AddAppointment");
            }
            ViewModels.BookViewModel aptobj = new ViewModels.BookViewModel();
            return View(aptobj);
        }

        public ActionResult Approvedview()
        {
                
            apprp = new ClinicalELDAL.Repository.ApprovedRepository();
            List<ClinicalELDAL.EntityLayer.Appointment> apoint = apprp.GetApprovedAppointments();
            return View(apoint);
        }

        public ActionResult Messageview()
        {
            string docid = Request.QueryString["docid"];
            ViewBag.DoctorID = docid;
            ViewModels.MessageViewModel mvm = new ViewModels.MessageViewModel();
            mvm.RecieverID =Convert.ToInt32( docid);
            return View(mvm);
        }
        [HttpPost]
        public ActionResult Messageview(ViewModels.MessageViewModel msgvm)
        {
            ClinicalELDAL.EntityLayer.Message message = new ClinicalELDAL.EntityLayer.Message();
            msgrp = new ClinicalELDAL.Repository.MessageRepository();
            if(ModelState.IsValid)
            {
                message.SenderID = Convert.ToInt32(Session["UserID"]);
                message.RecieverID =msgvm.RecieverID;
                message.Body = msgvm.Body;
                message.Date = msgvm.Date;
                message.Time = msgvm.Time;
                message.Status = "unread";
                bool b = msgrp.AddMessage(message);
                if (b == true)
                {
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("Messageview");
            }

            ViewModels.MessageViewModel msgvmobj = new ViewModels.MessageViewModel();
            return View(msgvmobj);
        }
        public ActionResult ViewMsgTable()
        {
            msgrp = new ClinicalELDAL.Repository.MessageRepository();
            List<ClinicalELDAL.EntityLayer.Message> messages = msgrp.GetMessage(Convert.ToInt32(Session["UserID"]));
            return View(messages);
        }
    }
}