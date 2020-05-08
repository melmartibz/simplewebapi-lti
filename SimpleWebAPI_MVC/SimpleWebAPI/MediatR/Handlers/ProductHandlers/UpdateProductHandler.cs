using MediatR;
using SimpleWebAPI.MediatR.Commands.CategoryCommand;
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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepo _productRepo;
        public UpdateProductHandler(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product exists = _productRepo.GetProductByID(request.prodid);
            if (exists == null)
            {
                return await Task.Run(() => { return new Product(); });
            }
            else
            {
                Product hassamename = _productRepo.GetProductByDetails(request.Product.Name, request.Product.Description, request.Product.Image, request.Product.CategoryID);
                if (hassamename != null)
                {
                    return await Task.Run(() => {
                        Product returnprod = new Product();
                        returnprod.Name = "Product already exists";
                        return returnprod;
                    });
                }
                else
                {
                    return await _productRepo.UpdateProduct(request.Product);
                }
            }
        }
    }
}
