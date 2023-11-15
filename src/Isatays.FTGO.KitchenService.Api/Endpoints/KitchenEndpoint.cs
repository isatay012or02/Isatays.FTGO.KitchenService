using Isatays.FTGO.KitchenService.Api.Data;
using Isatays.FTGO.KitchenService.Api.Models;
using Isatays.FTGO.KitchenService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isatays.FTGO.KitchenService.Api.Endpoints;

public static class KitchenEndpoint
{
    public static void ConfigureKitchenEndpoints(this WebApplication app)
    {
        app.MapPost("api/kitchen", CreateTicket).WithName(nameof(CreateTicket)).WithGroupName("Tickets").Produces<Ticket>(200);
    }

    //[HttpPost("create", Name = nameof(CreateTicket))]
    //[ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(int))]
    public static async Task<IResult> CreateTicket(IKitchenService kitchenService, [FromBody] CreateTicketDto request)
    {
        var result = await kitchenService.CreateTicket(request.Name, request.Description);

        return Results.Ok(result.Value);
    }
}
