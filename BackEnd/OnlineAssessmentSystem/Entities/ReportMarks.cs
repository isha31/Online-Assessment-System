using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    public class ReportMarks
    {
        public string DifficultyLevelName { get; set; }

        public string TopicName { get; set; }

        public decimal MarksObtained { get; set; }    
       
    }



    public class SubCategoryReportMarks
    {

        public string DifficultyLevelName { get; set; }

        public string SubCategoryName { get; set; }
        public decimal MarksObtained { get; set; }

    }


    public class CategoryReportMarks
    {
        public string CategoryName { get; set; }
        public decimal MarksObtained { get; set; }

    }


    public class SubCategoryAdmin
    {
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public SubCategoryAdmin()
        {

        }

        public SubCategoryAdmin(int a, string b, int c, string d)
        {
            this.SubCategoryID = a;
            this.SubCategoryName = b;
            this.CategoryID = c;
            this.CategoryName = d;
        }
    }

    public class TopicAdmin
    {
        public int TopicID { get; set; }
        public string TopicName { get; set; }

        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }

        public TopicAdmin()
        {

        }

        public TopicAdmin(int a, string b, int c, string d)
        {
            this.TopicID = a;
            this.TopicName = b;
            this.SubCategoryID = c;
            this.SubCategoryName = d;
        }
    }


    public class AdminQuestionBank
    {
        public int QuestionBankID { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

        public string Answer { get; set; }

        public int Marks { get; set; }
        public string DifficultyLevel { get; set; }

        public string Topic { get; set; }
    }


}
