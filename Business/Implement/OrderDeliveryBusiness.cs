using Data.Model;

namespace Business.Implement
{
    public class OrderDeliveryBusiness : BaseBusiness<OrderDelivery, IOrderDeliveryRepository>, IOrderDeliveryBusiness
    {

        private readonly IOrderDeliveryRepository _orderDeliveryRepository;
        private readonly IOrderDeliveryDetailRepository _orderDeliveryDetailRepository;
        private readonly ICategoryOrderDetailRepository _categoryOrderDetailRepository;
        public OrderDeliveryBusiness(IOrderDeliveryRepository orderDeliveryRepository
            , IOrderDeliveryDetailRepository orderDeliveryDetailRepository
            , ICategoryOrderDetailRepository categoryOrderDetailRepository) : base(orderDeliveryRepository)
        {
            _orderDeliveryRepository = orderDeliveryRepository;
            _orderDeliveryDetailRepository = orderDeliveryDetailRepository;
            _categoryOrderDetailRepository = categoryOrderDetailRepository;
        }
        public virtual void Initialization01(OrderDelivery model, string webRootPath)
        {
            if (model.DateCreated == null)
            {
                model.DateCreated = GlobalHelper.InitializationDateTime;
            }
            if (model.DateCreated != null)
            {
                model.DateCreated = new DateTime(model.DateCreated.Value.Year, model.DateCreated.Value.Month, model.DateCreated.Value.Day, model.DateCreated.Value.Hour, model.DateCreated.Value.Minute, 0, 0);
            }
            if (model.Active == null)
            {
                model.Active = true;
            }
            if (model.IsExpress == null)
            {
                model.IsExpress = false;
            }
            if (model.IsShopPayment == null)
            {
                model.IsShopPayment = false;
            }
            if (model.IsPrepayment == null)
            {
                model.IsPrepayment = false;
            }
            if (model.IsCompleteShop == null)
            {
                model.IsCompleteShop = false;
            }
            if (model.IsCompleteShipper == null)
            {
                model.IsCompleteShipper = false;
            }
            if (model.DeliveryProvinceID == null)
            {
                model.DeliveryProvinceID = 1;
            }
            if (model.CategoryOrderStatusID == null)
            {
                model.CategoryOrderStatusID = 1;
            }
            if (string.IsNullOrEmpty(model.Barcode))
            {
                string pathBarcode = Path.Combine(webRootPath, GlobalHelper.Barcode);
                Helper.Model.Barcode barcode = Ean13.CreateBarcode(pathBarcode);
                model.Barcode = barcode.Code;
                model.BarcodeFile = barcode.FileName;

                string pathQRcode = Path.Combine(webRootPath, GlobalHelper.QRcode);
                Helper.Model.QRCodeModel qRCode = QRCodeHelper.CreateQRCode(model.Barcode, pathQRcode);
                model.QRcode = qRCode.Code;
                model.QRcodeFile = qRCode.FileName;
            }
        }
        public virtual async Task<OrderDelivery> SaveMembershipAsync(OrderDelivery model)
        {
            try
            {
                if (model.ID > 0)
                {
                    OrderDelivery modelExist = await _orderDeliveryRepository.GetByIDAsync(model.ID);
                    if (modelExist != null)
                    {
                        modelExist.CategoryOrderStatusID = model.CategoryOrderStatusID;
                        model.RowVersion = await _orderDeliveryRepository.UpdateAsync(modelExist);
                        if (model.RowVersion > 0)
                        {
                            //string url = GlobalHelper.APISite + "api/v1/Mail/SendMailWhenOrderDeliveryComplete?orderDeliveryID=" + model.ID;
                            //HttpClient client = new HttpClient();
                            //HttpResponseMessage response = await client.GetAsync(url);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return model;
        }
        public virtual async Task<OrderDelivery> SaveShopAsync(OrderDelivery model, string webRootPath)
        {
            try
            {
                if (model.ID > 0)
                {
                    OrderDelivery modelExist = await _orderDeliveryRepository.GetByIDAsync(model.ID);
                    if (modelExist != null)
                    {
                        modelExist.DateCreated = model.DateCreated;
                        modelExist.ShopID = model.ShopID;
                        modelExist.CustomerFullName = model.CustomerFullName;
                        modelExist.CustomerPhone = model.CustomerPhone;
                        modelExist.DeliveryAddress = model.DeliveryAddress;
                        modelExist.DeliveryProvinceID = model.DeliveryProvinceID;
                        modelExist.DeliveryDistrictID = model.DeliveryDistrictID;
                        modelExist.DeliveryWardID = model.DeliveryWardID;
                        modelExist.Note = model.Note;
                        modelExist.IsExpress = model.IsExpress;
                        modelExist.IsCompleteShop = model.IsCompleteShop;
                        modelExist.IsPrepayment = model.IsPrepayment;
                        model.RowVersion = await _orderDeliveryRepository.UpdateAsync(modelExist);
                    }
                }
                else
                {
                    Initialization01(model, webRootPath);
                    model.RowVersion = await _orderDeliveryRepository.AddAsync(model);
                    if (model.RowVersion > 0)
                    {
                        OrderDeliveryDetail orderDeliveryDetail = await SaveOrderDeliveryDetail(model);

                        //string url = GlobalHelper.APISite + "api/v1/Mail/SendMailWhenOrderDeliveryComplete?orderDeliveryID=" + model.ID;
                        //HttpClient client = new HttpClient();
                        //HttpResponseMessage response = await client.GetAsync(url);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return model;
        }
        public virtual async Task<OrderDelivery> Save01Async(OrderDelivery model, string webRootPath)
        {
            try
            {
                if (model.ID > 0)
                {
                    OrderDelivery modelExist = await _orderDeliveryRepository.GetByIDAsync(model.ID);
                    if (modelExist != null)
                    {
                        modelExist.DateCreated = model.DateCreated;
                        modelExist.ShopID = model.ShopID;
                        modelExist.ShipperID = model.ShipperID;
                        modelExist.ReceiveID = model.ReceiveID;
                        modelExist.CustomerFullName = model.CustomerFullName;
                        modelExist.CustomerPhone = model.CustomerPhone;
                        modelExist.DeliveryAddress = model.DeliveryAddress;
                        modelExist.DeliveryProvinceID = model.DeliveryProvinceID;
                        modelExist.DeliveryDistrictID = model.DeliveryDistrictID;
                        modelExist.DeliveryWardID = model.DeliveryWardID;
                        modelExist.Note = model.Note;
                        modelExist.IsExpress = model.IsExpress;
                        modelExist.IsCompleteShop = model.IsCompleteShop;
                        modelExist.IsCompleteShipper = model.IsCompleteShipper;
                        modelExist.IsShopPayment = model.IsShopPayment;

                        model.RowVersion = await _orderDeliveryRepository.UpdateAsync(modelExist);
                    }
                }
                else
                {
                    Initialization01(model, webRootPath);
                    model.RowVersion = await _orderDeliveryRepository.AddAsync(model);
                    if (model.RowVersion > 0)
                    {
                        OrderDeliveryDetail orderDeliveryDetail = await SaveOrderDeliveryDetail(model);

                        //string url = GlobalHelper.APISite + "api/v1/Mail/SendMailWhenOrderDeliveryComplete?orderDeliveryID=" + model.ID;
                        //HttpClient client = new HttpClient();
                        //HttpResponseMessage response = await client.GetAsync(url);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return model;
        }

        private async Task<OrderDeliveryDetail> SaveOrderDeliveryDetail(OrderDelivery model)
        {
            CategoryOrderDetail categoryOrderDetail = new CategoryOrderDetail();
            OrderDeliveryDetail orderDeliveryDetail = new OrderDeliveryDetail();
            orderDeliveryDetail.ParentID = model.ID;
            categoryOrderDetail = await _categoryOrderDetailRepository.GetByCondition(item => item.ProvinceID == model.DeliveryProvinceID && item.DistrictID == model.DeliveryDistrictID && item.WardID == model.DeliveryWardID).FirstOrDefaultAsync();
            if (categoryOrderDetail == null)
            {
                categoryOrderDetail = await _categoryOrderDetailRepository.GetByIDAsync(1);
            }
            if (categoryOrderDetail != null)
            {
                if (categoryOrderDetail.ID > 0)
                {
                    orderDeliveryDetail.Quantity = 1;
                    orderDeliveryDetail.CategoryOrderDetailID = categoryOrderDetail.ID;
                    orderDeliveryDetail.Name = categoryOrderDetail.Name;
                    orderDeliveryDetail.Price = categoryOrderDetail.Price;
                    orderDeliveryDetail.RowVersion = await _orderDeliveryDetailRepository.AddAsync(orderDeliveryDetail);
                }
            }
            return orderDeliveryDetail;
        }
        public async Task<List<OrderDelivery>> GetBySearchStringToLisAsync(string searchString)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _orderDeliveryRepository.GetByCondition(item => item.Active == true && (item.Barcode.Contains(searchString) || item.ShopFullName.Contains(searchString) || item.ShipperFullName.Contains(searchString) || item.CustomerFullName.Contains(searchString) || item.DeliveryAddress.Contains(searchString))).ToListAsync();
            }
            return result;
        }

        public async Task<List<OrderDelivery>> GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToLisAsync(searchString);
            }
            else
            {
                try
                {
                    dateTimeBegin = new DateTime(dateTimeBegin.Year, dateTimeBegin.Month, dateTimeBegin.Day, 0, 0, 0);
                    dateTimeEnd = new DateTime(dateTimeEnd.Year, dateTimeEnd.Month, dateTimeEnd.Day, 23, 59, 59);
                    result = await _orderDeliveryRepository.GetByCondition(item => item.Active == true && item.DateCreated >= dateTimeBegin && item.DateCreated <= dateTimeEnd).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }

        public async Task<List<OrderDelivery>> GetByOrderShipperIDToListAsync(long orderShipperID)
        {
            List<OrderDelivery> result = await _orderDeliveryRepository.GetByOrderShipperIDToListAsync(orderShipperID);
            return result;
        }
        public virtual async Task<string> UpdateByIDAndActiveAndOrderShipperIDAsync(long ID, bool active, long orderShipperID)
        {
            var result = await _orderDeliveryRepository.UpdateByIDAndActiveAndOrderShipperIDAsync(ID, active, orderShipperID);
            return result;
        }
        public async Task<List<OrderDelivery>> GetByOrderReceiveIDToListAsync(long orderReceiveID)
        {
            List<OrderDelivery> result = await _orderDeliveryRepository.GetByOrderReceiveIDToListAsync(orderReceiveID);
            return result;
        }
        public virtual async Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync(long ID, bool active, long orderReceiveID)
        {
            var result = await _orderDeliveryRepository.UpdateByIDAndActiveAndOrderReceiveIDAsync(ID, active, orderReceiveID);
            return result;
        }
        public async Task<List<OrderDelivery>> GetByMembershipIDAndSearchStringToLisAsync(long membershipID, string searchString)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _orderDeliveryRepository.GetByCondition(item => (item.ShopID == membershipID || item.ReceiveID == membershipID || item.ShipperID == membershipID) && (item.Barcode.Contains(searchString) || item.ShopFullName.Contains(searchString) || item.ShipperFullName.Contains(searchString) || item.CustomerFullName.Contains(searchString) || item.DeliveryAddress.Contains(searchString))).ToListAsync();
            }
            return result;
        }
        public async Task<List<OrderDelivery>> GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync(long membershipID, int year, int month, int day, string searchString)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetByMembershipIDAndSearchStringToLisAsync(membershipID, searchString);
            }
            else
            {
                try
                {
                    result = await _orderDeliveryRepository.GetByCondition(item => (item.ShopID == membershipID || item.ReceiveID == membershipID || item.ShipperID == membershipID) && item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderDelivery>> GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long membershipID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetByMembershipIDAndSearchStringToLisAsync(membershipID, searchString);
            }
            else
            {
                try
                {
                    dateTimeBegin = new DateTime(dateTimeBegin.Year, dateTimeBegin.Month, dateTimeBegin.Day, 0, 0, 0);
                    dateTimeEnd = new DateTime(dateTimeEnd.Year, dateTimeEnd.Month, dateTimeEnd.Day, 23, 59, 59);
                    result = await _orderDeliveryRepository.GetByCondition(item => (item.ShopID == membershipID || item.ReceiveID == membershipID || item.ShipperID == membershipID) && (item.DateCreated >= dateTimeBegin && item.DateCreated <= dateTimeEnd)).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderDelivery>> GetCRMByShopIDAndIsCompleteShopListAsync(long shopID, bool isCompleteShop)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            try
            {
                result = await _orderDeliveryRepository.GetByCondition(item => item.ShopID == shopID && item.IsCompleteShop != true).ToListAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return result;
        }
        public async Task<List<OrderDelivery>> GetByShipperIDAndIsCompleteShipperListAsync(long shipperID, bool isCompleteShipper)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            try
            {
                result = await _orderDeliveryRepository.GetByCondition(item => item.ShipperID == shipperID && item.IsCompleteShipper != true).ToListAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return result;
        }
    }
}
