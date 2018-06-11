using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team3CAS.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}