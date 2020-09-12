using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineAssessmentSystem.Areas.Admin.Controllers
{
    public class UserController : ApiController
    {
        readonly IUser _bluser;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserController(IUser bluser)
        {
            _bluser = bluser;
        }

        // GET: api/User

        
        [ResponseType(typeof(User))]

        public IHttpActionResult GetAllTests()
        {
            List<User> users = null;

            try
            {
                if (ModelState.IsValid)
                {
                    users = _bluser.GetAllUsers();

                    if (users.Count == 0)
                    {
                        log.Error("Requested data has null data entries.");

                        return NotFound();
                    }
                    else
                    {
                        return Ok(users);
                    }
                }
                else
                {
                    log.Error("Invalid model state encountered.");

                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);

                return BadRequest(ModelState);
            }

        }

        // GET: api/Tests/5
     
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id, string email)
        {
            User user;
            try
            {
                if (ModelState.IsValid)
                {
                    user = _bluser.GetUserDetails(id, email);

                    if (user == null)
                    {
                        log.Error("Requested data not found.");

                        return NotFound();
                    }

                    else
                    {
                        return Ok(user);
                    }
                }
                else
                {
                    log.Error("Invalid model state encountered.");

                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);

                return BadRequest(ModelState);
            }

        }






        // PUT: api/Tests
       
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTest(User user)
        {

            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _bluser.UpdateUser(user);
                    if (result > 0)
                        return Ok();
                    else
                    {
                        log.Error("User failed to update");
                        return BadRequest(ModelState);

                    }
                }
                else
                {
                    log.Error("Invalid model state encountered.");

                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);

                return BadRequest(ModelState);
            }
        }

        // DELETE: api/User

        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteUser(int id)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _bluser.DeleteUser(id);
                    if (result > 0)
                        return Ok();
                    else
                    {
                        log.Error("User failed to delete");
                        return BadRequest(ModelState);

                    }
                }
                else
                {
                    log.Error("Invalid model state encountered.");

                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);

                return BadRequest(ModelState);
            }

        }
    }
}
