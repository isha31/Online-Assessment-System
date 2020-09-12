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
    public class SubCategoryTest
    {
        SubCategoryController subCategoryController;
        ISubCategory validation;
        List<SubCategory> subCategoryList;
        List<SubCategoryAdmin> subcatListAdmin;
        [OneTimeSetUp]
        public void SetUp()
        {
            subCategoryList = new List<SubCategory>
            {
                new SubCategory(23,"Test1",1),
                new SubCategory(24,"Test2",1),
                new SubCategory(25,"Test3",1)
            };

            subcatListAdmin = new List<SubCategoryAdmin>
            {
                new SubCategoryAdmin(26,"Test1",1,"Test1"),
                new SubCategoryAdmin(27,"Test2",1,"Test2"),
                new SubCategoryAdmin(28,"Test3",1,"Test3")
            };

            validation = Substitute.For<ISubCategory>();
            subCategoryController = new SubCategoryController(validation);
        }

        [Test]
        public void SubCategoryGetAll()
        {

            validation.GetAllSubCategorys().Returns(subCategoryList);
            subCategoryController.Request = new HttpRequestMessage();
            subCategoryController.Configuration = new HttpConfiguration();
            var actionResult = subCategoryController.GetAllSubCategories();
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void SubCategoryGetDetails()
        {



            validation.GetSubCategoryDetails(subCategoryList[0].SubCategoryID).Returns(subCategoryList[0]);
            subCategoryController.Request = new HttpRequestMessage();
            subCategoryController.Configuration = new HttpConfiguration();
            var actionResult = subCategoryController.GetSubCategory(subCategoryList[0].SubCategoryID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void IsSubCategoryAdded()
        {
            validation.CreateSubCategory(subCategoryList[0]).Returns(subcatListAdmin);
            subCategoryController.Request = new HttpRequestMessage();
            subCategoryController.Configuration = new HttpConfiguration();


            var actionResult = subCategoryController.PostSubCategory(subCategoryList[0]);

            Assert.AreEqual(HttpStatusCode.Created, actionResult.StatusCode);
        }

        [Test]

        public void IsSubCategoryUpdated()
        {
            validation.UpdateSubCategory(subCategoryList[0]).Returns(subcatListAdmin);
            subCategoryController.Request = new HttpRequestMessage();
            subCategoryController.Configuration = new HttpConfiguration();

            subCategoryList[0].SubCategoryName = "UpdatedSubCategory";
            var actionResult = subCategoryController.PutSubCategory(subCategoryList[0]);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]
        public void IsSubCategoryDeleted()
        {
            validation.DeleteSubCategory(subCategoryList[0].SubCategoryID).Returns(subcatListAdmin);
            subCategoryController.Request = new HttpRequestMessage();
            subCategoryController.Configuration = new HttpConfiguration();


            var actionResult = subCategoryController.DeleteSubCategory(subCategoryList[0].SubCategoryID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

    }
}
