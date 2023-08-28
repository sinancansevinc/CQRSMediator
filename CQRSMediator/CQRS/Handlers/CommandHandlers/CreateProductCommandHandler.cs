using CQRSMediator.Context;
using CQRSMediator.CQRS.Commands.Request;
using CQRSMediator.CQRS.Commands.Response;
using CQRSMediator.Models;
using MediatR;

namespace CQRSMediator.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private ApplicationDbContext _context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Product
                {
                    Name = request.Name,
                    CreatedAt = DateTime.Now,
                    Price = request.Price,
                    Quantity = request.Quantity
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return new CreateProductCommandResponse
                {
                    IsSuccess = true,
                    ProductId = product.Id
                };
            }
            catch (Exception)
            {

                return new CreateProductCommandResponse
                {
                    IsSuccess = false,
                };
            }

            
        }
    }
}
