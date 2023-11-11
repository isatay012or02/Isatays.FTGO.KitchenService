namespace Isatays.FTGO.KitchenService.Api.Common.Exceptions;

public abstract class ServiceUnavailableException : Exception
{
    /// <inheritdoc />
    protected ServiceUnavailableException(string method) : base(method) { }

    /// <inheritdoc />
    protected ServiceUnavailableException(string method, Exception ex) : base(method, ex) { }
}
