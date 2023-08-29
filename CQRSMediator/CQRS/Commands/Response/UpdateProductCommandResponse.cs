namespace CQRSMediator.CQRS.Commands.Response
{
    public class UpdateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int ProductId { get; set; }
    }
}
