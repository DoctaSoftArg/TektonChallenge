using Challenge.Api.Properties.Helpers;
using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;

namespace Challenge.Api.Queries
{
	public class GetProductByIdHandler
	{
		private readonly IGenericRepository<Productos> _repository;

		public GetProductByIdHandler(IGenericRepository<Productos> repository)
		{
			_repository = repository;
		}

		public async Task<Productos> Handle(GetProductoByIdQuery query)
		{
			var product = await _repository.GetByIdAsync(query.Id);
			if (product == null) return null;

			// Obtener el StatusName del diccionario
			var statusName = ProductStatusDictionary.Statuses.TryGetValue(product.StatusKey, out var name) ? name : "Unknown";

			return new Productos
			{
				Id = product.Id,
				Name = product.Name,
				StatusName = statusName,
				Stock = product.Stock,
				Description = product.Description,
				Price = product.Price,
				Discount = product.Discount,
				FinalPrice = product.FinalPrice
			};
		}
	}

}
