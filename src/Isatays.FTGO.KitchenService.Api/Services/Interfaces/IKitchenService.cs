using Isatays.FTGO.KitchenService.Api.Data;
using KDS.Primitives.FluentResult;

namespace Isatays.FTGO.KitchenService.Api.Services.Interfaces;

public interface IKitchenService
{
    Task<Result<Ticket>> CreateTicket(string name, string discription);
}
