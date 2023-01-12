using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Core.DataAccess.
	EntityFramework
{
	public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
		where TEntity : class, IEntity, new()
		where TContext : DbContext, new()
	{
		public async Task<TEntity> AddAsync(TEntity entity)
		{
			using (var context = new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				await context.SaveChangesAsync();
				return entity;
			}
		}

		public async Task AddAsync(List<TEntity> entities)
		{
			using (var context = new TContext())
			{
			    await context.AddRangeAsync(entities);
				await context.SaveChangesAsync();
			}
		}

		public async Task DeleteAsync(TEntity entity)
		{
			
			if (entity is IEntityExtendedId)
			{
				var IEntityExtendedIdObj = entity as IEntityExtendedId;
				IEntityExtendedIdObj.RecordStatus = true;
				await UpdateAsync(IEntityExtendedIdObj as TEntity);
			}
			else
			{
                using (var context = new TContext())
                {
                    var delteddEntity = context.Entry(entity);
                    delteddEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                }
            }
		}

		public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
		{
			using (var context = new TContext())
			{
				context.RemoveRange(entities);
				await context.SaveChangesAsync();
			}
		}

		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
		{
			using (var context = new TContext())
			{
				return await context.Set<TEntity>().Where(x => x.RecordStatus == false).SingleOrDefaultAsync(filter);
			}
		}

		public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null,int maxCount = 100)
		{

			using (var context = new TContext())
			{
				return filter == null
					? await context.Set<TEntity>().Where(x => x.RecordStatus == false).OrderByDescending(p => p.Id).Take(maxCount).ToListAsync()
					: await context.Set<TEntity>().Where(x => x.RecordStatus == false).OrderByDescending(p => p.Id).Where(filter).Take(maxCount).ToListAsync();
			}
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			using (var context = new TContext())
			{
				return await context.Set<TEntity>().Where(x=>x.RecordStatus == false).OrderByDescending(p => p.Id).ToListAsync();
			}
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			using (var context = new TContext())
			{
				var updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				await context.SaveChangesAsync();
				return entity;
			}
		}
	}
}
