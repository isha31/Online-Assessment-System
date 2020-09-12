using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TestGenerateOperations: ITestGenerate
    {
        readonly OASContext context = new OASContext();
        public List<QuestionFuctionReturn> QuestionSubTopicSpecific(QuestionFunction type)
        {
            List<QuestionFuctionReturn> questionbank = new List<QuestionFuctionReturn>();
            var questions = (
                            from topic in context.Topics
                            join questionbank_bank in context.QuestionBanks on topic.TopicID equals questionbank_bank.TopicID
                            join difficultylevel in context.DifficultyLevels on questionbank_bank.DifficultyLevelID equals difficultylevel.DifficultyLevelID
                            where difficultylevel.DifficultyLevelID == type.dfid && topic.TopicID == type.topicid
                            select new
                            {
                                DifficultyLevelID = questionbank_bank.DifficultyLevelID,
                                TopicID = questionbank_bank.TopicID,
                                Question = questionbank_bank.Question,
                                Option1 = questionbank_bank.Option1,
                                Option2 = questionbank_bank.Option2,
                                Option3 = questionbank_bank.Option3,
                                Option4 = questionbank_bank.Option4,
                                Answer = questionbank_bank.Answer
                            }
                            ).OrderBy(x => Guid.NewGuid()).Take(10).ToList();




            int i = 0;
            foreach (var q in questions)
            {

                questionbank.Add(new QuestionFuctionReturn()
                {

                    Question = q.Question,
                    Option1 = q.Option1,
                    Option2 = q.Option2,
                    Option3 = q.Option3,
                    Option4 = q.Option4,
                    Answer = q.Answer
                });
            }

            //For generating new test entry
            int topic_id = 0, df_id = 0;

            for (i = 0; i < 1; i++)
            {
                topic_id = questions[0].TopicID;
                df_id = questions[0].DifficultyLevelID;
            }

            Test newtest = new Test();
            newtest.TotalQuestions = 10;
            newtest.TotalMarks = 10;
            newtest.TotalDuration = DateTime.Now;
            newtest.TopicID = topic_id;
            newtest.DifficultyLevelID = df_id;

            TestOperations ctx = new TestOperations();
            ctx.CreateTest(newtest);

            return questionbank;
        }

        public bool GenerateUserTest(GenerateUserTestFunction user_test)
        {
            int user_id = 0, test_id = 0;

            User existingUser = context.Users.FirstOrDefault(user => user.EmailID == user_test.UserEmail);
            if (existingUser != null)
            {
                user_id = existingUser.UserID;
            }
            //Test existingTest = context.Tests.LastOrDefault(test=> test.);
            //if (existingTest != null)
            //{
            //    test_id = existingTest.TestID;
            //}
            //var query = (from test in context.Tests
            //             select new
            //             {
            //                 TestID = test.TestID
            //             }).LastOrDefault();

            //test_id = query.TestID;

            var count = context.Tests.Count();
            var list=context.Tests.ToList();

            test_id = list[count-1].TestID;

            UserTest newusertest = new UserTest();
            newusertest.UserTestID = 1;
            newusertest.CorrectAnswers = user_test.CorrectAnswers;
            newusertest.IncorrectAnswers = user_test.IncorrectAnswers;
            newusertest.MarksObtained = user_test.MarksObtained;
            newusertest.StartTime = user_test.StartTime;
            newusertest.EndTime = user_test.EndTime;
            newusertest.TestDate = DateTime.Now;
            newusertest.UserID = user_id;
            newusertest.TestID = test_id;

            UserTestOperations ctx = new UserTestOperations();
            int result = ctx.CreateUserTest(newusertest);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return true;
        }
    }
}
