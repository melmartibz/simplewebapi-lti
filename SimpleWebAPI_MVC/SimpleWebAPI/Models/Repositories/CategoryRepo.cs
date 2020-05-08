using SimpleWebAPI.Data;
using SimpleWebAPI.Models.Entities;
using SimpleWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly MainDBContext _context;
        public CategoryRepo(MainDBContext mainDBContext)
        {
            _context = mainDBContext;
        }

        public List<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }
        public Category GetCategoryByID(Guid categID)
        {
            return _context.Categories.Where(p => p.ID == categID).FirstOrDefault();
        }
        public Category GetCategoryByName(string name)
        {
            return _context.Categories.Where(p => p.Name == name).FirstOrDefault();
        }

        public async Task<Category> AddCategory(Category category)
        {
            category.ID = Guid.NewGuid();

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public void RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
