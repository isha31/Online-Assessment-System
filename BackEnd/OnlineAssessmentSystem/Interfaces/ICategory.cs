using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICategory
    {
        List<Category> GetAllCategorys();
        Category GetCategoryDetails(int id);
        int CreateCategory(Category category);
        List<Category> UpdateCategory(Category category);
        List<Category> DeleteCategory(int id);

    }
}
