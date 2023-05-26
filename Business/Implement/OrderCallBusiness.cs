namespace Business.Implement
{
    public class OrderCallBusiness : BaseBusiness<OrderCall, IOrderCallRepository>, IOrderCallBusiness
    {
        private readonly IOrderCallRepository _olrderCallRepository;
        private readonly IMembershipRepository _membershipRepository;
        public OrderCallBusiness(IOrderCallRepository orderCallRepository
            , IMembershipRepository membershipRepository) : base(orderCallRepository)
        {
            _olrderCallRepository = orderCallRepository;
            _membershipRepository = membershipRepository;
        }
        public override void Initialization(OrderCall model)
        {
            if (model.DateCreated == null)
            {
                model.DateCreated = GlobalHelper.InitializationDateTime;
            }
            if (model.DateCreated != null)
            {
                model.DateCreated = new DateTime(model.DateCreated.Value.Year, model.DateCreated.Value.Month, model.DateCreated.Value.Day, model.DateCreated.Value.Hour, model.DateCreated.Value.Minute, 0, 0);
            }
            if (model.ShopID != null)
            {
                Membership shop = _membershipRepository.GetByID(model.ShopID.Value);
                if (shop != null)
                {
                    model.ShopFullName = shop.Display;
                    model.ShopAddress = shop.Address;
                }
            }
            if (model.ShipperID != null)
            {
                Membership shipper = _membershipRepository.GetByID(model.ShipperID.Value);
                if (shipper != null)
                {
                    model.ShipperFullName = shipper.Display;
                    model.ShipperAddress = shipper.Address;
                }
            }
        }
        public async Task<List<OrderCall>> GetBySearchStringToLisAsync(string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _olrderCallRepository.GetByCondition(item => item.ShopFullName.Contains(searchString) || item.ShipperFullName.Contains(searchString)).ToListAsync();
            }
            return result;
        }
        public async Task<List<OrderCall>> GetByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToLisAsync(searchString);
            }
            else
            {
                try
                {
                    result = await _olrderCallRepository.GetByCondition(item => item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderCall>> GetByMembershipIDAndSearchStringToLisAsync(long membershipID, string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _olrderCallRepository.GetByCondition(item => (item.ShopID == membershipID || item.ShipperID == membershipID) && (item.ShopFullName.Contains(searchString) || item.ShipperFullName.Contains(searchString))).ToListAsync();
            }
            return result;
        }
        public async Task<List<OrderCall>> GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync(long membershipID, int year, int month, int day, string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetByMembershipIDAndSearchStringToLisAsync(membershipID, searchString);
            }
            else
            {
                try
                {
                    result = await _olrderCallRepository.GetByCondition(item => (item.ShopID == membershipID || item.ShipperID == membershipID) && (item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day)).ToListAsync();
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
