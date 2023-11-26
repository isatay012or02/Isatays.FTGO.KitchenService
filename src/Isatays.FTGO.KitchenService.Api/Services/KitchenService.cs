using Isatays.FTGO.KitchenService.Api.Common.Exceptions;
using Isatays.FTGO.KitchenService.Api.Data;
using Isatays.FTGO.KitchenService.Api.Repository.IRepository;
using Isatays.FTGO.KitchenService.Api.Services.Interfaces;
using KDS.Primitives.FluentResult;

namespace Isatays.FTGO.KitchenService.Api.Services;

public class KitchenService : IKitchenService
{
    private readonly IKitchenRepository _kitchenRepository;
	private readonly ILogger<KitchenService> _logger;

	public KitchenService(IKitchenRepository kitchenRepository, ILogger<KitchenService> logger) => (_kitchenRepository, _logger) = (kitchenRepository, logger);

	public async Task<Result<Ticket>> CreateTicket(string name, string discription)
	{
		Ticket result = null!;
		try
		{
            var addedData = new Ticket
            {
                Name = name,
                Description = discription,
                CreatedDate = DateTime.Now,
                UpdatedDate = null
            };

            result = await _kitchenRepository.Add(addedData);
        }
		catch (DatabaseException ex)
		{
			_logger.LogError($"Не удалось добавить данные, ошибка на уровне базы данных. Описание: {ex.Message}");
		}
		catch (Exception ex)
		{
			_logger.LogError($"Не удалось добавить данные. Описание: {ex.Message}");
		}

		return Result.Success(result);
	}
}
