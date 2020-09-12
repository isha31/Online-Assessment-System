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
    public class TopicController : ApiController
    {
        readonly ITopic _bltopic;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TopicController(ITopic bltopic)
        {
            _bltopic = bltopic;
        }

        // GET: api/Topic


        [ResponseType(typeof(Topic))]

        public HttpResponseMessage GetAllTopics()
        {
            List<Topic> topics = null;
            try
            {
                if (ModelState.IsValid)
                {
                    topics = _bltopic.GetAllTopics();

                    if (topics.Count == 0)
                    {
                        log.Error("Reuested data has null entries");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, topics);
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

        // GET: api/Topic/5

        [ResponseType(typeof(Topic))]
        public HttpResponseMessage GetTopic(int id)
        {
            Topic topic;
            try
            {
                if (ModelState.IsValid)
                {
                    topic = _bltopic.GetTopicDetails(id);

                    if (topic == null)
                    {
                        log.Error("Requested data not found");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }

                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, topic);
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

        // POST: api/Topic

        [ResponseType(typeof(void))]
        public HttpResponseMessage PostTopic(Topic topic)
        {

            List<TopicAdmin> topics = null;

            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    topics = _bltopic.CreateTopic(topic);
                    if (topics!=null)
                        return Request.CreateResponse(HttpStatusCode.Created, topics);
                    else
                    {
                        log.Error("Topic failed to create");
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

        // PUT: api/Topic

        [ResponseType(typeof(void))]
        public HttpResponseMessage PutTopic(Topic topic)
        {
            List<TopicAdmin> topics = null;
            
            try
            {
                if (ModelState.IsValid)
                {
                    topics = _bltopic.UpdateTopic(topic);
                    if (topics!=null)
                        return Request.CreateResponse(HttpStatusCode.OK,topics);
                    else
                    {
                        log.Error("Topic failed to update");
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

        // DELETE: api/Topic

        [ResponseType(typeof(void))]
        public HttpResponseMessage DeleteTopic(int id)
        {
            List<TopicAdmin> topics = null;

            try
            {
                if (ModelState.IsValid)
                {
                    topics = _bltopic.DeleteTopic(id);
                    if (topics!=null)
                        return Request.CreateResponse(HttpStatusCode.OK,topics);
                    else
                    {
                        log.Error("Topic failed to delete");
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

    public class AdminTopicController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        BLTopic _bltopic = new BLTopic();
        [ResponseType(typeof(TopicAdmin))]

        public HttpResponseMessage GetAllTopicsAdmin()
        {
            List<TopicAdmin> topics = null;
            try
            {
                if (ModelState.IsValid)
                {
                    topics = _bltopic.GetAllTopicAdmin();

                    if (topics.Count == 0)
                    {
                        log.Error("Reuested data not found");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                       
                        return Request.CreateResponse(HttpStatusCode.OK, topics);
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
