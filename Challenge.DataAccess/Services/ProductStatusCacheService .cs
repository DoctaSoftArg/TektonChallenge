using Challenge.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.DataAccess.Services
{
	public class ProductStatusCacheService : IProductStatusCacheService
	{
		private readonly IMemoryCache _cache;
		private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);

		private static readonly Dictionary<int, string> ProductStatuses = new Dictionary<int, string>
		{
			{ 1, "Active" },
			{ 0, "Inactive" }
		};

		public ProductStatusCacheService(IMemoryCache cache)
		{
			_cache = cache;
		}

		public async Task<Dictionary<int, string>> GetProductStatusesAsync()
		{
			return await _cache.GetOrCreateAsync("ProductStatuses", entry =>
			{
				entry.AbsoluteExpirationRelativeToNow = _cacheDuration;
				return Task.FromResult(ProductStatuses);
			});
		}
	}
}
