using MediatR;

namespace Netclip.Application.UseCases.Order.Queries;

public class GetAllOrderQuery:IRequest<List<Domain.Models.Order>>
{
}
