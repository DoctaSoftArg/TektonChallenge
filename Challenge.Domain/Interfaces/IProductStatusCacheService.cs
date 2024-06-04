using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Interfaces
{
	public interface IProductStatusCacheService
	{
		Task<Dictionary<int, string>> GetProductStatusesAsync();
	}
}
