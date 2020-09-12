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
    public class UserTest
    {

        [Key]
        public int UserTestID { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numbers in correct answers field")]
        [Required(ErrorMessage = "Correct answer is Required")]
        [DisplayName("Correct Answers")]
        public int CorrectAnswers { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numbers in incorrect answers field")]
        [Required(ErrorMessage = "Incorrect answer is required")]
        [DisplayName("Incorrect Answers")]
        public int IncorrectAnswers { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numbers in marks obtained field")]
        [Required(ErrorMessage = "Marks obtained is required")]
        [DisplayName("Marks Obtained")]
        public int MarksObtained { get; set; }

        [Required(ErrorMessage = "Start time is required")]
        [DataType(DataType.Time)]
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required")]

        [DataType(DataType.Time)]
        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }


        [Required(ErrorMessage = "Test date is Required")]
        [DataType(DataType.Date)]
        [DisplayName("Test Date")]
        public DateTime TestDate { get; set; }

        [ForeignKey(nameof(User))]
        [Required(ErrorMessage = "User ID is required")]
        [DisplayName("User ID")]
        public int UserID { get; set; }

        [ForeignKey(nameof(Test))]
        [Required(ErrorMessage = "Topic ID is Required")]
        [DisplayName("Topic ID")]
        public int TestID { get; set; }

        public virtual Test Test { get; set; }
        public virtual User User { get; set; }

    }

    public class GenerateUserTestFunction
    {

        public string UserEmail { get; set; }

       
        public int CorrectAnswers { get; set; }

      
        public int IncorrectAnswers { get; set; }

        
        public int MarksObtained { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

    }

    public class UserTestLog
    {
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numbers in marks obtained field")]
        [Required(ErrorMessage = "Marks obtained is required")]
        [DisplayName("Marks Obtained")]
        public int MarksObtained { get; set; }

        [Required(ErrorMessage = "Start time is required")]
        [DataType(DataType.Time)]
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required")]

        [DataType(DataType.Time)]
        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }


        [Required(ErrorMessage = "Test date is Required")]
        [DataType(DataType.Date)]
        [DisplayName("Test Date")]
        public DateTime TestDate { get; set; }

        public string TopicName { get; set; }
    }

}
