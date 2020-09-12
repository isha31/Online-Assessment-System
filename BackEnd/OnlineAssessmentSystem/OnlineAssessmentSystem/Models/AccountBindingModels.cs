using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel;
using Entities;

namespace OnlineAssessmentSystem.Models
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "First Name is Required")]
        [DisplayName("First Name")]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter only aplhabets in first name field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [DisplayName("Last Name")]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter only aplhabets in last name field")]

        public string LastName { get; set; }


        [Required]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Enter Contact number")]
        [DisplayName("Contact Number")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numbers in ContactNo field")]
        [Range(6000000000, 9999999999)]
        public long ContactNo { get; set; }

        [Required(ErrorMessage = "Please enter date of birth.")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [DisplayName("Country")]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter only aplhabets in country field")]
        public string Country { get; set; }

       
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
