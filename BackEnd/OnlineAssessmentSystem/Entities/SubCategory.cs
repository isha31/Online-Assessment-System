using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SubCategory
    {
        [Key]
        [DisplayName("Sub-Category ID")]
        public int SubCategoryID { get; set; }

        [Required(ErrorMessage = "Please enter subcategory name.")]
        [DisplayName("Sub-Category Name")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter only aplhabets in subcategory name field")]
        [StringLength(20, MinimumLength = 3)]
        public string SubCategoryName { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Topic> Topic { get; set; }

        public SubCategory()
        {

        }

        public SubCategory(int a,string b,int c)
        {
            this.SubCategoryID = a;
            this.SubCategoryName = b;
            this.CategoryID = c;
        }

    }
}
