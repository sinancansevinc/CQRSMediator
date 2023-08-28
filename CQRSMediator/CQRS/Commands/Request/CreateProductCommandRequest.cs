using CQRSMediator.CQRS.Commands.Response;
using MediatR;

namespace CQRSMediator.CQRS.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        //Command requests and query requests must inherit IRequest interface.
        //IRequest interface takes a TResponse type generic class

        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
