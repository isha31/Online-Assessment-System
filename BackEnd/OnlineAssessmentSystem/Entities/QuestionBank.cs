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
    public class QuestionBank
    {
        [Key]
        public int QuestionBankID { get; set; }

        [Required(ErrorMessage = "Please enter question.")]
        [DisplayName("Question")]
        [StringLength(50, MinimumLength = 3)]
        public string Question { get; set; }

        [DisplayName("Option 1")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter option 1.")]
        public string Option1 { get; set; }
        [DisplayName("Option 2")]
        [Required(ErrorMessage = "Please enter option 2.")]
        [StringLength(50, MinimumLength = 3)]
        public string Option2 { get; set; }
        [DisplayName("Option 3")]
        [Required(ErrorMessage = "Please enter option 3.")]
        [StringLength(50, MinimumLength = 3)]
        public string Option3 { get; set; }
        [DisplayName("Option 4")]
        [Required(ErrorMessage = "Please enter option 4.")]
        [StringLength(50, MinimumLength = 3)]
        public string Option4 { get; set; }
        [DisplayName("Answer")]
        [Required(ErrorMessage = "Please enter answer.")]
        [StringLength(50, MinimumLength = 3)]
        public string Answer { get; set; }

        [DisplayName("Marks")]
        [Required(ErrorMessage = "Please enter marks.")]
        [RegularExpression("^[0-9 ]+$", ErrorMessage = "Please enter only numbers in marks field")]

        public int Marks { get; set; }

        [ForeignKey(nameof(DifficultyLevel))]
        [Required(ErrorMessage = "Please enter difficulty level.")]
        public int DifficultyLevelID { get; set; }


        [ForeignKey(nameof(Topic))]
        [Required(ErrorMessage = "Please enter topic.")]
        public int TopicID { get; set; }     
        public virtual DifficultyLevel DifficultyLevel { get; set; }
        public virtual Topic Topic { get; set; }

        public QuestionBank()
        {

        }

        public QuestionBank(int a,string b, string c, string d, string e, string f, string g,int h,int i,int j)
        {
            this.QuestionBankID = a;
            this.Question = b;
            this.Option1 = c;
            this.Option2 = d;
            this.Option3 = e;
            this.Option4 = f;
            this.Answer = g;
            this.Marks = h;
            this.DifficultyLevelID = i;
            this.TopicID = j;
        }
    }

    public class QuestionFunction
    {
        public int dfid { get; set; }

        public int topicid { get; set; }
    }

    public class QuestionFuctionReturn
    {
        [Required(ErrorMessage = "Please enter question.")]
        [DisplayName("Question")]
        [StringLength(50, MinimumLength = 3)]
        public string Question { get; set; }

        [DisplayName("Option 1")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter option 1.")]
        public string Option1 { get; set; }
        [DisplayName("Option 2")]
        [Required(ErrorMessage = "Please enter option 2.")]
        [StringLength(50, MinimumLength = 3)]
        public string Option2 { get; set; }
        [DisplayName("Option 3")]
        [Required(ErrorMessage = "Please enter option 3.")]
        [StringLength(50, MinimumLength = 3)]
        public string Option3 { get; set; }
        [DisplayName("Option 4")]
        [Required(ErrorMessage = "Please enter option 4.")]
        [StringLength(50, MinimumLength = 3)]
        public string Option4 { get; set; }
        [DisplayName("Answer")]
        [Required(ErrorMessage = "Please enter answer.")]
        [StringLength(50, MinimumLength = 3)]
        public string Answer { get; set; }
    }
}
