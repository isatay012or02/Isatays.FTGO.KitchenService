using Isatays.FTGO.KitchenService.Api.Data;
using Isatays.FTGO.KitchenService.Api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Isatays.FTGO.KitchenService.Api.Repository;

public class KitchenRepository : IKitchenRepository
{
    private readonly DataContext _context;

	public KitchenRepository(DataContext context)
	{
		_context = context;
	}

	public async Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : IEntity
	{
		await _context.Set<TEntity>().AddAsync(entity);
		await _context.SaveChangesAsync();

		return entity;
	}
}
