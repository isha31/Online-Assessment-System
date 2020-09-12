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
    public class Topic
    {
        [Key]
        [DisplayName("Topic ID")]
        public int TopicID { get; set; }

        [Required(ErrorMessage = "Please enter topic name.")]
        [DisplayName("Topic Name")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter only aplhabets in topic name field")]
        [StringLength(20, MinimumLength = 3)]
        public string TopicName { get; set; }

        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryID { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        public ICollection<QuestionBank> QuestionBank { get; set; }
        public ICollection<Test> Test { get; set; }

        public Topic()
        {

        }

        public Topic(int a,string b,int c)
        {
            this.TopicID = a;
            this.TopicName = b;
            this.SubCategoryID = c;
        }

    }
}
