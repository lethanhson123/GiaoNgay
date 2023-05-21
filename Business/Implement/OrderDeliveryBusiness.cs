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
        public override void Initialization(OrderDelivery model)
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
            if (model.DeliveryProvinceID == null)
            {
                model.DeliveryProvinceID = 1;
            }
            if (model.CategoryOrderStatusID == null)
            {
                if (model.ShipperID != null)
                {
                    model.CategoryOrderStatusID = 7;
                }
                else
                {
                    model.CategoryOrderStatusID = 1;
                }
            }

        }
        public override async Task<OrderDelivery> SaveAsync(OrderDelivery model)
        {
            Initialization(model);
            if (model.ID > 0)
            {
                model.RowVersion = await _orderDeliveryRepository.UpdateAsync(model);
            }
            else
            {
                model.RowVersion = await _orderDeliveryRepository.AddAsync(model);
            }
            if (model.RowVersion > 1)
            {
                OrderDeliveryDetail orderDeliveryDetail = await SaveOrderDeliveryDetail(model);
                if (orderDeliveryDetail.RowVersion > 0)
                {
                    model = await _orderDeliveryRepository.GetByIDAsync(model.ID);
                }
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
                    result = await _orderDeliveryRepository.GetByCondition(item => item.CategoryOrderStatusID == 1 && item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
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
                    result = await _orderDeliveryRepository.GetByCondition(item => item.CategoryOrderStatusID == 6 && item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
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
                    result = await _orderDeliveryRepository.GetByCondition(item => listCategoryOrderStatusID.Contains(item.CategoryOrderStatusID.Value) && item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
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
