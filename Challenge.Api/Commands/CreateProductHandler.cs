using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;

namespace Challenge.Api.Commands
{
	public class CreateProductHandler
	{
		private readonly IGenericRepository<Productos> _repository;

		public CreateProductHandler(IGenericRepository<Productos> repository)
		{
			_repository = repository;
		}

		public async Task<Productos> Handle(CreateProductCommand command)
		{
			var product = new Productos
			{
				Name = command.Name,
				StatusName = command.StatusName,
				Stock = command.Stock,
				Description = command.Description,
				Price = command.Price,
				Discount = command.Discount,
				FinalPrice = command.Price * (100 - command.Discount) / 100
			};

			//Price * (100 - Discount) / 100
			await _repository.AddAsync(product);
			return product;
		}
	}

}
