using DataAccessLayer;
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
using System.Web.Http.Results;

namespace OnlineAssessmentSystem.Tests.Controllers
{
    public class CategoryTest
    {
        CategoryController categoryController;
        ICategory validation;
        List<Category> categoryList;

        [OneTimeSetUp]
        public void SetUp()
        {
            categoryList = new List<Category>
            {
                new Category(23,"Test1"),
                new Category(24,"Test2"),
                new Category(25,"Test3")
            };

            validation = Substitute.For<ICategory>();
            categoryController = new CategoryController(validation);
        }

        [Test]
        public void CategoryGetAll()
        {

            validation.GetAllCategorys().Returns(categoryList);
            categoryController.Request = new HttpRequestMessage();
            categoryController.Configuration = new HttpConfiguration();
            var actionResult = categoryController.GetAllCategories();
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void CategoryGetDetails()
        {

            

            validation.GetCategoryDetails(categoryList[0].CategoryID).Returns(categoryList[0]);
            categoryController.Request = new HttpRequestMessage();
            categoryController.Configuration = new HttpConfiguration();
            var actionResult = categoryController.GetCategory(categoryList[0].CategoryID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]

        public void IsCategoryAdded()
        {
            validation.CreateCategory(categoryList[0]).Returns(1);
            categoryController.Request = new HttpRequestMessage();
            categoryController.Configuration = new HttpConfiguration();


            var actionResult = categoryController.PostCategory(categoryList[0]);
           
            Assert.AreEqual(HttpStatusCode.Created, actionResult.StatusCode);
        }

        [Test]

        public void IsCategoryUpdated()
        {
            validation.UpdateCategory(categoryList[0]).Returns(categoryList);
            categoryController.Request = new HttpRequestMessage();
            categoryController.Configuration = new HttpConfiguration();

            categoryList[0].CategoryName = "UpdatedCategory";
            var actionResult = categoryController.PutCategory(categoryList[0]);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]
        public void IsCategoryDeleted()
        {
            validation.DeleteCategory(categoryList[0].CategoryID).Returns(categoryList);
            categoryController.Request = new HttpRequestMessage();
            categoryController.Configuration = new HttpConfiguration();


            var actionResult = categoryController.DeleteCategory(categoryList[0].CategoryID);
            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Test]
        public void IsNotAdded()
        {
            validation.CreateCategory(categoryList[0]).Returns(0);
            categoryController.Request = new HttpRequestMessage();
            categoryController.Configuration = new HttpConfiguration();


            var actionResult = categoryController.PostCategory(categoryList[0]);

            Assert.AreEqual(HttpStatusCode.BadRequest, actionResult.StatusCode);
        }

        [Test]
        public void IsNotUpdated()
        {
            List<Category> list = new List<Category>();
            list = null;
            validation.UpdateCategory(categoryList[0]).Returns(list);
            categoryController.Request = new HttpRequestMessage();
            categoryController.Configuration = new HttpConfiguration();

            categoryList[0].CategoryName = "UpdatedCategory";
            var actionResult = categoryController.PutCategory(categoryList[0]);
            Assert.AreEqual(HttpStatusCode.BadRequest, actionResult.StatusCode);
        }

        [Test]
        public void IsNotDeleted()
        {
            List<Category> list = new List<Category>();
            list = null;
            validation.DeleteCategory(categoryList[0].CategoryID).Returns(list);
            categoryController.Request = new HttpRequestMessage();
            categoryController.Configuration = new HttpConfiguration();


            var actionResult = categoryController.DeleteCategory(categoryList[0].CategoryID);
            Assert.AreEqual(HttpStatusCode.BadRequest, actionResult.StatusCode);
        }

      
       






    }
}
