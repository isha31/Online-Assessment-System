using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISubCategory
    {
        List<SubCategory> GetAllSubCategorys();
        SubCategory GetSubCategoryDetails(int id);
        List<SubCategoryAdmin> CreateSubCategory(SubCategory subcategory);
        List<SubCategoryAdmin> UpdateSubCategory(SubCategory subcategory);
        List<SubCategoryAdmin> DeleteSubCategory(int id);
        List<SubCategoryAdmin> GetAllSubCatAdmin(); 

    }
}
