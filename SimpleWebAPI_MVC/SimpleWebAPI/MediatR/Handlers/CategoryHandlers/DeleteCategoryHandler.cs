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
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly ICategoryRepo _categoryRepo;
        public DeleteCategoryHandler(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category retcateg = new Category();
            Category exists = _categoryRepo.GetCategoryByID(request.categid);
            if (exists == null)
            {
                retcateg.Name = "Category does not exists";
            }
            else
            {
               _categoryRepo.RemoveCategory(exists);
            }

            return await Task.Run(() => { return retcateg; });
        }
    }
}
