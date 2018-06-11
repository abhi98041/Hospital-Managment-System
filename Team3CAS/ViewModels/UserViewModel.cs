using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team3CAS.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles = new List<Models.Role>
            {
                new Models.Role{RoleID=0,Name="Select a role"},
                new Models.Role{RoleID=1,Name="Doctor"},
                new Models.Role{RoleID=2,Name="Patient"},
                new Models.Role{RoleID=3,Name="Vendor"},
                new Models.Role{RoleID=4,Name="Receptionist"},
            };
        }

        public int UserID { get; set; }
        [Required(ErrorMessage = "MedicareID is required")]
        public string MedicareId { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [StringLength(50, ErrorMessage = "Name should be above 3 chars and with in 50 chars", MinimumLength = 3)]
        [MaxLength(50, ErrorMessage = "Name should be within 50 char")]
        public string Name { get; set; }
        [Required(ErrorMessage = "RoleID is required")]
        public int RoleID { get; set; }
        // [Range(typeof(byte), "1", "3", ErrorMessage = "Userstatus out of range")]
        public byte UserStatus { get; set; }
        public List<Team3CAS.Models.Role> Roles { get; set; }
        public string RoleName { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }


    }
}
