namespace Service.Implement
{
	public class OrderDeliveryStatusBusiness : BaseBusiness<OrderDeliveryStatus, IOrderDeliveryStatusRepository>, IOrderDeliveryStatusBusiness
    {
		private readonly IOrderDeliveryStatusRepository _orderDeliveryStatusRepository;
		public OrderDeliveryStatusBusiness(IOrderDeliveryStatusRepository orderDeliveryStatusRepository) : base(orderDeliveryStatusRepository)
		{
            _orderDeliveryStatusRepository = orderDeliveryStatusRepository;
		}		
	}
}
