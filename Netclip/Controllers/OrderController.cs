using MediatR;
using Microsoft.AspNetCore.Mvc;
using Netclip.Application.UseCases.Order.Commands;

namespace Netclip.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator mediator;
    public OrderController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public  async ValueTask<IActionResult> CreateAsync(CreateOrderCommand command)
    {
        var result= await mediator.Send(command);
        return Ok(result);
    }
}
