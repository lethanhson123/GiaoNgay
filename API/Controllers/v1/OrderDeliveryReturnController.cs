
namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderDeliveryReturnController : BaseController<OrderDeliveryReturn, IOrderDeliveryReturnBusiness>
    {
        private readonly IOrderDeliveryReturnBusiness _orderDeliveryReturnBusiness;
        public OrderDeliveryReturnController(IOrderDeliveryReturnBusiness orderDeliveryReturnBusiness) : base(orderDeliveryReturnBusiness)
        {
            _orderDeliveryReturnBusiness = orderDeliveryReturnBusiness;
        }       
    }
}
