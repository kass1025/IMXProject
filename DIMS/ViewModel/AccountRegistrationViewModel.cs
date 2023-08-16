using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.ViewModel
{
    public class AccountRegistrationViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public int LocationId { get; set; }
        public int ZLocationId { get; set; }
        public int CLocationId { get; set; }
        public int WLocationId { get; set; }
        public int LocationCode { get; set; }
        public string LocationName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Display(Name = "Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password doesnot much")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string RegistrationInValid { get; set; }
        [Required]
        //[RegularExpression(@"^(^\+251|^251|^0)?9\d{8}$")]
        public string PhoneNumber { get; set; }
    }
}
