using CQRSMediator.CQRS.Queries.Response;
using MediatR;

namespace CQRSMediator.CQRS.Queries.Request
{
    public class GetByIdProductQueryRequest:IRequest<GetByIdProductQueryResponse>
    {
        public int Id { get; set; }
    }
}
