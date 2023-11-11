using Isatays.FTGO.KitchenService.Api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Isatays.FTGO.KitchenService.Api.Repository;

public class KitchenRepository<TEntity, TContext> : IRepository<TEntity>
	where TEntity : class 
	where TContext : DbContext
{
    private readonly TContext _context;

	public KitchenRepository(TContext context)
	{
		_context = context;
	}

	public async Task<TEntity> Add(TEntity entity)
	{
		await _context.Set<TEntity>().AddAsync(entity);
		await _context.SaveChangesAsync();

		return entity;
	}
}
