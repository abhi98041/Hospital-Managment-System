using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team3CAS.Models
{
    public class Appointment
        {
            public int AppointmentID { get; set; }
            public int PatientUserID { get; set; }
            public int DoctorUserID { get; set; }
            public string Status { get; set; }
            public DateTime Date { get; set; }

        }
    }
