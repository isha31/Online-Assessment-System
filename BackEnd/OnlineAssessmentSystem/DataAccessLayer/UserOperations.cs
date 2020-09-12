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
    public class UserOperations:IUser
    {
        readonly OASContext ctx = new OASContext();
        string exceptionMessage;
        public int CreateUser(User user)
        {
            int result = 0;
            try
            {
                ctx.Users.Add(user);
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

        public int DeleteUser(int id)
        {
            int result = 0;
            try
            {

                var existingUser = ctx.Users.FirstOrDefault(user => user.UserID == id);
                if (existingUser != null)
                {
                    ctx.Users.Remove(existingUser);
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

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = ctx.Users.ToList();
                return users;
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
            return users;
        }

        public User GetUserDetails(int id,string email)
        {
            User existingUser = new User();
            try
            {
                existingUser = ctx.Users.FirstOrDefault(user => user.EmailID == email);
                return existingUser;
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
            return existingUser;
        }

        public int UpdateUser(User user)
        {
            int result = 0;
            try
            {

                User existingUser = ctx.Users.FirstOrDefault(users => users.UserID == user.UserID);
                if (existingUser != null)
                {
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Gender = user.Gender;
                    existingUser.DOB = user.DOB;
                    existingUser.EmailID = user.EmailID;
                    existingUser.ContactNo = user.ContactNo;
                    existingUser.Country = user.Country;
                    existingUser.Password = user.Password;

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
