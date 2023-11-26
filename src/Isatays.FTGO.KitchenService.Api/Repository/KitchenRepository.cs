using Isatays.FTGO.KitchenService.Api.Common.Exceptions;
using Isatays.FTGO.KitchenService.Api.Data;
using Isatays.FTGO.KitchenService.Api.Repository.IRepository;

namespace Isatays.FTGO.KitchenService.Api.Repository;

public class KitchenRepository : IKitchenRepository
{
    private readonly DataContext _context;
    private readonly ILogger<KitchenRepository> _logger;

    public KitchenRepository(DataContext context, ILogger<KitchenRepository> logger) => (_context, _logger) = (context, logger);

	public async Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : IEntity
	{
		using (var transaction = _context.Database.BeginTransaction())
		{
			try
			{
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (DatabaseException ex)
            {
                transaction.Rollback();
                _logger.LogError($"Не удалось добавить данные, ошибка на уровне базы данных. Описание: {ex.Message}");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError($"Не удалось добавить данные. Описание: {ex.Message}");
            }
        }

		return entity;
	}
}
