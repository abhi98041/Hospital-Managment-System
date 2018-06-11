using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team3CAS.Models
{
    public class Message
    {
        public int SenderID { get; set; }
        public int RecieverID { get; set; }
        public string Body { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public string Status { get; set; }
    }
}