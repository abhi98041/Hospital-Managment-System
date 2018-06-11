using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team3CAS.Models
{
    public class Approvedaptmt
    {
        public DateTime Date { get; set; }
        public int DoctorUserID { get; set; }
        public String Status { get; set; }
    }
}