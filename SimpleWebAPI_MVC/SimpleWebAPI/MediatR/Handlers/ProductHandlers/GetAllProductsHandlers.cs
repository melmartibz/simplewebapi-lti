using MediatR;
using SimpleWebAPI.MediatR.Queries.ProductQueries;
using SimpleWebAPI.Models.Entities;
using SimpleWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Handlers.ProductHandlers
{
    public class GetAllProductsHandlers : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductRepo _productRepo;
        public GetAllProductsHandlers(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => { return _productRepo.GetAllProducts(); });
        }
    }
}
