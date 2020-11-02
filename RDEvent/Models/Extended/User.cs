using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RDEvent.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }
    }
    public class UserMetadata
    {
        [Display(Name = "Email:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id is Required")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        [Display(Name = "Password:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 Characters Required")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }


    }

}
