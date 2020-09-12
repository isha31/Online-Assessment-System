using DataAccessLayer;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLTest : ITest
    {
        readonly TestOperations _test_object;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BLTest()
        {
            _test_object = new TestOperations();
        }


        public List<Test> GetAllTests()
        {
            List<Test> tests = new List<Test>();
            try
            {
                tests = _test_object.GetAllTests();
                if (tests != null)
                {
                    return tests;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return tests;
        }
        public Test GetTestDetails(int id)
        {
            Test existingTest = new Test();
            try
            {
                existingTest = _test_object.GetTestDetails(id);
                if (existingTest != null)
                {
                    return existingTest;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return existingTest;
        }
        public int CreateTest(Test test)
        {
            int result = 0;
            try
            {
                result = _test_object.CreateTest(test);
                if (result>0)
                {
                    return result;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return result;
        }
        public int UpdateTest(Test test)
        {
            int result = 0;
            try
            {
                result = _test_object.UpdateTest(test);
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return result;
        }
        public int DeleteTest(int id)
        {
            int result = 0;
            try
            {
                result = _test_object.DeleteTest(id);
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return result;
        }
    }
}
