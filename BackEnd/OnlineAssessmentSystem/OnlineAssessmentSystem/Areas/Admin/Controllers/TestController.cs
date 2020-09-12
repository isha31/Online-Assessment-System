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
    public class TestController : ApiController
    {
        readonly ITest _bltest;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TestController(ITest bltest)
        {
            _bltest = bltest;
        }

        // GET: api/Test

       
        [ResponseType(typeof(Test))]

        public HttpResponseMessage GetAllTests()
        {
            List<Test> tests = null;
            try
            {
                if (ModelState.IsValid)
                {
                    tests = _bltest.GetAllTests();

                    if (tests.Count == 0)
                    {
                        log.Error("Requested data has null data entries.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                     return Request.CreateResponse(HttpStatusCode.OK, tests);
                    }
                }
                else
                {
                    log.Error("Invalid model state encountered.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        // GET: api/Tests/5
      
        [ResponseType(typeof(Test))]
        public HttpResponseMessage GetTest(int id)
        {
            Test test;
            try
            {
                if (ModelState.IsValid)
                {
                    test = _bltest.GetTestDetails(id);

                    if (test == null)
                    {
                        log.Error("Requested data not found.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }

                    else
                    {
                    return Request.CreateResponse(HttpStatusCode.OK, test);

                    }
                }
                else
                {
                    log.Error("Invalid model state encountered.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        // POST: api/UserTests
        
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PostUserTest(Test test)
        //{


        //    int result = 0;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            result = _bltest.CreateTest(test);
        //            if (result > 0)
        //                return Created(Request.RequestUri + "/" + test.TestID, test);
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

        // PUT: api/Tests
        
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutTest(Test test)
        {

            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _bltest.UpdateTest(test);
                    if (result > 0)
                    {
                     return Request.CreateResponse(HttpStatusCode.OK);
                    }
                       
                    else
                    {
                        log.Error("Test failed to update");
                        return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                        
                }
                else
                {
                    log.Error("Invalid model state encountered.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE: api/Tests
       
        [ResponseType(typeof(void))]
        public HttpResponseMessage DeleteTest(int id)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _bltest.DeleteTest(id);
                    if (result > 0)
                    {
                    return Request.CreateResponse(HttpStatusCode.OK);
                    }
                        
                    else
                    {
                        log.Error("Test failed to delete");
                        return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                        
                }
                else
                {
                    log.Error("Invalid model state encountered.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }
    }
}
