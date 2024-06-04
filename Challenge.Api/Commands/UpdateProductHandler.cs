using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;

namespace Challenge.Api.Commands
{
	public class UpdateProductHandler
	{
		private readonly IGenericRepository<Productos> _repository;

		public UpdateProductHandler(IGenericRepository<Productos> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateProductCommand command)
		{
			var product = await _repository.GetByIdAsync(command.Id);
			if (product == null) throw new Exception("Product not found");

			product.Name = command.Name;
			product.StatusName = command.StatusName;
			product.Stock = command.Stock;
			product.Description = command.Description;
			product.Price = command.Price;
			product.Discount = command.Discount;
			product.FinalPrice = command.FinalPrice;

			await _repository.UpdateAsync(product);
		}
	}

}
