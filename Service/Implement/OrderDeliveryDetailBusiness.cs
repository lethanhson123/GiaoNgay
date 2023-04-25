namespace Service.Implement
{
	public class OrderDeliveryDetailBusiness : BaseBusiness<OrderDeliveryDetail, IOrderDeliveryDetailRepository>, IOrderDeliveryDetailBusiness
    {
		private readonly IOrderDeliveryDetailRepository _orderDeliveryDetailRepository;
		public OrderDeliveryDetailBusiness(IOrderDeliveryDetailRepository orderDeliveryDetailRepository) : base(orderDeliveryDetailRepository)
		{
            _orderDeliveryDetailRepository = orderDeliveryDetailRepository;
		}		
	}
}
