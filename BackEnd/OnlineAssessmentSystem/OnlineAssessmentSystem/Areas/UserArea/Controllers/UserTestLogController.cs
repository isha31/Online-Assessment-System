using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineAssessmentSystem.Areas.UserArea.Controllers
{
    public class UserTestLogController : ApiController
    {
        readonly IUserTest _blusertestlog;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserTestLogController(IUserTest blusertestlog)
        {
            _blusertestlog = blusertestlog;
        }

        [ResponseType(typeof(UserTestLog))]
        public IHttpActionResult GetUserTestLog(int id, string email)
        {
            List<UserTestLog> userTestLog;
            try
            {
                if (ModelState.IsValid)
                {
                    userTestLog = _blusertestlog.GetUserTestLog(id, email);

                    if (userTestLog == null)
                    {
                        log.Error("Requested data not found");
                        return NotFound();
                    }

                    else
                    {
                        return Ok(userTestLog);
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
