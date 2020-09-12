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
    public class BLCategory: ICategory
    {
        
        
        readonly CategoryOperations _category_object;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BLCategory()
        {
            _category_object = new CategoryOperations();
        }

        public List<Category> GetAllCategorys()
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = _category_object.GetAllCategorys();
                if (categories != null)
                {
                    return categories;
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
                
                log.Error(customex.Message) ;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return categories;

        }
        public Category GetCategoryDetails(int id)
        {
            Category existingCategory = new Category();
            try
            {
                existingCategory = _category_object.GetCategoryDetails(id);
                if (existingCategory!=null)
                {
                    return existingCategory;
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
            return existingCategory;
        }
        public int CreateCategory(Category category)
        {
            int result = 0;
            try
            {
                result = _category_object.CreateCategory(category);
                if (result != null)
                {
                    return result;
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
            return result;
        }
        public List<Category> UpdateCategory(Category category)
        {
            List < Category > categories = new List<Category>();
            
            try
            {
                 categories= _category_object.UpdateCategory(category);
                if (categories != null)
                {
                    return categories;
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
            return categories;
        }
        public List<Category> DeleteCategory(int id)
        {

            List<Category> categories = new List<Category>();
            try
            {
                categories = _category_object.DeleteCategory(id);
                if (categories != null)
                {
                    return categories;
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
            return categories;
        }
    }
}
