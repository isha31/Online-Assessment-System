using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DifficultyLevel
    {
        [Key]
        public int DifficultyLevelID { get; set; }

        [Required(ErrorMessage = "Please enter difficulty level name.")]
        [DisplayName("Difficulty Level Name")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Please enter only aplhabets in difficulty level name field")]
        [StringLength(20, MinimumLength = 3)]
        public string DifficultyLevelName { get; set; }

        public ICollection<QuestionBank> QuestionBank { get; set; }

        public ICollection<Test> Test { get; set; }


        public DifficultyLevel()
        {

        }
        public DifficultyLevel(int a,string b)
        {
            this.DifficultyLevelID = a;
            this.DifficultyLevelName = b;
        }
    }
}
