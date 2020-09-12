using BusinessLogicLayer;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Description;

namespace OnlineAssessmentSystem.Areas.Admin.Controllers
{
    
    public class CategoryController : ApiController
    {
        readonly ICategory _blcategory;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CategoryController(ICategory category)
        {
            _blcategory = category;
        }

        // GET: api/Categories
        public HttpResponseMessage GetAllCategories()
        {
            List<Category> categories = null;
            try
            {
                if (ModelState.IsValid)
                {
                    categories = _blcategory.GetAllCategorys();

                    if (categories.Count == 0)
                    {
                        log.Error("Requested data has null data entries.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,categories);
                    }
                }
                else
                {
                    log.Error("Invalid model state encountered.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public HttpResponseMessage GetCategory(int id)
        {
            Category category;
             try
            {
                if (ModelState.IsValid)
                {
                    category = _blcategory.GetCategoryDetails(id);

                    if (category == null)
                    {
                        log.Error("Requested data not found.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }

                    else
                    {

                        return Request.CreateResponse(HttpStatusCode.OK, category);
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

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public HttpResponseMessage PostCategory(Category category)
        {


            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _blcategory.CreateCategory(category);
                    if (result > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, category);
                    }
                        
                    else
                    {
                        log.Error("New category failed to create.");
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
                return Request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
            }

        }

        // PUT: api/Categories
        
        [ResponseType(typeof(Category))]
        
        public HttpResponseMessage PutCategory(Category category)
        {

            List<Category> categories = new List<Category>();
            try
            {
                if (ModelState.IsValid)
                {
                    categories = _blcategory.UpdateCategory(category);
                    if (categories!=null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,categories);
                    }
                        

                    else
                    {
                        log.Error("Category not updated");
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

        // DELETE: api/Categories
        
        [ResponseType(typeof(Category))]
        public HttpResponseMessage DeleteCategory(int id)
        {
            List<Category> categories = new List<Category>();
            try
            {
                if (ModelState.IsValid)
                {
                    categories = _blcategory.DeleteCategory(id);
                    if (categories != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,categories);
                    }
                    else
                    {
                        log.Error("Category failed to delete");
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
}
