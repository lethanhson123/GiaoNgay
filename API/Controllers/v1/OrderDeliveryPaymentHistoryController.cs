namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderDeliveryPaymentHistoryController : BaseController<OrderDeliveryPaymentHistory, IOrderDeliveryPaymentHistoryBusiness>
    {
        private readonly IOrderDeliveryPaymentHistoryBusiness _orderDeliveryPaymentHistoryBusiness;
        public OrderDeliveryPaymentHistoryController(IOrderDeliveryPaymentHistoryBusiness orderDeliveryPaymentHistoryBusiness) : base(orderDeliveryPaymentHistoryBusiness)
        {
            _orderDeliveryPaymentHistoryBusiness = orderDeliveryPaymentHistoryBusiness;
        }
    }
}
