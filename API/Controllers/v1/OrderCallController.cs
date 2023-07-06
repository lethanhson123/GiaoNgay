using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderCallController : BaseController<OrderCall, IOrderCallBusiness>
    {        
        private readonly IOrderCallBusiness _orderCallBusiness;             
        public OrderCallController(IWebHostEnvironment webHostEnvironment
            , IOrderCallBusiness orderCallBusiness
            , IOrderCallFileBusiness olrderCallFileBusiness) : base(orderCallBusiness)
        {            
            _orderCallBusiness = orderCallBusiness;         
        }
        [HttpPost]
        [Route("ShipperSaveAsync")]
        public virtual async Task<OrderCall> ShipperSaveAsync()
        {
            OrderCall result = JsonConvert.DeserializeObject<OrderCall>(Request.Form["data"]);
            await _orderCallBusiness.ShipperSaveAsync(result);
            return result;
        }

        [HttpPost]
        [Route("GetByYearAndMonthAndDayAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderCall>> GetByYearAndMonthAndDayAndSearchStringToLisAsync()
        {
            int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            int day = JsonConvert.DeserializeObject<int>(Request.Form["day"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderCallBusiness.GetByYearAndMonthAndDayAndSearchStringToLisAsync(year, month, day, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderCall>> GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync()
        {
            long membershipID = JsonConvert.DeserializeObject<long>(Request.Form["membershipID"]);
            int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            int day = JsonConvert.DeserializeObject<int>(Request.Form["day"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderCallBusiness.GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync(membershipID, year, month, day, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderCall>> GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderCallBusiness.GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderCall>> GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long membershipID = JsonConvert.DeserializeObject<long>(Request.Form["membershipID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderCallBusiness.GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(membershipID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderCall>> GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long membershipID = JsonConvert.DeserializeObject<long>(Request.Form["membershipID"]);
            long categoryOrderStatusID = JsonConvert.DeserializeObject<long>(Request.Form["categoryOrderStatusID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderCallBusiness.GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(membershipID, categoryOrderStatusID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetByOrderReceiveIDToListAsync")]
        public virtual async Task<List<OrderCall>> GetByOrderReceiveIDToListAsync()
        {
            long orderReceiveID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            var result = await _orderCallBusiness.GetByOrderReceiveIDToListAsync(orderReceiveID);
            return result;
        }
        [HttpPost]
        [Route("UpdateByIDAndActiveAndOrderReceiveIDAsync")]
        public virtual async Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["ID"]);
            bool active = JsonConvert.DeserializeObject<bool>(Request.Form["active"]);
            long orderReceiveID = JsonConvert.DeserializeObject<long>(Request.Form["orderReceiveID"]);
            var result = await _orderCallBusiness.UpdateByIDAndActiveAndOrderReceiveIDAsync(ID, active, orderReceiveID);
            return result;
        }       
    }
}
