namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderShipperController : BaseController<OrderShipper, IOrderShipperBusiness>
    {
        private readonly IOrderShipperBusiness _orderShipperBusiness;
        public OrderShipperController(IOrderShipperBusiness orderShipperBusiness) : base(orderShipperBusiness)
        {
            _orderShipperBusiness = orderShipperBusiness;
        }
    }
}
