using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineAssessmentSystem.Areas.UserArea.Controllers
{
    public class TestGenerateController : ApiController
    {
        readonly ITestGenerate _bltestgenerate;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TestGenerateController(ITestGenerate bltestgenerate)
        {
            _bltestgenerate = bltestgenerate;
        }

        [Route("api/User/TestGenerate/Test/{userid}")]
        public IHttpActionResult PostGenerateUserTest(int userid, GenerateUserTestFunction type)
        {
            bool result;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _bltestgenerate.GenerateUserTest(type);

                    if (!result)
                    {
                        log.Error("User test failed to generate");
                        return BadRequest(ModelState);
                    }
                    else
                    {
                        return Ok();
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


        [Route("api/User/TestGenerate/Questions/{userid}")]
        public IHttpActionResult QuestionSubTopicSpecific(int userid, QuestionFunction type)
        {
            List<QuestionFuctionReturn> questions = null;
            try
            {
                if (ModelState.IsValid)
                {
                    questions = _bltestgenerate.QuestionSubTopicSpecific(type);

                    if (questions.Count == 0)
                    {
                        log.Error("Questions failed to generate");
                        return NotFound();
                    }
                    else
                    {
                        return Ok(questions);
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
