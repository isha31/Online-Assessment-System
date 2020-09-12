using BusinessLogicLayer;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineAssessmentSystem.Areas.Admin.Controllers
{
   
    public class SubCategoryController : ApiController
    {
        readonly ISubCategory _blsubcategory;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SubCategoryController(ISubCategory blsubcategory)
        {
            _blsubcategory = blsubcategory;
        }

        // GET: api/SubCategory

        
        [ResponseType(typeof(SubCategory))]

        public HttpResponseMessage GetAllSubCategories()
        {
            List<SubCategory> subcategories = null;
            try
            {
                if (ModelState.IsValid)
                {
                    subcategories = _blsubcategory.GetAllSubCategorys();

                    if (subcategories.Count == 0)
                    {
                        log.Error("Requested data has null data entries.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, subcategories);
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

        
        
       


        // GET: api/SubCategory/5

        [ResponseType(typeof(SubCategory))]
        public HttpResponseMessage GetSubCategory(int id)
        {
            SubCategory subcategory;
            try
            {
                if (ModelState.IsValid)
                {
                    subcategory = _blsubcategory.GetSubCategoryDetails(id);

                    if (subcategory == null)
                    {
                        log.Error("Requested data not found.");
                        return Request.CreateResponse(HttpStatusCode.NotFound);

                    }

                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, subcategory);

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

        // POST: api/SubCategory
       
        [ResponseType(typeof(void))]
        public HttpResponseMessage PostSubCategory(SubCategory subcategory)
        {

            List<SubCategoryAdmin> subcategories = null;

            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    subcategories = _blsubcategory.CreateSubCategory(subcategory);
                    if (subcategories!=null )
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, subcategories);
                    }
                        
                    else
                    {
                        log.Error("Subcategory failed to create");
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

        // PUT: api/SubCategory
       
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutSubCategory(SubCategory subcategory)
        {
            List<SubCategoryAdmin> subcategories = null;
            try
            {
                if (ModelState.IsValid)
                {
                    subcategories = _blsubcategory.UpdateSubCategory(subcategory);
                    if (subcategories !=null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, subcategories);
                    }
                        

                    else
                    {
                        log.Error("Subcategory failed to update");
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

        // DELETE: api/SubCategory
      
        [ResponseType(typeof(void))]
        public HttpResponseMessage DeleteSubCategory(int id)
        {
             List<SubCategoryAdmin> subcategories = null;

            try
            {
                if (ModelState.IsValid)
                {
                    subcategories = _blsubcategory.DeleteSubCategory(id);
                    if (subcategories!=null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,subcategories);
                    }
                      

                    else
                    {
                        log.Error("Subcategory failed to delete");
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


    public class AdminSubCategoryController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [ResponseType(typeof(SubCategoryAdmin))]

        public HttpResponseMessage GetAllSubCatAdmin()
        {

            BLSubCategory _blsubcategory = new BLSubCategory();
            List<SubCategoryAdmin> subcategories = null;
            try
            {
                if (ModelState.IsValid)
                {
                    subcategories = _blsubcategory.GetAllSubCatAdmin();

                    if (subcategories.Count == 0)
                    {
                        log.Error("Requested data not found");
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, subcategories);
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
