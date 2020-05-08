using Microsoft.AspNetCore.Components;
using SimpleMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace SimpleMVC.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return (await _httpClient.GetJsonAsync<Category[]>("api/Category")).ToList();
        }

        public Task<Category> GetCategoryByID(Guid categid)
        {
            throw new NotImplementedException();
        }
    }
}
