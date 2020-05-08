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
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly ICategoryRepo _category;
        public UpdateCategoryHandler(ICategoryRepo category)
        {
            _category = category;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category exists = _category.GetCategoryByID(request.categid);
            if (exists == null)
            {
                return await Task.Run(() => { return new Category(); });
            }
            else
            {
                Category hassamename = _category.GetCategoryByName(request.category.Name);
                if (hassamename != null)
                {
                    return await Task.Run(() => {
                        Category returncateg = new Category();
                        returncateg.Name = "Category name already exists";
                        return returncateg;
                    });
                }
                else
                {
                    return await _category.UpdateCategory(request.category);
                }
            }
        }
    }
}
