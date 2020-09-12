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
   public class TestGenerationTest
    {

        TestController testController;
        ITest validation;
        List<Test> testList;
        DateTime date = DateTime.Now;


        [OneTimeSetUp]
        public void SetUp()
        {
            testList = new List<Test>
            {
                
                new Test(23,2,2,date,2,1),
                new Test(24,2,2,date,2,1),
                new Test(25,2,2,date,2,1)
            };

            validation = Substitute.For<ITest>();
            testController = new TestController(validation);
        }


        [Test]
        public void TestGetAll()
        {

            validation.GetAllTests().Returns(testList);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();
            var actionResult = testController.GetAllTests();
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void TestGetDetails()
        {
            validation.GetTestDetails(testList[0].TestID).Returns(testList[0]);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();
            var actionResult = testController.GetTest(testList[0].TestID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]
        public void IsTestDeleted()
        {
            validation.DeleteTest(testList[0].TestID).Returns(1);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();


            var actionResult = testController.DeleteTest(testList[0].TestID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void IsTestUpdated()
        {
            validation.UpdateTest(testList[0]).Returns(1);
            testController.Request = new HttpRequestMessage();
            testController.Configuration = new HttpConfiguration();

            testList[0].TopicID = 3;
            var actionResult = testController.PutTest(testList[0]);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

    }
}
