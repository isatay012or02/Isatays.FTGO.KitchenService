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
    Log.Fatal(ex, "��������� ���� ��������� � ����������� ({ApplicationName})!");
}
finally
{
    Log.Information("{Msg}!", "������������� �������� ������������");
    await Log.CloseAndFlushAsync();
}
