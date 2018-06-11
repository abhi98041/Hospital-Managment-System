using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Team3CAS.ViewModels
{
    public class MessageViewModel
    {
        public List<ClinicalELDAL.EntityLayer.User> users;
        ClinicalELDAL.Repository.MessageRepository msgRepository = null;
        public MessageViewModel()
        {
            msgRepository = new ClinicalELDAL.Repository.MessageRepository();
        }

        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public int RecieverID { get; set; }
        [Required(ErrorMessage ="Message is required")]
        public string Body { get; set; }
        
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public string Status { get; set; }
    }
}