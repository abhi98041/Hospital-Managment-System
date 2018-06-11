using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalELDAL.Repository
{
    public class AppointmentRepository : ClinicalELDAL.Repository.BaseRepository
    {
        public List<EntityLayer.Appointment> GetActiveAppointments()
        {
            IEnumerable<EntityLayer.Appointment> query = from appointment in mycontext.Appointments.Include("User")

                                                         select appointment;

            return query.ToList();
        }

        public List<EntityLayer.Appointment> GetSpecificAppointments(int appid)
        {
            IEnumerable<EntityLayer.Appointment> query = from appointment in mycontext.Appointments.Include("User")
                                                         where appointment.AppointmentID == appid
                                                         select appointment;

            return query.ToList();
        }



        public List<EntityLayer.Appointment> SearchAppointments(int AppointmentID)
        {
            IEnumerable<EntityLayer.Appointment> query = from app in mycontext.Appointments
                                                         orderby app.AppointmentID ascending
                                                         select app;
            return query.ToList();
        }
        public string GetDoctorNameById(int id)
        {
            var query = from d in mycontext.Doctors.Include("User")
                        where d.UserID == id
                        select d.User.Name;
            return query.SingleOrDefault();

        }
        public bool GetApprovedAppointments(int appid)
        {
            EntityLayer.Appointment dbUser = (from u in mycontext.Appointments
                                              where u.AppointmentID == appid
                                              select u).SingleOrDefault();
            dbUser.Status = "Inactive";
            mycontext.Entry(dbUser).State = System.Data.Entity.EntityState.Modified;
            int result = mycontext.SaveChanges();
            return result > 0;
        }
        public bool GetDeniedAppointments(int appid)
        {
            EntityLayer.Appointment dbUser = (from u in mycontext.Appointments
                                              where u.AppointmentID == appid
                                              select u).SingleOrDefault();
            dbUser.Status = "active";
            mycontext.Entry(dbUser).State = System.Data.Entity.EntityState.Modified;
            int result = mycontext.SaveChanges();
            return result > 0;
        }
    }
}
