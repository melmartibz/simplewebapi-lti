using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Queries.ProductQueries
{
    public class GetProductByCategoryIDQuery : IRequest<List<Product>>
    {
        public Guid categid { get; }
        public GetProductByCategoryIDQuery(Guid _categid)
        {
            categid = _categid;
        }
    }
}
