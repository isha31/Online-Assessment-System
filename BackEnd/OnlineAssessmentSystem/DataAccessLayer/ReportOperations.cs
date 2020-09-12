using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReportOperations : IReports
    {
        readonly OASContext context = new OASContext();
        public List<ReportMarks> GetTopicReport(string id)
        {
            List<ReportMarks> marks_list = new List<ReportMarks>();

            var marklist = (from usertest in context.UserTests
                         join test in context.Tests on usertest.TestID equals test.TestID
                         join topic in context.Topics on test.TopicID equals topic.TopicID
                         join difficultylevel in context.DifficultyLevels on test.DifficultyLevelID equals difficultylevel.DifficultyLevelID
                         where usertest.User.EmailID == id
                         group new { usertest.MarksObtained, test.TotalMarks } by new { difficultylevel.DifficultyLevelName, topic.TopicName } into grp
                         select new
                         {
                             DifficultyLevelName=grp.Key.DifficultyLevelName,
                             TopicName=grp.Key.TopicName,
                             MarksObtained = grp.Sum(marks => marks.MarksObtained),
                             TotalMarks = grp.Sum(marks=> marks.TotalMarks)
                         }
                       ).ToList();



            int i = 1;

            foreach(var m in marklist)
            {
                marks_list.Add(new ReportMarks()
                {
                    DifficultyLevelName=m.TopicName,
                    TopicName= m.TopicName,
                    MarksObtained=m.MarksObtained
                });
            }
            return marks_list;
        }

        public List<SubCategoryReportMarks> GetSubCategoryReport(string id)
        {
            List<SubCategoryReportMarks> marks_list = new List<SubCategoryReportMarks>();

            var marklist = (from usertest in context.UserTests
                            join test in context.Tests on usertest.TestID equals test.TestID
                            join topic in context.Topics on test.TopicID equals topic.TopicID
                            join difficultylevel in context.DifficultyLevels on test.DifficultyLevelID equals difficultylevel.DifficultyLevelID
                            join subcategory in context.SubCategorys on topic.SubCategoryID equals subcategory.SubCategoryID
                            where usertest.User.EmailID == id
                            group new { usertest.MarksObtained,test.TotalMarks } by new { difficultylevel.DifficultyLevelName, subcategory.SubCategoryName } into grp
                            select new
                            {
                                DifficultyLevelName=grp.Key.DifficultyLevelName,
                                SubCategoryName = grp.Key.SubCategoryName,
                                MarksObtained = grp.Sum(marks => marks.MarksObtained),
                                TotalMarks = grp.Sum(marks => marks.TotalMarks)
                            }
                       ).ToList();

            int i = 1;

            foreach (var m in marklist)
            {
                marks_list.Add(new SubCategoryReportMarks()
                {
                   DifficultyLevelName=m.DifficultyLevelName,
                    SubCategoryName = m.SubCategoryName,
                    MarksObtained = m.MarksObtained

                });
            }
            return marks_list;
        }

        public List<CategoryReportMarks> GetCategoryReport(string id)
        {
            List<CategoryReportMarks> marks_list = new List<CategoryReportMarks>();

            var marklist = (from usertest in context.UserTests
                            join test in context.Tests on usertest.TestID equals test.TestID
                            join topic in context.Topics on test.TopicID equals topic.TopicID
                            join difficultylevel in context.DifficultyLevels on test.DifficultyLevelID equals difficultylevel.DifficultyLevelID
                            join subcategory in context.SubCategorys on topic.SubCategoryID equals subcategory.SubCategoryID
                            join category in context.Categorys on subcategory.CategoryID equals category.CategoryID
                            where usertest.User.EmailID == id
                            group new { usertest.MarksObtained, test.TotalMarks } by new { category.CategoryName } into grp
                            select new
                            {
                                CategoryName = grp.Key.CategoryName,
                                MarksObtained = grp.Sum(marks => marks.MarksObtained),
                                TotalMarks = grp.Sum(marks => marks.TotalMarks)
                            }
                       ).ToList();

            int i = 1;

            foreach (var m in marklist)
            {
                marks_list.Add(new CategoryReportMarks()
                {
                   
                    CategoryName = m.CategoryName,
                    MarksObtained = m.MarksObtained
                    


                });
            }
            return marks_list;
        }
    }
    
}
