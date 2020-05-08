using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Queries.CategoryQueries
{
    public class GetAllCategoryQuery : IRequest<List<Category>>
    {
        
    }
}
