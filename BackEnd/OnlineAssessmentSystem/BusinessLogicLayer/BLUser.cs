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
    public class BLUser : IUser
    {

        readonly UserOperations _user_object;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BLUser()
        {
            _user_object = new UserOperations();
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = _user_object.GetAllUsers();
                if (users != null)
                {
                    return users;
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
            return users;
        }
        public User GetUserDetails(int id, string email)
        {
            User existingUser = new User();
            try
            {
                existingUser = _user_object.GetUserDetails(id,email);
                if (existingUser != null)
                {
                    return existingUser;
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
            return existingUser;
        }

        public int CreateUser(User user)
        {
            int result = 0;
            try
            {
                result = _user_object.CreateUser(user);
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


        public int UpdateUser(User user)
        {
            int result = 0;
            try
            {
                result = _user_object.UpdateUser(user);
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
        public int DeleteUser(int id)
        {
            int result = 0;
            try
            {
                result = _user_object.DeleteUser(id);
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
