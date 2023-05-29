namespace Business.Implement
{
	public class OrderDeliveryHistoryBusiness : BaseBusiness<OrderDeliveryHistory, IOrderDeliveryHistoryRepository>, IOrderDeliveryHistoryBusiness
    {
		private readonly IOrderDeliveryHistoryRepository _orderDeliveryHistoryRepository;
        private readonly IMembershipRepository _membershipRepository;
        public OrderDeliveryHistoryBusiness(IOrderDeliveryHistoryRepository orderDeliveryHistoryRepository
            , IMembershipRepository membershipRepository) : base(orderDeliveryHistoryRepository)
		{
            _orderDeliveryHistoryRepository = orderDeliveryHistoryRepository;
            _membershipRepository = membershipRepository;
        }
        public override void Initialization(OrderDeliveryHistory model)
        {            
            if (model.ShipperID != null)
            {
                Membership shipper = _membershipRepository.GetByID(model.ShipperID.Value);
                if (shipper != null)
                {
                    model.ShipperFullName = shipper.Display;                    
                }
            }
        }
    }
}
