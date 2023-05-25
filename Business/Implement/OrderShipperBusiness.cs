namespace Business.Implement
{
    public class OrderShipperBusiness : BaseBusiness<OrderShipper, IOrderShipperRepository>, IOrderShipperBusiness
    {
        private readonly IOrderShipperRepository _orderShipperRepository;
        private readonly IMembershipRepository _membershipRepository;
        public OrderShipperBusiness(IOrderShipperRepository orderShipperRepository
            , IMembershipRepository membershipRepository) : base(orderShipperRepository)
        {
            _orderShipperRepository = orderShipperRepository;
            _membershipRepository = membershipRepository;
        }
        public override void Initialization(OrderShipper model)
        {
            if (model.DateCreated == null)
            {
                model.DateCreated = GlobalHelper.InitializationDateTime;
            }
            if (model.DateCreated != null)
            {
                model.DateCreated = new DateTime(model.DateCreated.Value.Year, model.DateCreated.Value.Month, model.DateCreated.Value.Day, model.DateCreated.Value.Hour, model.DateCreated.Value.Minute, 0, 0);
            }
            if (model.ShipperID != null)
            {
                Membership shipper = _membershipRepository.GetByID(model.ShipperID.Value);
                if (shipper != null)
                {
                    model.Name = shipper.Display;
                }
            }
        }
        public override async Task<OrderShipper> SaveAsync(OrderShipper model)
        {
            Initialization(model);
            if (model.ID > 0)
            {
                await _orderShipperRepository.UpdateAsync(model);
            }
            else
            {
                await _orderShipperRepository.AddAsync(model);
            }
            return model;
        }
        public async Task<List<OrderShipper>> GetBySearchStringToLisAsync(string searchString)
        {
            List<OrderShipper> result = new List<OrderShipper>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _orderShipperRepository.GetByCondition(item => item.Name.Contains(searchString)).ToListAsync();
            }
            return result;
        }
        public async Task<List<OrderShipper>> GetByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString)
        {
            List<OrderShipper> result = new List<OrderShipper>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToLisAsync(searchString);
            }
            else
            {
                try
                {
                    result = await _orderShipperRepository.GetByCondition(item => item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
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
