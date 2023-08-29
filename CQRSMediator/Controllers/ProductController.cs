using CQRSMediator.CQRS.Commands.Request;
using CQRSMediator.CQRS.Queries.Request;
using CQRSMediator.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest createProductCommandRequest)
        {
            //Mediator handles and provides loosy coupling
            var response = await _mediator.Send(createProductCommandRequest);
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetProductById([FromQuery] GetByIdProductQueryRequest request)
        {
            var product = await _mediator.Send(request);
            
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
