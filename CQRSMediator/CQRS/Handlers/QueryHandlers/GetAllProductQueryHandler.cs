using CQRSMediator.Context;
using CQRSMediator.CQRS.Queries.Request;
using CQRSMediator.CQRS.Queries.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, IEnumerable<GetAllProductQueryResponse>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllProductQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();

            var result = products.Select(p => new GetAllProductQueryResponse
            {
                Id = p.Id,
                CreatedAt = p.CreatedAt,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity
            });

            return result;

        }
    }
}
