using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Commands.ProductCommand
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }
        public Guid prodid { get; set; }
        public UpdateProductCommand(Product _product, Guid _prodid)
        {
            Product = _product;
            prodid = _prodid;
        }
    }
}
