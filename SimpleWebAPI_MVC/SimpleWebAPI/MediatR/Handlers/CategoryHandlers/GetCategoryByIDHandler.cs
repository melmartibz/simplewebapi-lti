using MediatR;
using SimpleWebAPI.MediatR.Queries.CategoryQueries;
using SimpleWebAPI.Models.Entities;
using SimpleWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Handlers.CategoryHandlers
{
    public class GetCategoryByIDHandler : IRequestHandler<GetCategoryByIDQuery, Category>
    {
        private readonly ICategoryRepo _categoryRepo;
        public GetCategoryByIDHandler(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public Task<Category> Handle(GetCategoryByIDQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => { return _categoryRepo.GetCategoryByID(request.categid); });
        }
    }
}
