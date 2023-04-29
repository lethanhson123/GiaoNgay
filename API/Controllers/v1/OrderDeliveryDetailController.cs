namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderDeliveryDetailController : BaseController<OrderDeliveryDetail, IOrderDeliveryDetailBusiness>
    {
        private readonly IOrderDeliveryDetailBusiness _orderDeliveryDetailBusiness;
        public OrderDeliveryDetailController(IOrderDeliveryDetailBusiness orderDeliveryDetailBusiness) : base(orderDeliveryDetailBusiness)
        {
            _orderDeliveryDetailBusiness = orderDeliveryDetailBusiness;
        }
    }
}
