using BusinessLogicLayer;
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
    public class QuestionBankController : ApiController
    {
        readonly IQuestionBank _blquestionbank;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public QuestionBankController(IQuestionBank blquestionbank)
        {
            _blquestionbank = blquestionbank;
        }

        // GET: api/QuestionBank
        [HttpGet]
        // [Route("Admin/api/QuestionBank")]
        [ResponseType(typeof(QuestionBank))]

        public HttpResponseMessage GetAllQuestionBanks()
        {
            List<QuestionBank> questionbanks = null;
            try
            {
                if (ModelState.IsValid)
                {
                    questionbanks = _blquestionbank.GetAllQuestionBanks();

                    if (questionbanks.Count == 0)
                    {
                        log.Error("Requested data has null data entries.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, questionbanks);
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

        // GET: api/QuestionBank/5
        //  [Route("Admin/api/QuestionBank/{id}")]
        [ResponseType(typeof(UserTest))]
        public HttpResponseMessage GetQuestionBank(int id)
        {
            QuestionBank questionbank;
            try
            {
                if (ModelState.IsValid)
                {
                    questionbank = _blquestionbank.GetQuestionBankDetails(id);

                    if (questionbank == null)
                    {
                        log.Error("Requested data not found.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }

                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, questionbank);
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

        // POST: api/QuestionBank
        // [Route("Admin/api/QuestionBank")]
        [ResponseType(typeof(void))]
        public HttpResponseMessage PostQuestionBank(int id)
        {


            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _blquestionbank.CreateQuestionBank(id);
                    if (result > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,"OK");
                    }
                        
                
                    else
                    {
                        log.Error("Question bank not created");
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

        // PUT: api/UserTests
        // [Route("Admin/api/UserTest")]
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutQuestionBank(QuestionBank questionbank)
        {

            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _blquestionbank.UpdateQuestionBank(questionbank);
                    if (result > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                        
                    else
                    {
                        log.Error("Question bank failed to update");
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

        // DELETE: api/QuestionBank
        // [Route("Admin/api/QuestionBank/{id}")]
        [ResponseType(typeof(void))]
        public HttpResponseMessage DeleteQuestionBank(int id)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _blquestionbank.DeleteQuestionBank(id);
                    if (result > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                        
                    else
                    {
                        log.Error("Question bank failed to delete");
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
    public class AdminQuestionBankController : ApiController
    {
        BLQuestionBank _blquestionbank = new BLQuestionBank();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [ResponseType(typeof(QuestionBank))]

        public HttpResponseMessage GetAllAdminQuestionBanks()
        {

            List<AdminQuestionBank> questionbanks = null;

            try
            {
                if (ModelState.IsValid)
                {
                    questionbanks = _blquestionbank.GetAllAdminQuestionBanks();

                    if (questionbanks.Count == 0)
                    {
                        log.Error("Requested data not found");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, questionbanks);
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
