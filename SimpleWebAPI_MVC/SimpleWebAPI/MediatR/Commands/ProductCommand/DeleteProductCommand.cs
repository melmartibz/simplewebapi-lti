using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Commands.ProductCommand
{
    public class DeleteProductCommand :IRequest<Product>
    {
        public Guid prodid { get; set; }
        public DeleteProductCommand(Guid _prodid)
        {
            prodid = _prodid;
        }
    }
}
