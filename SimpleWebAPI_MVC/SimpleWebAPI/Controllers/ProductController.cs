using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.MediatR.Commands.ProductCommand;
using SimpleWebAPI.MediatR.Handlers.ProductHandlers;
using SimpleWebAPI.MediatR.Queries.ProductQueries;
using SimpleWebAPI.Models.Entities;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var output = await _mediator.Send(query);
            return Ok(output);
        }

        [HttpGet("{prodid}")]
        public async Task<IActionResult> GetProductByID(Guid prodid)
        {
            var query = new GetProductByIDQuery(prodid);
            var output = await _mediator.Send(query);
            return Ok(output);
        }

        [HttpGet("category/{categid}")]
        public async Task<IActionResult> GetProductByCategoryID(Guid categid)
        {
            var query = new GetProductByCategoryIDQuery(categid);
            var output = await _mediator.Send(query);
            return Ok(output);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                var query = new CreateProductCommand(product);
                var output = await _mediator.Send(query);

                if (output.ID == Guid.Empty)
                {
                    ModelState.AddModelError("product", "Product alreadty exists");
                    return BadRequest(ModelState);
                }

                return CreatedAtAction(nameof(GetProductByID), new { prodid = output.ID }, output);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{prodid}")]
        public async Task<IActionResult> UpdateProduct(Guid prodid, Product product)
        {
            var query = new UpdateProductCommand(product, prodid);
            var output = await _mediator.Send(query);

            if (!String.IsNullOrEmpty(output.Name))
            {
                ModelState.AddModelError("product", output.Name);
                return BadRequest(ModelState);
            }
            else if (output.ID == Guid.Empty)
            {
                ModelState.AddModelError("product", "Product deos not exist");
                return BadRequest(ModelState);
            }

            return CreatedAtAction(nameof(GetProductByID), new { categid = output.ID }, output);
        }

        [Authorize]
        [HttpDelete("{prodid}")]
        public async Task<IActionResult> DeleteProduct(Guid prodid)
        {
            var query = new DeleteProductCommand(prodid);
            var output = await _mediator.Send(query);

            if (!String.IsNullOrEmpty(output.Name))
            {
                ModelState.AddModelError("product", output.Name);
                return BadRequest(ModelState);
            }
            return RedirectToAction(nameof(GetAllProducts));
        }
    }
}