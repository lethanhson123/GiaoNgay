namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderShipperDetailController : BaseController<OrderShipperDetail, IOrderShipperDetailBusiness>
    {
        private readonly IOrderShipperDetailBusiness _orderShipperDetailBusiness;
        public OrderShipperDetailController(IOrderShipperDetailBusiness orderShipperDetailBusiness) : base(orderShipperDetailBusiness)
        {
            _orderShipperDetailBusiness = orderShipperDetailBusiness;
        }
    }
}
