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
    public class UserTestController : ApiController
    {

        readonly IUserTest _blusertest;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserTestController(IUserTest blusertest)
        {
            _blusertest = blusertest;
        }

        // GET: api/UserTests
        [HttpGet]
       // [Route("Admin/api/UserTest")]
        [ResponseType(typeof(UserTest))]

        public IHttpActionResult GetAllUserTests()
        {
            List<UserTest> usertests = null;
            try
            {
                if (ModelState.IsValid)
                {
                    usertests = _blusertest.GetAllUserTests();

                    if (usertests.Count == 0)
                    {
                        log.Error("Requested data has null data entries.");

                        return NotFound();
                    }
                    else
                    {
                        return Ok(usertests);
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

        // GET: api/UserTests/5
      //  [Route("Admin/api/UserTest/{id}")]
        [ResponseType(typeof(UserTest))]
        public IHttpActionResult GetUserTest(int id)
        {
            UserTest usertest;
            try
            {
                if (ModelState.IsValid)
                {
                    usertest = _blusertest.GetUserTestDetails(id);

                    if (usertest == null)
                    {
                        log.Error("Requested data not found");
                        return NotFound();
                    }

                    else
                    {
                        return Ok(usertest);
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

        // POST: api/UserTests
       // [Route("Admin/api/UserTest")]
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PostUserTest(UserTest usertest)
        //{


        //    int result = 0;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            result = _blusertest.CreateUserTest(usertest);
        //            if (result > 0)
        //                return Created(Request.RequestUri + "/" + usertest.UserTestID, usertest);
        //            else
        //                return BadRequest(ModelState);
        //        }
        //        else
        //        {
        //            return BadRequest(ModelState);
        //        }
        //    }
        //    catch
        //    {
        //        return BadRequest(ModelState);
        //    }

        //}

        // PUT: api/UserTests
       // [Route("Admin/api/UserTest")]


        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserTest(UserTest usertest)
        {

            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _blusertest.UpdateUserTest(usertest);
                    if (result > 0)
                        return Ok();
                    else
                    {
                        log.Error("User test failed to update");
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

        // DELETE: api/UserTests
       // [Route("Admin/api/UserTest/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteUserTest(int id)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _blusertest.DeleteUserTest(id);
                    if (result > 0)
                        return Ok();
                    else
                    {
                        log.Error("User test failed to delete");
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
