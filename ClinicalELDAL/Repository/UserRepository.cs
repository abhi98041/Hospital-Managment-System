using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalELDAL.Repository
{
    public class UserRepository : BaseRepository
    {
        public List<EntityLayer.Appointment> GetSpecificPatient(int docid)
        {
            IEnumerable<EntityLayer.Appointment> query = from patient in mycontext.Appointments.Include("User")
                                                         where patient.DoctorUserID == docid
                                                         select patient;
            return query.ToList();
        }

    
        public class BaseRepository
        {
            protected EntityLayer.Team3CASEntities1 mycontext;
            public BaseRepository()
            {
                mycontext = new EntityLayer.Team3CASEntities1();
            }
        }

       
        
            public EntityLayer.User CheckUser(string userid, string password)
            {
                EntityLayer.User dbuser = (from u in mycontext.Users
                                           where u.MedicareID == userid
                                           && u.Password == password
                                           select u).SingleOrDefault();
                return dbuser;
            }




            public List<EntityLayer.User> GetAllUsers()
            {
                IEnumerable<EntityLayer.User> query = from usr in mycontext.Users.Include("Role")

                                                      orderby usr.Name ascending
                                                      select usr;
                return query.ToList();
            }
            public List<EntityLayer.User> SearchUsers(string name)
            {
                IEnumerable<EntityLayer.User> query = from usr in mycontext.Users.Include("Role")
                                                      where usr.Status == "active" &&
                                                      usr.Name.ToLower().StartsWith(name.ToLower())
                                                      orderby usr.Name ascending
                                                      select usr;
                return query.ToList();
            }

            public bool AddUser(EntityLayer.User usr)
            {
                mycontext.Users.Add(usr);
                int result = mycontext.SaveChanges();
                return result > 0;
            }

            public bool UpdateUser(EntityLayer.User usr)
            {
                EntityLayer.User dbUser = (from u in mycontext.Users
                                           where u.UserID == usr.UserID
                                           select u).SingleOrDefault();
                mycontext.Entry(dbUser).State = System.Data.Entity.EntityState.Modified;
                int result = mycontext.SaveChanges();
                return result > 0;
            }
            public EntityLayer.User GetUserByID(string UserID)
            {
                int uid1 = Convert.ToInt32(UserID);
                EntityLayer.User dbUser = (from u in mycontext.Users
                                           where u.UserID == uid1
                                           select u).SingleOrDefault();
                return dbUser;

            }
            public bool EditUser(EntityLayer.User usr)
            {
                List<EntityLayer.User> user = new List<EntityLayer.User>();
                EntityLayer.User dbuser = (from u in mycontext.Users
                                           where u.UserID == usr.UserID
                                           select u).SingleOrDefault();
                dbuser.Name = usr.Name;

                dbuser.Password = usr.Password;

                mycontext.Entry(dbuser).State = System.Data.Entity.EntityState.Modified;
                int result = mycontext.SaveChanges();
                return result > 0;
            }


    }
}

