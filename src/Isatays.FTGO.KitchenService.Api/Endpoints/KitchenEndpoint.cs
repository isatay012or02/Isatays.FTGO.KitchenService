using Isatays.FTGO.KitchenService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Isatays.FTGO.KitchenService.Api.Endpoints;

public static class KitchenEndpoint
{
    public static void ConfigureKitchenEndpoints(this WebApplication app)
    {
        app.MapPost("api/kitchen", CreateTicket).WithName(nameof(CreateTicket)).WithGroupName("Tickets");
    }

    [HttpPost("create", Name = nameof(CreateTicket))]
    [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(int))]
    public static async Task<IResult> CreateTicket([FromBody] CreateTicketDto request)
    {
        

        return Results.Ok();
    }
}
