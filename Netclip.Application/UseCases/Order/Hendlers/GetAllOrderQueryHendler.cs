using MediatR;
using Microsoft.EntityFrameworkCore;
using Netclip.Application.Absreactions;
using Netclip.Application.UseCases.Order.Queries;

namespace Netclip.Application.UseCases.Order.Hendlers;

public class GetAllOrderQueryHendler : IRequestHandler<GetAllOrderQuery, List<Domain.Models.Order>>
{
    private readonly IAppDbContext _appDbContext;

    public GetAllOrderQueryHendler(IAppDbContext dbContext)
    {
        _appDbContext = dbContext;
    }
    public async Task<List<Domain.Models.Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var result=await _appDbContext.Orders.ToListAsync(cancellationToken);
        return result;
    }
}
