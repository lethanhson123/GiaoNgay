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
            if (model.IsComplete == null)
            {
                model.IsComplete = false;
            }
            if (model.DeliveryProvinceID == null)
            {
                model.DeliveryProvinceID = 1;
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
        public virtual async Task<OrderDelivery> Save01Async(OrderDelivery model, string webRootPath)
        {
            try
            {
                if (model.ID > 0)
                {
                    OrderDelivery modelExist = await _orderDeliveryRepository.GetByIDAsync(model.ID);
                    if (modelExist != null)
                    {
                        modelExist.ShopID = model.ShopID;
                        modelExist.ShipperID = model.ShipperID;
                        modelExist.CustomerFullName = model.CustomerFullName;
                        modelExist.CustomerPhone = model.CustomerPhone;
                        modelExist.DeliveryAddress = model.DeliveryAddress;
                        modelExist.DeliveryDistrictID = model.DeliveryDistrictID;
                        modelExist.DeliveryWardID = model.DeliveryWardID;
                        modelExist.IsExpress = model.IsExpress;
                        modelExist.IsComplete = model.IsComplete;
                        modelExist.IsShopPayment = model.IsShopPayment;
                        modelExist.IsPrepayment = model.IsPrepayment;
                        modelExist.DateCreated = model.DateCreated;
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
            if (model.IsExpress == true)
            {
                categoryOrderDetail = await _categoryOrderDetailRepository.GetByIDAsync(2);
            }
            else
            {
                categoryOrderDetail = await _categoryOrderDetailRepository.GetByIDAsync(1);
            }
            if (categoryOrderDetail != null)
            {
                orderDeliveryDetail.Quantity = 1;
                orderDeliveryDetail.CategoryOrderDetailID = categoryOrderDetail.ID;
                orderDeliveryDetail.Name = categoryOrderDetail.Name;
                orderDeliveryDetail.Price = categoryOrderDetail.Price;
                orderDeliveryDetail.RowVersion = await _orderDeliveryDetailRepository.AddAsync(orderDeliveryDetail);
            }
            return orderDeliveryDetail;
        }
        public async Task<List<OrderDelivery>> GetBySearchStringToLisAsync(string searchString)
        {
            List<OrderDelivery> result = new List<OrderDelivery>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _orderDeliveryRepository.GetByCondition(item => item.Barcode.Contains(searchString) || item.ShopFullName.Contains(searchString) || item.ShipperFullName.Contains(searchString) || item.CustomerFullName.Contains(searchString) || item.DeliveryAddress.Contains(searchString)).ToListAsync();
            }
            return result;
        }
        public async Task<List<OrderDelivery>> Get01ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString)
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
                    result = await _orderDeliveryRepository.GetByCondition(item => item.IsComplete != true && item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderDelivery>> Get02ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString)
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

                    List<long> listCategoryOrderStatusID = new List<long> { 2, 3, 4, 5, 7 };
                    result = await _orderDeliveryRepository.GetByCondition(item => item.ShipperID != null && item.IsComplete != true && item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderDelivery>> Get03ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString)
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

                    List<long> listCategoryOrderStatusID = new List<long> { 2, 3, 4, 5, 7 };
                    result = await _orderDeliveryRepository.GetByCondition(item => item.ReceiveID != null && item.IsComplete != true && item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderDelivery>> Get04ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString)
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
                    result = await _orderDeliveryRepository.GetByCondition(item => item.IsComplete == true && item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }

    }
}
