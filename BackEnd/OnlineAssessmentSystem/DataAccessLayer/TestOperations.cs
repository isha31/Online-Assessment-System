using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class TestOperations: ITest
    {
        OASContext ctx = new OASContext();
        string exceptionMessage;

        public List<Test> GetAllTests()
        {
            List<Test> tests = new List<Test>();
            try
            {
                tests = ctx.Tests.ToList();
                return tests;
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
            return tests;
        }

        public Test GetTestDetails(int id)
        {
            Test existingTest = new Test();
            try
            {
                existingTest = ctx.Tests.FirstOrDefault(test => test.TestID == id);
                return existingTest;
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
            return existingTest;
        }

        public int CreateTest(Test test)
        {
            int result = 0;
            try
            {
                ctx.Tests.Add(test);
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

        public int UpdateTest(Test test)
        {
            int result = 0;
            try
            {

                Test existingTest = ctx.Tests.FirstOrDefault(tests => tests.TestID == test.TestID);
                if (existingTest != null)
                {
                    existingTest.TotalQuestions = test.TotalQuestions;
                    existingTest.TotalMarks = test.TotalMarks;
                    existingTest.TotalDuration = test.TotalDuration;
                    existingTest.TopicID = test.TopicID;

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
        public int DeleteTest(int id)
        {
            int result = 0;
            try
            {

                var existingTest = ctx.Tests.FirstOrDefault(test => test.TestID == id);
                if (existingTest != null)
                {
                    ctx.Tests.Remove(existingTest);
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

    }
}
