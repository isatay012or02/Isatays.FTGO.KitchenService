using Isatays.FTGO.KitchenService.Api.Data;

namespace Isatays.FTGO.KitchenService.Api.Repository.IRepository;

public interface IKitchenRepository
{
    Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : IEntity;
}
