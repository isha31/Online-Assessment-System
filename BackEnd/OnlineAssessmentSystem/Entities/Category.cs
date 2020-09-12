using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        [Key]
        [DisplayName("Category ID")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Please enter category name.")]
        [DisplayName("Category Name")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter only aplhabets in category name field")]
        [StringLength(20, MinimumLength = 3)]
        public string CategoryName { get; set; }

        public virtual ICollection<SubCategory> SubCategory { get; set; }

        public Category()
        {

        }
        public Category(int a,string b)
        {
            this.CategoryID = a;
            this.CategoryName = b;
        }
    }
}
