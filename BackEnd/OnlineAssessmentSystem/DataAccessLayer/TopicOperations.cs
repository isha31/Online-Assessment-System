using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TopicOperations : IDisposable,ITopic
    {
        readonly OASContext ctx = new OASContext();
        string exceptionMessage;
        public List<TopicAdmin> CreateTopic(Topic topic)
        {
            List<TopicAdmin> topicslist = new List<TopicAdmin>();

            int result = 0;
            try
            {
                ctx.Topics.Add(topic);
                result = ctx.SaveChanges();
                topicslist = GetAllTopicAdmin();

                return topicslist;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return topicslist;
        }

        public List<TopicAdmin> DeleteTopic(int id)
        {
            List<TopicAdmin> topicslist = new List<TopicAdmin>();

            int result = 0;
            try
            {

                var existingTopic = ctx.Topics.FirstOrDefault(topic => topic.TopicID == id);
                if (existingTopic != null)
                {
                    ctx.Topics.Remove(existingTopic);
                    result = ctx.SaveChanges();
                    topicslist = GetAllTopicAdmin();

                }
                return topicslist;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return topicslist;
        }

        public List<Topic> GetAllTopics()
        {
            List<Topic> topics = new List<Topic>();
            try
            {
                topics = ctx.Topics.ToList();
                return topics;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return topics;
        }

        public Topic GetTopicDetails(int id)
        {
            Topic existingTopic = new Topic();
            try
            {
                existingTopic = ctx.Topics.FirstOrDefault(topic => topic.TopicID == id);
                return existingTopic;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return existingTopic;
        }

        public List<TopicAdmin> UpdateTopic(Topic topic)
        {
            List<TopicAdmin> topicslist = new List<TopicAdmin>();

            int result = 0;
            try
            {

                Topic existingTopic = ctx.Topics.FirstOrDefault(topics => topics.TopicID == topic.TopicID);
                if (existingTopic != null)
                {
                    existingTopic.TopicName = topic.TopicName;
                    existingTopic.SubCategoryID = topic.SubCategoryID;

                    result = ctx.SaveChanges();
                    topicslist = GetAllTopicAdmin();

                }
                return topicslist;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return topicslist;
        }

        public void Dispose()
        {
            ctx.Dispose();
        }


        public List<TopicAdmin> GetAllTopicAdmin()
        {
            List<TopicAdmin> topicList = new List<TopicAdmin>();
            try
            {
                var topics = from top in ctx.Topics join sub in ctx.SubCategorys on top.SubCategoryID equals sub.SubCategoryID select new { TopID = top.TopicID, TopName = top.TopicName, SubCatID = top.SubCategoryID, SubCatName = sub.SubCategoryName};
                foreach (var adminSub in topics)
                {

                    topicList.Add(new TopicAdmin()
                    {
                        TopicID=adminSub.TopID,
                        TopicName=adminSub.TopName,
                        SubCategoryID = adminSub.SubCatID,
                        SubCategoryName = adminSub.SubCatName
                       
                    });
                }

                return topicList;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return topicList;
        }
    }
}
