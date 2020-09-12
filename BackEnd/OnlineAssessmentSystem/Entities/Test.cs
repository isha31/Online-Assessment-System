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
    public class Test
    {
        [Key]
        public int TestID { get; set; }

        [Required(ErrorMessage = "Total questions is Required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numbers in total questions field")]
        [DisplayName("Total Questions")]
        public int TotalQuestions { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numbers in total marks field")]
        [Required(ErrorMessage = "Total marks is Required")]
        [DisplayName("Total marks")]
        public int TotalMarks { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Total duration is Required")]
        [DisplayName("Total duration")]
        public DateTime TotalDuration { get; set; }

        [ForeignKey(nameof(Topic))]
        public int TopicID { get; set; }

        [ForeignKey(nameof(DifficultyLevel))]
        public int DifficultyLevelID { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual DifficultyLevel DifficultyLevel { get; set; }

        public virtual ICollection<UserTest> UserTest { get; set; }


        public Test()
        {

        }

        public Test(int a,int b,int c,DateTime d,int e,int f)
        {
            this.TestID = a;
            this.TotalQuestions = b;
            this.TotalMarks = c;
            this.TotalDuration = d;
            this.TopicID = e;
            this.DifficultyLevelID = f;
        }
    }
}
