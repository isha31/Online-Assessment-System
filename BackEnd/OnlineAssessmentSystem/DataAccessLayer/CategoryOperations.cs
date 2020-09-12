using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CategoryOperations : ICategory, IDisposable
    {
        readonly OASContext ctx = new OASContext();
        string exceptionMessage;
        public int CreateCategory(Category category)
        {
            int result = 0;
            try
            {
                ctx.Categorys.Add(category);
                result = ctx.SaveChanges();
                return result;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return result;
        }

        public List<Category> DeleteCategory(int id)
        {
            List<Category> categories = new List<Category>();
            int result = 0;
            try
            {

                var existingCategory = ctx.Categorys.FirstOrDefault(category => category.CategoryID == id);
                if (existingCategory != null)
                {
                    ctx.Categorys.Remove(existingCategory);
                    result = ctx.SaveChanges();
                    categories = ctx.Categorys.ToList();

                }
                return categories;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return categories;
        }



        public List<Category> GetAllCategorys()
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = ctx.Categorys.ToList();
                return categories;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return categories;
        }

        public Category GetCategoryDetails(int id)
        {
            Category existingCategory = new Category();
            try
            {
                existingCategory = ctx.Categorys.FirstOrDefault(category => category.CategoryID == id);
                return existingCategory;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return existingCategory;
        }

        public List<Category> UpdateCategory(Category category)
        {
            List<Category> categories = new List<Category>();
            int result = 0;
            try
            {

                Category existingCategory = ctx.Categorys.FirstOrDefault(categorys => categorys.CategoryID == category.CategoryID);
                if (existingCategory != null)
                {
                    existingCategory.CategoryName = category.CategoryName;

                    result = ctx.SaveChanges();
                    categories = ctx.Categorys.ToList();
                    
                }
                return categories;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return categories;
        }

        public void Dispose()
        {
            ctx.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
