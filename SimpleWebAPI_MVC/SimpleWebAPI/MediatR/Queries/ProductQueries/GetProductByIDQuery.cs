using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Queries.ProductQueries
{
    public class GetProductByIDQuery : IRequest<Product>
    {
        public Guid prodid { get; }
        public GetProductByIDQuery(Guid _prodid)
        {
            prodid = _prodid;
        }
    }
}
