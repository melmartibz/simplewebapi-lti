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
    public class GetProductByIDHandler : IRequestHandler<GetProductByIDQuery, Product>
    {
        private readonly IProductRepo _productRepo;
        public GetProductByIDHandler(IProductRepo productRepo) 
        {
            _productRepo = productRepo;
        }

        public async Task<Product> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => { return _productRepo.GetProductByID(request.prodid); });
        }
    }
}
