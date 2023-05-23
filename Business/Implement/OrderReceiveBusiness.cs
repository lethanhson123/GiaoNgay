namespace Business.Implement
{
	public class OrderReceiveBusiness : BaseBusiness<OrderReceive, IOrderReceiveRepository>, IOrderReceiveBusiness
    {
		private readonly IOrderReceiveRepository _orderReceiveRepository;
        private readonly IMembershipRepository _membershipRepository;
        public OrderReceiveBusiness(IOrderReceiveRepository orderReceiveRepository
            , IMembershipRepository membershipRepository) : base(orderReceiveRepository)
		{
            _orderReceiveRepository = orderReceiveRepository;
            _membershipRepository = membershipRepository;
        }
        public override void Initialization(OrderReceive model)
        {
            if (model.ReceiveID != null)
            {
                Membership receive = _membershipRepository.GetByID(model.ReceiveID.Value);
                if (receive != null)
                {
                    model.Name = receive.Display;
                }
            }
        }
        public override async Task<OrderReceive> SaveAsync(OrderReceive model)
        {
            Initialization(model);
            if (model.ID > 0)
            {
                await _orderReceiveRepository.UpdateAsync(model);
            }
            else
            {
                await _orderReceiveRepository.AddAsync(model);
            }
            return model;
        }
        public async Task<List<OrderReceive>> GetBySearchStringToLisAsync(string searchString)
        {
            List<OrderReceive> result = new List<OrderReceive>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _orderReceiveRepository.GetByCondition(item => item.Name.Contains(searchString)).ToListAsync();
            }
            return result;
        }
        public async Task<List<OrderReceive>> GetByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString)
        {
            List<OrderReceive> result = new List<OrderReceive>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToLisAsync(searchString);
            }
            else
            {
                try
                {
                    result = await _orderReceiveRepository.GetByCondition(item => item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
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
