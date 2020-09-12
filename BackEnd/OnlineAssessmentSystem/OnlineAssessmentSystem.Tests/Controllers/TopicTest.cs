using Entities;
using Interfaces;
using NSubstitute;
using NUnit.Framework;
using OnlineAssessmentSystem.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineAssessmentSystem.Tests.Controllers
{
    public class TopicTest
    {
        TopicController topicController;
        ITopic validation;
        List<Topic> topicList;
        List<TopicAdmin> topicListAdmin;
        [OneTimeSetUp]
        public void SetUp()
        {
            topicList = new List<Topic>
            {
                new Topic(23,"Test1",1),
                new Topic(24,"Test2",1),
                new Topic(25,"Test3",1)
            };

            topicListAdmin = new List<TopicAdmin>
            {
                new TopicAdmin (26,"Test4",1,"Test4"),
                new TopicAdmin(27,"Test5",1,"Test5"),
                new TopicAdmin(28,"Test6",1,"Test6")
            };
            validation = Substitute.For<ITopic>();
            topicController = new TopicController(validation);
        }

        [Test]
        public void TopicGetAll()
        {

            validation.GetAllTopics().Returns(topicList);
            topicController.Request = new HttpRequestMessage();
            topicController.Configuration = new HttpConfiguration();
            var actionResult = topicController.GetAllTopics();
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void TopicGetDetails()
        {



            validation.GetTopicDetails(topicList[0].TopicID).Returns(topicList[0]);
            topicController.Request = new HttpRequestMessage();
            topicController.Configuration = new HttpConfiguration();
            var actionResult = topicController.GetTopic(topicList[0].TopicID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void IsTopicAdded()
        {
            validation.CreateTopic(topicList[0]).Returns(topicListAdmin);
            topicController.Request = new HttpRequestMessage();
            topicController.Configuration = new HttpConfiguration();


            var actionResult = topicController.PostTopic(topicList[0]);

            Assert.AreEqual(HttpStatusCode.Created, actionResult.StatusCode);
        }

        [Test]

        public void IsTopicUpdated()
        {
            validation.UpdateTopic(topicList[0]).Returns(topicListAdmin);
            topicController.Request = new HttpRequestMessage();
            topicController.Configuration = new HttpConfiguration();

            topicList[0].TopicName = "UpdatedTopic";
            var actionResult = topicController.PutTopic(topicList[0]);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]
        public void IsTopicDeleted()
        {
            validation.DeleteTopic(topicList[0].TopicID).Returns(topicListAdmin);
            topicController.Request = new HttpRequestMessage();
            topicController.Configuration = new HttpConfiguration();


            var actionResult = topicController.DeleteTopic(topicList[0].TopicID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

    }
}
