using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SubCategoryOperations:IDisposable,ISubCategory
    {
        OASContext ctx = new OASContext();
        string exceptionMessage;
        public List<SubCategoryAdmin> CreateSubCategory(SubCategory subCategory)
        {
            List<SubCategoryAdmin> subcategories = new List<SubCategoryAdmin>();

            int result = 0;
            try
            {
                ctx.SubCategorys.Add(subCategory);
                result = ctx.SaveChanges();
                subcategories = GetAllSubCatAdmin();

                return subcategories;
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
            return subcategories;
        }

        public List<SubCategoryAdmin> DeleteSubCategory(int id)
        {
            List<SubCategoryAdmin> subcategories = new List<SubCategoryAdmin>();

            int result = 0;
            try
            {

                var existingSubCategory = ctx.SubCategorys.FirstOrDefault(subCategory => subCategory.SubCategoryID == id);
                if (existingSubCategory != null)
                {
                    ctx.SubCategorys.Remove(existingSubCategory);
                    result = ctx.SaveChanges();
                    subcategories = GetAllSubCatAdmin();

                }
                return subcategories;
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
            return subcategories;
        }

        

        public List<SubCategory> GetAllSubCategorys()
        {
            List<SubCategory> categories = new List<SubCategory>();
            try
            {
                categories = ctx.SubCategorys.ToList();
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

        public SubCategory GetSubCategoryDetails(int id)
        {
            SubCategory existingSubCategory = new SubCategory();
            try
            {
                existingSubCategory = ctx.SubCategorys.FirstOrDefault(subCategory => subCategory.SubCategoryID == id);
                return existingSubCategory;
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
            return existingSubCategory;
        }

        public List<SubCategoryAdmin> UpdateSubCategory(SubCategory subCategory)
        {
            List<SubCategoryAdmin> subList = null;
            int result = 0;
            try
            {

                SubCategory existingSubCategory = ctx.SubCategorys.FirstOrDefault(subCategorys => subCategorys.SubCategoryID == subCategory.SubCategoryID);
                if (existingSubCategory != null)
                {
                    existingSubCategory.SubCategoryName = subCategory.SubCategoryName;
                    existingSubCategory.CategoryID = subCategory.CategoryID;

                    result = ctx.SaveChanges();
                    subList = GetAllSubCatAdmin();

                }
                return subList;
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
            return subList;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        

        public List<SubCategoryAdmin> GetAllSubCatAdmin()
        {
            List<SubCategoryAdmin> subList = new List<SubCategoryAdmin>();
            try
            {
               var categories = from sub in ctx.SubCategorys join cat in ctx.Categorys on sub.CategoryID equals cat.CategoryID select new {SubID=sub.SubCategoryID,SubName=sub.SubCategoryName,CatID=sub.CategoryID,CatName=cat.CategoryName};
                foreach (var adminSub in categories)
                {

                    subList.Add(new SubCategoryAdmin()
                    {
                        SubCategoryID=adminSub.SubID,
                        SubCategoryName=adminSub.SubName,                        
                        CategoryID=adminSub.CatID,
                        CategoryName = adminSub.CatName,
                    });
                }

                return subList;
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
            return subList;
        }
    }
}
