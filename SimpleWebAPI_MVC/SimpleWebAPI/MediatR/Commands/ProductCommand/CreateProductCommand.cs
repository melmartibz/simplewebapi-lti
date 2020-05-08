using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Commands.ProductCommand
{
    public class CreateProductCommand : IRequest<Product>
    {
        public Product product { get; set; }
        public CreateProductCommand(Product _product)
        {
            product = _product;
        }
    }
}
