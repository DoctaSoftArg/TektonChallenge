using Challenge.Api.Commands;
using Challenge.Api.Queries;
using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly CreateProductHandler _createHandler;
		private readonly UpdateProductHandler _updateHandler;
		private readonly GetProductByIdHandler _getByIdHandler;
		private readonly ILogger<ProductsController> _logger;

		public ProductsController(CreateProductHandler createHandler, UpdateProductHandler updateHandler, GetProductByIdHandler getByIdHandler, ILogger<ProductsController> logger)
		{
			_createHandler = createHandler;
			_updateHandler = updateHandler;
			_getByIdHandler = getByIdHandler;
			_logger = logger;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Productos>> GetById(int id)
		{
			var query = new GetProductoByIdQuery { Id = id };
			var product = await _getByIdHandler.Handle(query);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpPost]
		public async Task<ActionResult> Insert([FromBody] CreateProductCommand command)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var product = await _createHandler.Handle(command);
			return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				await _updateHandler.Handle(command);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating product");
				return NotFound();
			}

			return NoContent();
		}
	}


}
