using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

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

        [Required(ErrorMessage = "Email Address is Required")]
        [DisplayName("Email ID")]
        [MaxLength(50)]
        [EmailAddress]
        public string EmailID { get; set; }

       
        [Required]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Enter Contact number")]
        [DisplayName("Contact Number")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numbers in ContactNo field")]
        [Range(6000000000, 9999999999)]
        public long ContactNo { get; set; }

        [Required(ErrorMessage ="Please enter date of birth.")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [DisplayName("Country")]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter only aplhabets in country field")]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(12), MinLength(6)]
        public string Password { get; set; }

        public virtual ICollection<UserTest> UserTest { get; set; }
    }

    public enum Gender
    {
        Select, Male, Female, Other
    }
    
}
