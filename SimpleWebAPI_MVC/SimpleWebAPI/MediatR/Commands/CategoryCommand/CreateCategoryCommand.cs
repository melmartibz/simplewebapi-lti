using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Commands.CategoryCommand
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public Category category { get; set; }
        public CreateCategoryCommand(Category _category)
        {
            category = _category;
        }
    }
}
