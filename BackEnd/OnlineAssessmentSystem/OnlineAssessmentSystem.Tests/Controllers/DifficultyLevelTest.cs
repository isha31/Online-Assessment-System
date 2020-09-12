using Entities;
using Interfaces;
using NSubstitute;
using NUnit.Framework;
using OnlineAssessmentSystem.Areas.Admin.Controllers;

using System.Collections.Generic;

using System.Net;
using System.Net.Http;

using System.Web.Http;


namespace OnlineAssessmentSystem.Tests.Controllers
{
    public class DifficultyLevelTest
    {
        DifficultyLevelController dlevelController;
        IDifficultyLevel validation;
        List<DifficultyLevel> dlevelList;

        [OneTimeSetUp]
        public void SetUp()
        {
            dlevelList = new List<DifficultyLevel>
            {
                new DifficultyLevel(23,"Test1"),
                new DifficultyLevel(24,"Test2"),
                new DifficultyLevel(25,"Test3")
            };
            validation = Substitute.For<IDifficultyLevel>();
            dlevelController = new DifficultyLevelController(validation);
        }

        [Test]
        public void DiffLevelGetAll()
        {

            validation.GetAllDifficultyLevels().Returns(dlevelList);
            dlevelController.Request = new HttpRequestMessage();
            dlevelController.Configuration = new HttpConfiguration();
            var actionResult = dlevelController.GetAllDifficultyLevels();
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void SubCategoryGetDetails()
        {



            validation.GetDifficultyLevelDetails(dlevelList[0].DifficultyLevelID).Returns(dlevelList[0]);
            dlevelController.Request = new HttpRequestMessage();
            dlevelController.Configuration = new HttpConfiguration();
            var actionResult = dlevelController.GetDifficultyLevel(dlevelList[0].DifficultyLevelID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }
    }
}
