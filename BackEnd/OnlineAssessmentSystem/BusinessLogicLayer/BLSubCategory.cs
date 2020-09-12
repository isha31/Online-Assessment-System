using DataAccessLayer;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLSubCategory:ISubCategory
    {
        readonly SubCategoryOperations _subcategory_object;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BLSubCategory()
        {
            _subcategory_object = new SubCategoryOperations();
        }



        public List<SubCategory> GetAllSubCategorys()
        {
            List<SubCategory> subcategories = new List<SubCategory>();
            try
            {
                subcategories = _subcategory_object.GetAllSubCategorys();
                if (subcategories != null)
                {
                    return subcategories;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {

                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return subcategories;

        }
        public SubCategory GetSubCategoryDetails(int id)
        {
            SubCategory existingSubCategory = new SubCategory();
            try
            {
                existingSubCategory = _subcategory_object.GetSubCategoryDetails(id);
                if (existingSubCategory != null)
                {
                    return existingSubCategory;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {

                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return existingSubCategory;
        }
        public List<SubCategoryAdmin> CreateSubCategory(SubCategory subcategory)
        {
            List<SubCategoryAdmin> subcategories = new List<SubCategoryAdmin>();

            
            try
            {
                subcategories = _subcategory_object.CreateSubCategory(subcategory);
                if (subcategories != null)
                {
                    return subcategories;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {

                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return subcategories;
        }
        public List<SubCategoryAdmin> UpdateSubCategory(SubCategory subcategory)
        {
            List<SubCategoryAdmin> subcategories = new List<SubCategoryAdmin>();

            try
            {
                subcategories = _subcategory_object.UpdateSubCategory(subcategory);

                if (subcategories != null)
                {
                    return subcategories;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {

                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return subcategories;
        }
        public List<SubCategoryAdmin> DeleteSubCategory(int id)
        {
            List<SubCategoryAdmin> subcategories = new List<SubCategoryAdmin>();

           
            try
            {
                subcategories = _subcategory_object.DeleteSubCategory(id);
                if (subcategories != null)
                {
                    return subcategories;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {

                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return subcategories;
        }

        public List<SubCategoryAdmin> GetAllSubCatAdmin()
        {
            List<SubCategoryAdmin> adminSubcategories = new List<SubCategoryAdmin>();
            try
            {
                adminSubcategories = _subcategory_object.GetAllSubCatAdmin();
                if (adminSubcategories != null)
                {
                    return adminSubcategories;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {

                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return adminSubcategories;
        }
    }
}
