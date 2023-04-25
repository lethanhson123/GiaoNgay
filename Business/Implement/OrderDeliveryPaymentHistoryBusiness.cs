namespace Business.Implement
{
	public class OrderDeliveryPaymentHistoryBusiness : BaseBusiness<OrderDeliveryPaymentHistory, IOrderDeliveryPaymentHistoryRepository>, IOrderDeliveryPaymentHistoryBusiness
    {
		private readonly IOrderDeliveryPaymentHistoryRepository _orderDeliveryPaymentHistoryRepository;
		public OrderDeliveryPaymentHistoryBusiness(IOrderDeliveryPaymentHistoryRepository orderDeliveryPaymentHistoryRepository) : base(orderDeliveryPaymentHistoryRepository)
		{
            _orderDeliveryPaymentHistoryRepository = orderDeliveryPaymentHistoryRepository;
		}		
	}
}
