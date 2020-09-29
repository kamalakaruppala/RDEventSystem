using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RDEvent.Models
{
    public class UserLogin
    {
        [Display(Name ="Email Id:")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Email Id Required")]
        public string EmailID { get; set; }
        [Display(Name = "Password:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
       
        public bool RememberMe { get; set; }
    }
}