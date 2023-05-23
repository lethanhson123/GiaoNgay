using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderDeliveryController : BaseController<OrderDelivery, IOrderDeliveryBusiness>
    {
        private readonly IOrderDeliveryBusiness _orderDeliveryBusiness;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public OrderDeliveryController(IOrderDeliveryBusiness orderDeliveryBusiness
            , IWebHostEnvironment webHostEnvironment) : base(orderDeliveryBusiness)
        {
            _orderDeliveryBusiness = orderDeliveryBusiness;
            _webHostEnvironment = webHostEnvironment;
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
            var result = await _orderDeliveryBusiness.Get02ByYearAndMonthAndDayAndSearchStringToLisAsync(year, month, day, searchString);
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
            var result = await _orderDeliveryBusiness.Get03ByYearAndMonthAndDayAndSearchStringToLisAsync(year, month, day, searchString);
            return result;
        }
        [HttpPost]
        [Route("Get04ByYearAndMonthAndDayAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> Get04ByYearAndMonthAndDayAndSearchStringToLisAsync()        {
            int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            int day = JsonConvert.DeserializeObject<int>(Request.Form["day"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.Get04ByYearAndMonthAndDayAndSearchStringToLisAsync(year, month, day, searchString);
            return result;
        }
        [HttpPost]
        [Route("Save01Async")]
        public virtual async Task<OrderDelivery> Save01Async()
        {
            OrderDelivery result = JsonConvert.DeserializeObject<OrderDelivery>(Request.Form["data"]);
            string webRootPath = _webHostEnvironment.WebRootPath;
            await _orderDeliveryBusiness.Save01Async(result, webRootPath);
            return result;
        }        
        [HttpGet]
        [Route("GetByIDStringAsync")]
        public async Task<OrderDelivery> GetByIDStringAsync(string ID)
        {
            OrderDelivery result = new OrderDelivery();
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = await _orderDeliveryBusiness.GetByIDAsync(long.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }            
            return result;
        }
    }
}
