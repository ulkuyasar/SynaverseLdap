using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
	public interface IEntityRepository<T> where T:class,IEntity,new()
	{
		Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, int maxCount=100);
		Task<T> GetAsync(Expression<Func<T, bool>> filter);
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> AddAsync(T entity);
		Task AddAsync(List<T> entities);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task DeleteRangeAsync(IEnumerable<T> entities);

	}
}
