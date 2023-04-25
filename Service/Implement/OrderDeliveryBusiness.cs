namespace Business.Implement
{
	public class OrderDeliveryBusiness : BaseBusiness<OrderDelivery, IOrderDeliveryRepository>, IOrderDeliveryBusiness
    {
		private readonly IOrderDeliveryRepository _orderDeliveryRepository;
		public OrderDeliveryBusiness(IOrderDeliveryRepository orderDeliveryRepository) : base(orderDeliveryRepository)
		{
            _orderDeliveryRepository = orderDeliveryRepository;
		}		
	}
}
