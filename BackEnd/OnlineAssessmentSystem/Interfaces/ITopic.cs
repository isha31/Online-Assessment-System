using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITopic
    {
        List<Topic> GetAllTopics();
        Topic GetTopicDetails(int id);
        List<TopicAdmin> CreateTopic(Topic topic);
        List<TopicAdmin> UpdateTopic(Topic topic);
        List<TopicAdmin> DeleteTopic(int id);
        List<TopicAdmin> GetAllTopicAdmin();

    }
}
