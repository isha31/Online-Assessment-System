using DataAccessLayer;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLTopic : ITopic
    {
        readonly TopicOperations _topic_object;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BLTopic()
        {
            _topic_object = new TopicOperations();
        }

        public List<Topic> GetAllTopics()
        {
            List<Topic> subcategories = new List<Topic>();
            try
            {
                subcategories = _topic_object.GetAllTopics();
                if (subcategories != null)
                {
                    return subcategories;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return subcategories;

        }
        public Topic GetTopicDetails(int id)
        {
            Topic existingTopic = new Topic();
            try
            {
                existingTopic = _topic_object.GetTopicDetails(id);
                if (existingTopic != null)
                {
                    return existingTopic;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return existingTopic;
        }
        public List<TopicAdmin> CreateTopic(Topic topic)
        {
            List<TopicAdmin> topiclist = new List<TopicAdmin>();

          
            try
            {
                topiclist = _topic_object.CreateTopic(topic);
                if (topiclist != null)
                {
                    return topiclist;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return topiclist;
        }
        public List<TopicAdmin> UpdateTopic(Topic topic)
        {
            List<TopicAdmin> topiclist = new List<TopicAdmin>();
            try
            {
                topiclist = _topic_object.UpdateTopic(topic);

                if (topiclist != null)
                {
                    return topiclist;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return topiclist;
        }
        public List<TopicAdmin> DeleteTopic(int id)
        {
            List<TopicAdmin> topiclist = new List<TopicAdmin>();

           
            try
            {
                topiclist = _topic_object.DeleteTopic(id);
                if (topiclist != null)
                {
                    return topiclist;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return topiclist;
        }

        public List<TopicAdmin> GetAllTopicAdmin()
        {
            List<TopicAdmin> subcategories = new List<TopicAdmin>();
            try
            {
                subcategories = _topic_object.GetAllTopicAdmin();
                if (subcategories != null)
                {
                    return subcategories;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return subcategories;
        }
    }
}
