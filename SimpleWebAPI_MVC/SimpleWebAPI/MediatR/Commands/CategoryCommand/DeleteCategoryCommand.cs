using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Commands.CategoryCommand
{
    public class DeleteCategoryCommand : IRequest<Category>
    {
        public Guid categid { get; set; }
        public DeleteCategoryCommand(Guid _categid) 
        {
            categid = _categid;
        }
    }
}
