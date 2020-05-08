using MediatR;
using SimpleWebAPI.MediatR.Commands.ProductCommand;
using SimpleWebAPI.Models.Entities;
using SimpleWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Handlers.ProductHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepo _productRepo;
        public CreateProductHandler(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product exists = _productRepo.GetProductByDetails(request.product.Name, request.product.Description, request.product.Image, request.product.CategoryID);
            if (exists != null)
            {
                return await Task.Run(() => { return new Product(); });
            }
            else
            {
                return await _productRepo.CreateProduct(request.product);
            }
        }
    }
}
