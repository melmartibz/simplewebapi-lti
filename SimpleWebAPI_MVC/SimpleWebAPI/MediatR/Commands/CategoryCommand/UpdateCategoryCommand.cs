using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Commands.CategoryCommand
{
    public class UpdateCategoryCommand : IRequest<Category>
    {
        public Category category { get; set; }
        public Guid categid { get; set; }
        public UpdateCategoryCommand(Category _category, Guid _categid)
        {
            category = _category;
            categid = _categid;
        }
    }
}
