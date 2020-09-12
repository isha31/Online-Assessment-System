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
    public class DifficultyLevelController : ApiController
    {
        readonly IDifficultyLevel _bldifficultylevel;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DifficultyLevelController(IDifficultyLevel bldifficultylevel)
        {
            _bldifficultylevel = bldifficultylevel;
        }

        // GET: api/DifficultyLevel
        [HttpGet]
        // [Route("Admin/api/DifficultyLevel")]
        [ResponseType(typeof(DifficultyLevel))]

        public HttpResponseMessage GetAllDifficultyLevels()
        {
            List<DifficultyLevel> difficultylevels = null;
            try
            {
                if (ModelState.IsValid)
                {
                    difficultylevels = _bldifficultylevel.GetAllDifficultyLevels();
                    
                    if (difficultylevels.Count == 0)
                    {
                        log.Error("Requested data has null data entries.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,difficultylevels);
                    }
                }
                else
                {
                    log.Error("Invalid model state encountered.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        // GET: api/DifficultyLevel/5
        //  [Route("Admin/api/DifficultyLevel/{id}")]
        [ResponseType(typeof(DifficultyLevel))]
        public HttpResponseMessage GetDifficultyLevel(int id)
        {
            DifficultyLevel difficultylevel;
            try
            {
                if (ModelState.IsValid)
                {
                    difficultylevel = _bldifficultylevel.GetDifficultyLevelDetails(id);

                    if (difficultylevel == null)
                    {
                        log.Error("Requested data not found.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }

                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, difficultylevel);

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
