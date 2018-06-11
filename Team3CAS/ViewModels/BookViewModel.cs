using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Team3CAS.ViewModels
{
    public class BookViewModel
    {
        public List<ClinicalELDAL.EntityLayer.User> users;
        ClinicalELDAL.Repository.PatientRepository userRepository = null;
        public BookViewModel()
        {
            userRepository = new ClinicalELDAL.Repository.PatientRepository();
            users = userRepository.GetDoctors();
        }
        //public int DoctorID { get; set; }
       
        public int AppointmentID { get; set; }
        [Required(ErrorMessage = "Patient ID is required")]
        public int PatientUserID { get; set; }
        [Required(ErrorMessage = "Doctor ID is required")]
        public int DoctorUserID { get; set; }
        [Required(ErrorMessage = "AppointmentDate is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "AppointmentTime is required")]
        public TimeSpan Time { get; set; }

        public string Status{ get; set; }
    }
}
