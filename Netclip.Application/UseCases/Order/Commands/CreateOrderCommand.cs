using MediatR;

namespace Netclip.Application.UseCases.Order.Commands;

public class CreateOrderCommand:IRequest<bool>
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string ccilka { get; set; }
    public string Task { get; set; }
}
