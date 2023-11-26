using Isatays.FTGO.KitchenService.Api.Data;
using Isatays.FTGO.KitchenService.Api.Models;
using Isatays.FTGO.KitchenService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Isatays.FTGO.KitchenService.Api.Endpoints;

public static class KitchenEndpoint
{
    public static void ConfigureKitchenEndpoints(this WebApplication app)
    {
        app.MapPost("api/kitchen", CreateTicket)
            .WithName(nameof(CreateTicket))
            .WithGroupName("Kitchen")
            .Produces<Ticket>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json);
    }

    public static async Task<IResult> CreateTicket(IKitchenService kitchenService, [FromBody] CreateTicketDto request)
    {
        var result = await kitchenService.CreateTicket(request.Name, request.Description);

        return Results.Ok(result.Value);
    }
}
