namespace Business.Implement
{
	public class OrderCallFileBusiness : BaseBusiness<OrderCallFile, IOrderCallFileRepository>, IOrderCallFileBusiness
    {
		private readonly IOrderCallFileRepository _orderCallFileRepository;
		public OrderCallFileBusiness(IOrderCallFileRepository orderCallFileRepository) : base(orderCallFileRepository)
		{
            _orderCallFileRepository = orderCallFileRepository;
		}		
	}
}
