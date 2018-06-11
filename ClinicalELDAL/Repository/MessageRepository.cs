using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalELDAL.Repository
{
    public class MessageRepository
    {
        protected ClinicalELDAL.EntityLayer.Team3CASEntities1 mycontext;
        public MessageRepository()
        {
            mycontext = new EntityLayer.Team3CASEntities1();
        }

        public bool AddMessage(EntityLayer.Message apt)
        {
            mycontext.Messages.Add(apt);
            int result = mycontext.SaveChanges();
            return result > 0;
        }

        public List<EntityLayer.Message> GetMessage(int userID)
        {
            int userid = userID;
            IEnumerable<ClinicalELDAL.EntityLayer.Message> query = from msg in mycontext.Messages.Include("User1").Include("User")
                                                                   where msg.SenderID == userid || msg.RecieverID == userid
                                                                   select msg;
            return query.ToList();
        }


    }
}
