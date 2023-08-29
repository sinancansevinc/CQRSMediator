using CQRSMediator.Context;
using CQRSMediator.CQRS.Commands.Request;
using CQRSMediator.CQRS.Commands.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeleteProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return new DeleteProductCommandResponse
                {
                    IsSuccess = true
                };
            
            }
            catch (Exception)
            {

                return new DeleteProductCommandResponse
                {
                    IsSuccess = false
                };
            }
        }
    }
}
