using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderDeliveryController : BaseController<OrderDelivery, IOrderDeliveryBusiness>
    {
        private readonly IOrderDeliveryBusiness _orderDeliveryBusiness;
        public OrderDeliveryController(IOrderDeliveryBusiness orderDeliveryBusiness) : base(orderDeliveryBusiness)
        {
            _orderDeliveryBusiness = orderDeliveryBusiness;
        }
        [HttpPost]
        [Route("Get01ByYearAndMonthAndDayAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> Get01ByYearAndMonthAndDayAndSearchStringToLisAsync()
        {
            int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            int day = JsonConvert.DeserializeObject<int>(Request.Form["day"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.Get01ByYearAndMonthAndDayAndSearchStringToLisAsync(year, month, day, searchString);
            return result;
        }
        [HttpPost]
        [Route("Get02ByYearAndMonthAndDayAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> Get02ByYearAndMonthAndDayAndSearchStringToLisAsync()
        {
            int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            int day = JsonConvert.DeserializeObject<int>(Request.Form["day"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.Get01ByYearAndMonthAndDayAndSearchStringToLisAsync(year, month, day, searchString);
            return result;
        }
        [HttpPost]
        [Route("Get03ByYearAndMonthAndDayAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> Get03ByYearAndMonthAndDayAndSearchStringToLisAsync()
        {
            int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            int day = JsonConvert.DeserializeObject<int>(Request.Form["day"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.Get01ByYearAndMonthAndDayAndSearchStringToLisAsync(year, month, day, searchString);
            return result;
        }
    }
}
