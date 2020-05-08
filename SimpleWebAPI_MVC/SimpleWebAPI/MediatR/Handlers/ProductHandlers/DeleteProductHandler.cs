using MediatR;
using SimpleWebAPI.MediatR.Commands.ProductCommand;
using SimpleWebAPI.Models.Entities;
using SimpleWebAPI.Models.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Handlers.ProductHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IProductRepo _productRepo;
        public DeleteProductHandler(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product retprod = new Product();
            Product exists = _productRepo.GetProductByID(request.prodid);
            if (exists == null)
            {
                retprod.Name = "Product does not exists";
            }
            else
            {
                _productRepo.RemoveProduct(exists);
            }

            return await Task.Run(() => { return retprod; });
        }
    }
}
