namespace Business.Implement
{
	public class OrderDeliveryFileBusiness : BaseBusiness<OrderDeliveryFile, IOrderDeliveryFileRepository>, IOrderDeliveryFileBusiness
    {
		private readonly IOrderDeliveryFileRepository _orderDeliveryFileRepository;
		public OrderDeliveryFileBusiness(IOrderDeliveryFileRepository orderDeliveryFileRepository) : base(orderDeliveryFileRepository)
		{
            _orderDeliveryFileRepository = orderDeliveryFileRepository;
		}		
	}
}
