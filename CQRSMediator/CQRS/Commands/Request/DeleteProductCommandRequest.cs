using CQRSMediator.CQRS.Commands.Response;
using MediatR;

namespace CQRSMediator.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }


    }
}