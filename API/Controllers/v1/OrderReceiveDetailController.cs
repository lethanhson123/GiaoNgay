namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderReceiveDetailController : BaseController<OrderReceiveDetail, IOrderReceiveDetailBusiness>
    {
        private readonly IOrderReceiveDetailBusiness _orderReceiveDetailBusiness;
        public OrderReceiveDetailController(IOrderReceiveDetailBusiness orderReceiveDetailBusiness) : base(orderReceiveDetailBusiness)
        {
            _orderReceiveDetailBusiness = orderReceiveDetailBusiness;
        }
    }
}
