using Isatays.FTGO.KitchenService.Api.Endpoints;
using Isatays.FTGO.KitchenService.Api.Features.Extensions;
using Isatays.FTGO.KitchenService.Api.Features.Middleware;
using Serilog;

var app = WebApplication.CreateBuilder(args).ConfigureBuilder().Build().ConfigureApp();

try
{
    app.UseMiddleware<LoggingMiddleware>();
    app.UseMiddleware<ExceptionHandleMiddleware>();

    app.ConfigureKitchenEndpoints();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Программа была выброшена с исплючением ({ApplicationName})!");
}
finally
{
    Log.Information("{Msg}!", "Высвобождение ресурсов логгирования");
    await Log.CloseAndFlushAsync();
}
