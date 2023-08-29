using CQRSMediator.Context;
using CQRSMediator.CQRS.Commands.Request;
using CQRSMediator.CQRS.Commands.Response;
using CQRSMediator.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.CQRS.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
               
                var product = new Product
                {
                    Name = request.Name,
                    Price = request.Price,
                    Id = request.Id,
                    Quantity = request.Quantity,
                };

                _context.Products.Attach(product);
                _context.Entry(product).Property(x => x.Quantity).IsModified = true;
                _context.Entry(product).Property(x => x.Name).IsModified = true;
                _context.Entry(product).Property(x => x.Price).IsModified = true;

                //_context.Products.Update(product);
                await _context.SaveChangesAsync();

                return new UpdateProductCommandResponse
                {
                    IsSuccess = true,
                    ProductId = product.Id
                };
            }
            catch (Exception)
            {
                return new UpdateProductCommandResponse
                {
                    IsSuccess = false,
                    ProductId = request.Id
                };
                
            }
        }
    }
}
