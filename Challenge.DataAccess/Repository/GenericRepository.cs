using Challenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.DataAccess.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		//private readonly DbContext _context;
		//private readonly DbSet<T> _dbSet;

		//public GenericRepository(DbContext context)
		//{
		//	_context = context;
		//	_dbSet = _context.Set<T>();
		//}

		//public async Task<T> GetByIdAsync(int id)
		//{
		//	return await _dbSet.FindAsync(id);
		//}

		//public async Task<IEnumerable<T>> GetAllAsync()
		//{
		//	return await _dbSet.ToListAsync();
		//}

		//public async Task AddAsync(T entity)
		//{
		//	await _dbSet.AddAsync(entity);
		//	await _context.SaveChangesAsync();
		//}

		//public async Task UpdateAsync(T entity)
		//{
		//	_dbSet.Update(entity);
		//	await _context.SaveChangesAsync();
		//}

		//public async Task DeleteAsync(int id)
		//{
		//	var entity = await _dbSet.FindAsync(id);
		//	_dbSet.Remove(entity);
		//	await _context.SaveChangesAsync();
		//}
		public Task AddAsync(T entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<T>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
