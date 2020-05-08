using SimpleWebAPI.Data;
using SimpleWebAPI.Models.Entities;
using SimpleWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly MainDBContext _mainDBContext;
        public ProductRepo(MainDBContext mainDBContext)
        {
            _mainDBContext = mainDBContext;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> prods = _mainDBContext.Products.ToList();
            foreach (Product p in prods)
            {
                p.Category = _mainDBContext.Categories.Where(q => q.ID == p.CategoryID).FirstOrDefault();
            }

            return prods;
        }

        public Product GetProductByID(Guid prodID)
        {
            return _mainDBContext.Products.Where(p => p.ID == prodID).FirstOrDefault();
        }

        public List<Product> GetProductsByCategoryID(Guid categID)
        {
            List<Product> prods = _mainDBContext.Products.Where(p => p.CategoryID == categID).ToList();
            foreach (Product p in prods)
            {
                p.Category = _mainDBContext.Categories.Where(q => q.ID == p.CategoryID).FirstOrDefault();
            }
            return prods;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _mainDBContext.Products.Add(product);
            await _mainDBContext.SaveChangesAsync();
            return product;
        }
        public void RemoveProduct(Product product)
        {
            _mainDBContext.Products.Remove(product);
            _mainDBContext.SaveChanges();
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            _mainDBContext.Products.Update(product);
            await _mainDBContext.SaveChangesAsync();
            return product;
        }

        public Product GetProductByDetails(string name, string desc, string img, Guid categid)
        {
            return _mainDBContext.Products.Where(p => p.Name == name && p.Description == desc && p.Image == img && p.CategoryID == categid).FirstOrDefault();
        }
    }
}
