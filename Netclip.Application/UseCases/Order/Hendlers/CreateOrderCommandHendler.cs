using MediatR;
using Netclip.Application.Absreactions;
using Netclip.Application.UseCases.Order.Commands;
using System.Security.Principal;

namespace Netclip.Application.UseCases.Order.Hendlers;

public class CreateOrderCommandHendler : IRequestHandler<CreateOrderCommand,bool>
{
    private readonly IAppDbContext _appDbContext;

    public CreateOrderCommandHendler(IAppDbContext dbContext)
    {
        _appDbContext = dbContext;
    }

    async Task<bool> IRequestHandler<CreateOrderCommand, bool>.Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orders = new Domain.Models.Order()
        {
            Name = request.Name,
            Phone = request.Phone,
            ccilka = request.ccilka,
            Email = request.Email,
            Task = request.Task,
        };
        await _appDbContext.Orders.AddAsync(orders);
        int res = await _appDbContext.SaveChangesAsync(cancellationToken);

        return res > 0;
    }
}
