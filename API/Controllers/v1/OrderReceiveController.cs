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
        [HttpPost]
        [Route("GetByYearAndMonthAndDayAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderReceive>> GetByYearAndMonthAndDayAndSearchStringToLisAsync()
        {
            int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            int day = JsonConvert.DeserializeObject<int>(Request.Form["day"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderReceiveBusiness.GetByYearAndMonthAndDayAndSearchStringToLisAsync(year, month, day, searchString);
            return result;
        }
        [HttpGet]
        [Route("GetByIDStringAsync")]
        public async Task<OrderReceive> GetByIDStringAsync(string ID)
        {
            OrderReceive result = new OrderReceive();
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = await _orderReceiveBusiness.GetByIDAsync(long.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
    }
}
