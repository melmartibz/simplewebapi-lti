using Microsoft.AspNetCore.Components;
using SimpleMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleMVC.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return (await _httpClient.GetJsonAsync<Product[]>("api/Product")).ToList();
        }

        public Task<Product> GetProductByID(Guid prodid)
        {
            throw new NotImplementedException();
        }
    }
}
