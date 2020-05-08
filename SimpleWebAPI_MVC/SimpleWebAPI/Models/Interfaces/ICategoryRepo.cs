using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models.Interfaces
{
    public interface ICategoryRepo
    {
        List<Category> GetAllCategory();
        Category GetCategoryByID(Guid categID);
        Category GetCategoryByName(string name);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        void RemoveCategory(Category category);
    }
}
