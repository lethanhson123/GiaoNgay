using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
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
        [Route("GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetCRMByProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetCRMByProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long provinceID = JsonConvert.DeserializeObject<long>(Request.Form["provinceID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetCRMByProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(provinceID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetCRMByProvinceIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetCRMByProvinceIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long provinceID = JsonConvert.DeserializeObject<long>(Request.Form["provinceID"]);
            long categoryOrderStatusID = JsonConvert.DeserializeObject<long>(Request.Form["categoryOrderStatusID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetCRMByProvinceIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(provinceID, categoryOrderStatusID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetCRMByCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetCRMByCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long categoryOrderStatusID = JsonConvert.DeserializeObject<long>(Request.Form["categoryOrderStatusID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetCRMByCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(categoryOrderStatusID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetCRMByShopAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetCRMByShopAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long shopID = JsonConvert.DeserializeObject<long>(Request.Form["shopID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetCRMByShopAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(shopID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetCRMByShipperAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetCRMByShipperAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long shipperID = JsonConvert.DeserializeObject<long>(Request.Form["shipperID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetCRMByShipperAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(shipperID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync()
        {
            long membershipID = JsonConvert.DeserializeObject<long>(Request.Form["membershipID"]);
            int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            int day = JsonConvert.DeserializeObject<int>(Request.Form["day"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync(membershipID, year, month, day, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long membershipID = JsonConvert.DeserializeObject<long>(Request.Form["membershipID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(membershipID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetByShipperIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetByShipperIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long shipperID = JsonConvert.DeserializeObject<long>(Request.Form["shipperID"]);
            long categoryOrderStatusID = JsonConvert.DeserializeObject<long>(Request.Form["categoryOrderStatusID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetByShipperIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(shipperID, categoryOrderStatusID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long membershipID = JsonConvert.DeserializeObject<long>(Request.Form["membershipID"]);
            long categoryOrderStatusID = JsonConvert.DeserializeObject<long>(Request.Form["categoryOrderStatusID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(membershipID, categoryOrderStatusID, dateTimeBegin, dateTimeEnd, searchString);
            return result;
        }
        [HttpPost]
        [Route("GetByMembershipIDAndProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync")]
        public virtual async Task<List<OrderDelivery>> GetByMembershipIDAndProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync()
        {
            long provinceID = JsonConvert.DeserializeObject<long>(Request.Form["provinceID"]);
            long membershipID = JsonConvert.DeserializeObject<long>(Request.Form["membershipID"]);
            DateTime dateTimeBegin = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeBegin"]);
            DateTime dateTimeEnd = JsonConvert.DeserializeObject<DateTime>(Request.Form["dateTimeEnd"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            var result = await _orderDeliveryBusiness.GetByMembershipIDAndProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(membershipID, provinceID, dateTimeBegin, dateTimeEnd, searchString);
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
        [HttpPost]
        [Route("SaveShopAsync")]
        public virtual async Task<OrderDelivery> SaveShopAsync()
        {
            OrderDelivery result = JsonConvert.DeserializeObject<OrderDelivery>(Request.Form["data"]);
            string webRootPath = _webHostEnvironment.WebRootPath;
            await _orderDeliveryBusiness.SaveShopAsync(result, webRootPath);
            return result;
        }
        [HttpPost]
        [Route("SaveMembershipAsync")]
        public virtual async Task<OrderDelivery> SaveMembershipAsync()
        {
            OrderDelivery result = JsonConvert.DeserializeObject<OrderDelivery>(Request.Form["data"]);
            await _orderDeliveryBusiness.SaveMembershipAsync(result);
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
        [HttpPost]
        [Route("GetByOrderShipperIDToListAsync")]
        public virtual async Task<List<OrderDelivery>> GetByOrderShipperIDToListAsync()
        {
            long orderShipperID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            var result = await _orderDeliveryBusiness.GetByOrderShipperIDToListAsync(orderShipperID);
            return result;
        }
        [HttpPost]
        [Route("UpdateByIDAndActiveAndOrderShipperIDAsync")]
        public virtual async Task<string> UpdateByIDAndActiveAndOrderShipperIDAsync()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["ID"]);
            bool active = JsonConvert.DeserializeObject<bool>(Request.Form["active"]);
            long orderShipperID = JsonConvert.DeserializeObject<long>(Request.Form["orderShipperID"]);
            var result = await _orderDeliveryBusiness.UpdateByIDAndActiveAndOrderShipperIDAsync(ID, active, orderShipperID);
            return result;
        }
        [HttpPost]
        [Route("GetByOrderReceiveIDToListAsync")]
        public virtual async Task<List<OrderDelivery>> GetByOrderReceiveIDToListAsync()
        {
            long orderReceiveID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            var result = await _orderDeliveryBusiness.GetByOrderReceiveIDToListAsync(orderReceiveID);
            return result;
        }
        [HttpPost]
        [Route("UpdateByIDAndActiveAndOrderReceiveIDAsync")]
        public virtual async Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["ID"]);
            bool active = JsonConvert.DeserializeObject<bool>(Request.Form["active"]);
            long orderReceiveID = JsonConvert.DeserializeObject<long>(Request.Form["orderReceiveID"]);
            var result = await _orderDeliveryBusiness.UpdateByIDAndActiveAndOrderReceiveIDAsync(ID, active, orderReceiveID);
            return result;
        }
        [HttpGet]
        [Route("GetCRMByShopIDAndIsCompleteShopListAsync")]
        public async Task<List<OrderDelivery>> GetCRMByShopIDAndIsCompleteShopListAsync(string shopID)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            try
            {
                shopID = shopID.Split('.')[0];
                shopID = shopID.Split('/')[shopID.Split('/').Length - 1];
                result = await _orderDeliveryBusiness.GetCRMByShopIDAndIsCompleteShopListAsync(long.Parse(shopID), false);
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("GetShopByShopIDAndIsCompleteShopListAsync")]
        public async Task<List<OrderDelivery>> GetShopByShopIDAndIsCompleteShopListAsync(long shopID)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            try
            {
                result = await _orderDeliveryBusiness.GetCRMByShopIDAndIsCompleteShopListAsync(shopID, false);
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("GetByShipperIDAndIsCompleteShipperListAsync")]
        public async Task<List<OrderDelivery>> GetByShipperIDAndIsCompleteShipperListAsync(long shipperID)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            try
            {
                result = await _orderDeliveryBusiness.GetByShipperIDAndIsCompleteShipperListAsync(shipperID, false);
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("CreateQRCodeCCCD")]
        public virtual string CreateQRCodeCCCD(string QRCode)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            return _orderDeliveryBusiness.CreateQRCodeCCCD(webRootPath, QRCode);
        }
    }
}
