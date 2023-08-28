using CQRSMediator.CQRS.Queries.Response;
using MediatR;

namespace CQRSMediator.CQRS.Queries.Request
{
    public class GetAllProductQueryRequest:IRequest<IEnumerable<GetAllProductQueryResponse>>
    {
    }
}
