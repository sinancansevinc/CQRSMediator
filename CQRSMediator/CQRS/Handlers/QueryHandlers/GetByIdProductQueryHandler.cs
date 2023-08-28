using CQRSMediator.Context;
using CQRSMediator.CQRS.Queries.Request;
using CQRSMediator.CQRS.Queries.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetByIdProductQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
            return new GetByIdProductQueryResponse
            {
                Id = product.Id,
                CreatedAt = product.CreatedAt,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }
    }
}
