using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalELDAL.Repository
{
    public class PatientRepository
    {
        protected ClinicalELDAL.EntityLayer.Team3CASEntities1 mycontext;
        public PatientRepository()
        {
            mycontext = new EntityLayer.Team3CASEntities1();
        }

        public List<EntityLayer.Appointment> GetAppointments()
        {
            IEnumerable<ClinicalELDAL.EntityLayer.Appointment> query = from appoint in mycontext.Appointments.Include("User1") select appoint;
            return query.ToList();
        }

        public List<EntityLayer.User> GetDoctors()
        {
            IEnumerable<EntityLayer.User> query = from usr in mycontext.Users.Include("Role")
                                                  where usr.Status == "active" & usr.RoleID == 1
                                                  orderby usr.Name
                                                  ascending
                                                  select usr;
            return query.ToList();
        }

        public bool AddApppointment(EntityLayer.Appointment apt)
        {
            mycontext.Appointments.Add(apt);
            int result = mycontext.SaveChanges();
            return result > 0;
        }
    }
}

