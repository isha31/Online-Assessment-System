using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserTestOperations: IUserTest
    {
        readonly OASContext ctx = new OASContext();
        
        public List<UserTest> GetAllUserTests()
        {
            List<UserTest> usertests = new List<UserTest>();
            string exceptionMessage;
            try
            {
                usertests = ctx.UserTests.ToList();
                return usertests;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return usertests;
        }
        public UserTest GetUserTestDetails(int id)
        {
            UserTest existingUserTest = new UserTest();
            string exceptionMessage;
            try
            {
                existingUserTest = ctx.UserTests.FirstOrDefault(usertest => usertest.UserTestID == id);
                return existingUserTest;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return existingUserTest;
        }

        public int CreateUserTest(UserTest usertest)
        {
            int result = 0;
            string exceptionMessage;
            try
            {
                ctx.UserTests.Add(usertest);
                result = ctx.SaveChanges();
                return result;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return result;
        }
        public int UpdateUserTest(UserTest usertest)
        {
            int result = 0;
            string exceptionMessage;
            try
            {

                UserTest existingUserTest = ctx.UserTests.FirstOrDefault(usertests => usertests.UserTestID == usertest.UserTestID);
                if (existingUserTest != null)
                {
                    existingUserTest.CorrectAnswers = usertest.CorrectAnswers;
                    existingUserTest.IncorrectAnswers = usertest.IncorrectAnswers;
                    existingUserTest.MarksObtained = usertest.MarksObtained;
                    existingUserTest.StartTime = usertest.StartTime;
                    existingUserTest.EndTime = usertest.EndTime;
                    existingUserTest.TestDate = usertest.TestDate;
                    existingUserTest.TestID = usertest.TestID;

                    result = ctx.SaveChanges();
                }
                return result;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return result;
        }
        public int DeleteUserTest(int id)
        {
            int result = 0;
            string exceptionMessage;
            try
            {

                var existingUserTest = ctx.UserTests.FirstOrDefault(usertest => usertest.UserTestID == id);
                if (existingUserTest != null)
                {
                    ctx.UserTests.Remove(existingUserTest);
                    result = ctx.SaveChanges();
                }
                return result;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return result;
        }

        public List<UserTestLog> GetUserTestLog(int id,string email)
        {
            List<UserTestLog> userTestLog = new List<UserTestLog>();
            string exceptionMessage;
            try
            {
                var new_userTestLog = (from usertest in ctx.UserTests
                                       join test in ctx.Tests on usertest.TestID equals test.TestID
                                       join topic in ctx.Topics on test.TopicID equals topic.TopicID
                                       where usertest.User.EmailID == email
                                       select new
                                       {
                                           MarksObtained= usertest.MarksObtained,
                                           StartTime = usertest.StartTime,
                                           EndTime = usertest.EndTime,
                                           TestDate = usertest.TestDate,
                                           TopicName = topic.TopicName,

                                       }).OrderByDescending(x=>x.TestDate).ToList();

                //var newList = new_userTestLog.OrderByDescending(x => x.TestDate).ToList();

                foreach (var m in new_userTestLog)
                {
                    userTestLog.Add(new UserTestLog()
                    {
                       MarksObtained=m.MarksObtained,
                       TestDate=m.TestDate,
                       StartTime=m.StartTime,
                       EndTime=m.EndTime,
                       TopicName=m.TopicName
                    });
                }




                //ctx.UserTests.FirstOrDefault(usertest => usertest.UserTestID == id);
                return userTestLog;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return userTestLog;
        }
    }
}
