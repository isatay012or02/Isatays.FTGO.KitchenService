namespace Isatays.FTGO.KitchenService.Api.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) not found.")
    {
    }
}
