namespace Isatays.FTGO.KitchenService.Api.Repository.IRepository;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> Add(TEntity entity);
}
