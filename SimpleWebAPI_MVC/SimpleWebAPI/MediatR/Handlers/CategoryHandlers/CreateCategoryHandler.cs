using MediatR;
using SimpleWebAPI.MediatR.Commands.CategoryCommand;
using SimpleWebAPI.Models.Entities;
using SimpleWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Handlers.CategoryHandlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly ICategoryRepo _categoryRepo;
        public CreateCategoryHandler(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category exists = _categoryRepo.GetCategoryByName(request.category.Name);
            if (exists != null)
            {
                return await Task.Run(() => { return new Category(); });
            }
            else
            {
                return await _categoryRepo.AddCategory(request.category);
            }
        }
    }
}
