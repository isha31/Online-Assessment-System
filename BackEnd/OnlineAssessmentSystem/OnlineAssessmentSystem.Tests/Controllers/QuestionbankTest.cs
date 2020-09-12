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
    
   public class QuestionBankTest
    {
        QuestionBankController questionBankController;
        IQuestionBank validation;
        List<QuestionBank> questionBankList;

        [OneTimeSetUp]
        public void SetUp()
        {
            questionBankList = new List<QuestionBank>
            {
                new QuestionBank(23,"Test1","opt1","opt2","opt3","opt4","ans",1,1,1),
                new QuestionBank(24,"Test1","opt1","opt2","opt3","opt4","ans",1,1,1),
                new QuestionBank(25,"Test1","opt1","opt2","opt3","opt4","ans",1,1,1),
            };
            validation = Substitute.For<IQuestionBank>();
            questionBankController = new QuestionBankController(validation);
        }

        [Test]
        public void QuestionBankGetAll()
        {

            validation.GetAllQuestionBanks().Returns(questionBankList);
            questionBankController.Request = new HttpRequestMessage();
            questionBankController.Configuration = new HttpConfiguration();
            var actionResult = questionBankController.GetAllQuestionBanks();
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void QuestionBankGetDetails()
        {



            validation.GetQuestionBankDetails(questionBankList[0].QuestionBankID).Returns(questionBankList[0]);
            questionBankController.Request = new HttpRequestMessage();
            questionBankController.Configuration = new HttpConfiguration();
            var actionResult = questionBankController.GetQuestionBank(questionBankList[0].QuestionBankID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void IsQuestionBankAdded()
        {
            validation.CreateQuestionBank(1).Returns(1);
            questionBankController.Request = new HttpRequestMessage();
            questionBankController.Configuration = new HttpConfiguration();


            var actionResult = questionBankController.PostQuestionBank(1);

            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void IsQuestionBankUpdated()
        {
            validation.UpdateQuestionBank(questionBankList[0]).Returns(1);
            questionBankController.Request = new HttpRequestMessage();
            questionBankController.Configuration = new HttpConfiguration();

            questionBankList[0].Question = "UpdatedQuestionBank";
            var actionResult = questionBankController.PutQuestionBank(questionBankList[0]);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]
        public void IsQuestionBankDeleted()
        {
            validation.DeleteQuestionBank(questionBankList[0].QuestionBankID).Returns(1);
            questionBankController.Request = new HttpRequestMessage();
            questionBankController.Configuration = new HttpConfiguration();


            var actionResult = questionBankController.DeleteQuestionBank(questionBankList[0].QuestionBankID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }
    }
}
