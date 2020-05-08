using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.MediatR.Commands.CategoryCommand;
using SimpleWebAPI.MediatR.Queries.CategoryQueries;
using SimpleWebAPI.Models.Entities;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var query = new GetAllCategoryQuery();
            var output = await _mediator.Send(query);
            return Ok(output);
        }

        [HttpGet("{categid}")]
        public async Task<IActionResult> GetCategoryByID(Guid categid)
        {
            var query = new GetCategoryByIDQuery(categid);
            var output = await _mediator.Send(query);
            return Ok(output);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            try
            {
                var query = new CreateCategoryCommand(category);
                var output = await _mediator.Send(query);

                if (output.ID == Guid.Empty)
                {
                    ModelState.AddModelError("category", "Category exists");
                    return BadRequest(ModelState);
                }

                return CreatedAtAction(nameof(GetCategoryByID), new { categid = output.ID}, output);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{categid}")]
        public async Task<IActionResult> UpdateCategory(Guid categid, Category category)
        {
            var query = new UpdateCategoryCommand(category, categid);
            var output = await _mediator.Send(query);

            if (!String.IsNullOrEmpty(output.Name))
            {
                ModelState.AddModelError("category", output.Name);
                return BadRequest(ModelState);
            }
            else if (output.ID == Guid.Empty)
            {
                ModelState.AddModelError("category", "Category deos not exist");
                return BadRequest(ModelState);
            }

            return CreatedAtAction(nameof(GetCategoryByID), new { categid = output.ID }, output);
        }

        [Authorize]
        [HttpDelete("{categid}")]
        public async Task<IActionResult> DeleteCategory(Guid categid)
        {
            var query = new DeleteCategoryCommand(categid);
            var output = await _mediator.Send(query);

            if (!String.IsNullOrEmpty(output.Name))
            {
                ModelState.AddModelError("category", output.Name);
                return BadRequest(ModelState);
            }

            return RedirectToAction(nameof(GetAllCategory));
        }
    }
}