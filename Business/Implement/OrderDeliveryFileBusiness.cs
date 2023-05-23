namespace Business.Implement
{
	public class OrderDeliveryFileBusiness : BaseBusiness<OrderDeliveryFile, IOrderDeliveryFileRepository>, IOrderDeliveryFileBusiness
    {
		private readonly IOrderDeliveryFileRepository _OrderDeliveryFileRepository;
		public OrderDeliveryFileBusiness(IOrderDeliveryFileRepository OrderDeliveryFileRepository) : base(OrderDeliveryFileRepository)
		{
            _OrderDeliveryFileRepository = OrderDeliveryFileRepository;
		}		
	}
}
