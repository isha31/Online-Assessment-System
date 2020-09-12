using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineAssessmentSystem.Areas.Admin.Controllers
{
    [RoutePrefix("api/Admin/Report")]
    public class ReportController : ApiController
    {
        readonly IReports _blreport;

        public ReportController(IReports blreport)
        {
            _blreport = blreport;
        }

       

        [Route("TopicReport/{i}")]
        public IHttpActionResult GetTopicReport(int i,string id)
        {
            List<ReportMarks> marks = null;
            try
            {
                if (ModelState.IsValid)
                {
                    marks = _blreport.GetTopicReport(id);

                    if (marks.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(marks);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }

        [Route("SubCategoryReport/{i}")]
        public IHttpActionResult GetSubCategoryReport(int i,string id)
        {
            List<SubCategoryReportMarks> marks = null;
            try
            {
                if (ModelState.IsValid)
                {
                    
                   
                    marks = _blreport.GetSubCategoryReport(id);

                    if (marks.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(marks);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }

     
        [Route("CategoryReport/{i}")]
        public IHttpActionResult GetCategoryReport(int i,string id)
        {
            List<CategoryReportMarks> marks = null;
            try
            {
                if (ModelState.IsValid)
                {
                    marks = _blreport.GetCategoryReport(id);

                    if (marks.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(marks);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }

    }
}
