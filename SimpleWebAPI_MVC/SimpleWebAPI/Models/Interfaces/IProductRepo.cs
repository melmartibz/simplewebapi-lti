using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models.Interfaces
{
    public interface IProductRepo
    {
        List<Product> GetAllProducts();
        List<Product> GetProductsByCategoryID(Guid categID);
        Product GetProductByID(Guid prodID);
        Product GetProductByDetails(string name, string desc, string img, Guid categid);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        void RemoveProduct(Product product);

    }
}
