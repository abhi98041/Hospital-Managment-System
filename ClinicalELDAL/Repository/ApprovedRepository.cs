using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalELDAL.Repository
{
    public class ApprovedRepository
    {
        protected ClinicalELDAL.EntityLayer.Team3CASEntities1 mycontent;
        public ApprovedRepository()
        {
            mycontent = new EntityLayer.Team3CASEntities1();
        }

        public List<EntityLayer.Appointment> GetApprovedAppointments()
        {
            IEnumerable<ClinicalELDAL.EntityLayer.Appointment> query = from appoint in mycontent.Appointments.Include("User1")
                                                                       where appoint.Status == "active"
                                                                       orderby appoint.Date
                                                                       select appoint;

            return query.ToList();
        }
    }
}
