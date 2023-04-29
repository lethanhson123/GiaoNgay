namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderDeliveryStatusController : BaseController<OrderDeliveryStatus, IOrderDeliveryStatusBusiness>
    {
        private readonly IOrderDeliveryStatusBusiness _orderDeliveryStatusBusiness;
        public OrderDeliveryStatusController(IOrderDeliveryStatusBusiness orderDeliveryStatusBusiness) : base(orderDeliveryStatusBusiness)
        {
            _orderDeliveryStatusBusiness = orderDeliveryStatusBusiness;
        }
    }
}
