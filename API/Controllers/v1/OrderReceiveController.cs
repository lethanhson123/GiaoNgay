namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderReceiveController : BaseController<OrderReceive, IOrderReceiveBusiness>
    {
        private readonly IOrderReceiveBusiness _orderReceiveBusiness;
        public OrderReceiveController(IOrderReceiveBusiness orderReceiveBusiness) : base(orderReceiveBusiness)
        {
            _orderReceiveBusiness = orderReceiveBusiness;
        }
    }
}
