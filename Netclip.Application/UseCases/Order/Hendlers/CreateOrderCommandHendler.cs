using MediatR;
using Microsoft.Extensions.Configuration;
using Netclip.Application.Absreactions;
using Netclip.Application.UseCases.Order.Commands;
using NetCLip.TelegramBot.TelegramCommands;

namespace Netclip.Application.UseCases.Order.Hendlers;

public class CreateOrderCommandHendler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly IAppDbContext _appDbContext;
    private readonly IConfiguration _configuration;

    public CreateOrderCommandHendler(IAppDbContext dbContext, IConfiguration configuration)
    {

        _appDbContext = dbContext;
        _configuration = configuration;
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

        TelegramBotSend telegram = new TelegramBotSend(_configuration);
        await telegram.SendMessageToTelegramBot(orders);

        return res > 0;
    }
}
