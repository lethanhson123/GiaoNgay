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
        [HttpPost]
        [Route("GetByYearAndMonthAndDayAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderShipper>> GetByYearAndMonthAndDayAndSearchStringToLisAsync()
        {
            int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            int day = JsonConvert.DeserializeObject<int>(Request.Form["day"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderShipperBusiness.GetByYearAndMonthAndDayAndSearchStringToLisAsync(year, month, day, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderShipper>> GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderShipperBusiness.GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpGet]
        [Route("GetByIDStringAsync")]
        public async Task<OrderShipper> GetByIDStringAsync(string ID)
        {
            OrderShipper result = new OrderShipper();
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = await _orderShipperBusiness.GetByIDAsync(long.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
    }
}
