
namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderDeliveryHistoryController : BaseController<OrderDeliveryHistory, IOrderDeliveryHistoryBusiness>
    {
        private readonly IOrderDeliveryHistoryBusiness _orderDeliveryHistoryBusiness;
        public OrderDeliveryHistoryController(IOrderDeliveryHistoryBusiness orderDeliveryHistoryBusiness) : base(orderDeliveryHistoryBusiness)
        {
            _orderDeliveryHistoryBusiness = orderDeliveryHistoryBusiness;
        }
       
    }
}
