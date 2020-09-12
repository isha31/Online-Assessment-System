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
    public class BLUserTest:IUserTest
    {
        UserTestOperations _usertest_object;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BLUserTest()
        {
            _usertest_object = new UserTestOperations();
        }

        public List<UserTest> GetAllUserTests()
        {
            List<UserTest> usertests=new List<UserTest>();
            try
            {
                usertests = _usertest_object.GetAllUserTests();
                if (usertests != null)
                {
                    return usertests;
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
            return usertests;
        }
        public UserTest GetUserTestDetails(int id)
        {
            UserTest existingUserTest=new UserTest();
            try
            {
                existingUserTest = _usertest_object.GetUserTestDetails(id);
                if (existingUserTest != null)
                {
                    return existingUserTest;
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
            return existingUserTest;
        }
        public int CreateUserTest(UserTest usertest)
        {
            int result = 0;
            try
            {
                result =_usertest_object.CreateUserTest(usertest);
                if (result >0)
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
        public int UpdateUserTest(UserTest usertest)
        {
            int result = 0;
            try
            {
                result = _usertest_object.UpdateUserTest(usertest);
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
        public int DeleteUserTest(int id)
        {
            int result = 0;
            try
            {
                result = _usertest_object.DeleteUserTest(id);
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

        public List<UserTestLog> GetUserTestLog(int id,string email)
        {
            List<UserTestLog> userTestLog = new List<UserTestLog>();
            try
            {
                userTestLog = _usertest_object.GetUserTestLog(id,email);
                if (userTestLog !=null)
                {
                    return userTestLog;
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
            return userTestLog;
        }
    }
}
